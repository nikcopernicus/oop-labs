using System.Collections.Generic;

namespace Lab4_Bakcup
{
    interface IClearLimitAlgo
    {
        public List<IRestorePoint> ClearLimit(List<IRestorePoint> restorePoints);
    }
}
