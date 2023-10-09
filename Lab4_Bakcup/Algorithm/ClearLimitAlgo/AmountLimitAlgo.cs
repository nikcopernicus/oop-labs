using System.Collections.Generic;

namespace Lab4_Bakcup
{
    class AmountLimitAlgo : IClearLimitAlgo
    {
        public int LimitValue;
        public AmountLimitAlgo(int limitValue)
        {
            LimitValue = limitValue;
        }
        public List<IRestorePoint> ClearLimit(List<IRestorePoint> restorePoints)
        {
            List<IRestorePoint> removedPoints = new List<IRestorePoint>();
            foreach (IRestorePoint restorePoint in restorePoints)
            {
                if (restorePoints.Count - removedPoints.Count > LimitValue)
                {
                    removedPoints.Add(restorePoint);
                }
                else
                {
                    break;
                }
            }
            return removedPoints;
        }
    }
}
