using System.Collections.Generic;

namespace Lab4_Bakcup
{
    class SizeLimitAlgo : IClearLimitAlgo
    {
        public int LimitValue;
        public SizeLimitAlgo(int limitValue)
        {
            LimitValue = limitValue;
        }
        public List<IRestorePoint> ClearLimit(List<IRestorePoint> restorePoints)
        {
            List<IRestorePoint> removedPoints = new List<IRestorePoint>();
            int sum = 0;
            foreach (IRestorePoint point in restorePoints)
            {
                sum += point.RestorePointSize;
            }
            foreach (IRestorePoint restorePoint in restorePoints)
            {                
                if (sum > LimitValue)
                {
                    sum -= restorePoint.RestorePointSize;
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
