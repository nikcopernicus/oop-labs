using System;
using System.Collections.Generic;

namespace Lab4_Bakcup
{
    class DateLimitAlgo : IClearLimitAlgo
    {
        public DateTime LimitValue;
        public DateLimitAlgo(DateTime limitValue)
        {
            LimitValue = limitValue;
        }
        public List<IRestorePoint> ClearLimit(List<IRestorePoint> restorePoints)
        {
            List<IRestorePoint> removedPoints = new List<IRestorePoint>();
            foreach (IRestorePoint restorePoint in restorePoints)
            {
                if (restorePoint.CreationTime < LimitValue)
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
