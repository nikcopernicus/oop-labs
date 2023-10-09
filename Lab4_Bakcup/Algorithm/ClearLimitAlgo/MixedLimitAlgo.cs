using System.Collections.Generic;

namespace Lab4_Bakcup
{
    public enum MixedLimitMode
    {
        ALL = 0,
        ANY = 1
    };

    class MixedLimitAlgo : IClearLimitAlgo
    {
        public List<IClearLimitAlgo> LimitAlgos;
        public MixedLimitMode Mode;
        public MixedLimitAlgo(List<IClearLimitAlgo> limitAlgos, MixedLimitMode mode)
        {
            LimitAlgos = limitAlgos;
            Mode = mode;
        }
        public List<IRestorePoint> ClearLimit(List<IRestorePoint> restorePoints)
        {
            switch (Mode)
            {
                case MixedLimitMode.ALL:
                    List<IRestorePoint> minRemovedPoints = new List<IRestorePoint>();
                    foreach(IClearLimitAlgo limitAlgo in LimitAlgos)
                    {
                        if ((minRemovedPoints.Count < limitAlgo.ClearLimit(restorePoints).Count) || (minRemovedPoints.Count == 0))
                        {
                            minRemovedPoints = limitAlgo.ClearLimit(restorePoints);
                        }
                    }
                    return minRemovedPoints;

                case MixedLimitMode.ANY:
                    List<IRestorePoint> maxRemovedPoints = new List<IRestorePoint>();
                    foreach (IClearLimitAlgo limitAlgo in LimitAlgos)
                    {
                        foreach(IRestorePoint removePoint in limitAlgo.ClearLimit(restorePoints))
                        {
                            if (!maxRemovedPoints.Contains(removePoint))
                            {
                                maxRemovedPoints.Add(removePoint);
                            }
                        }                        
                    }
                    return maxRemovedPoints;

                default:
                    return null;
            }
            
        }
    }
}
