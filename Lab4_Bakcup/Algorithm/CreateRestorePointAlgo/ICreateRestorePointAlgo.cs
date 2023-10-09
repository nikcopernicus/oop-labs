using System.Collections.Generic;

namespace Lab4_Bakcup
{
    interface ICreateRestorePointAlgo
    {
        public IRestorePoint CreateRestorePoint(int id,List<PseudoFile> restoreFiles,List<IRestorePoint> restorePoints, IStorageAlgo storageAlgo);
    }
}
