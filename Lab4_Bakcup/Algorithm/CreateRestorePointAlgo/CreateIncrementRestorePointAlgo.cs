using System;
using System.Collections.Generic;
using System.Linq;

namespace Lab4_Bakcup
{
    class CreateIncrementRestorePointAlgo : ICreateRestorePointAlgo
    {
        public IRestorePoint CreateRestorePoint(int id, List<PseudoFile> restoreFiles, List<IRestorePoint> restorePoints, IStorageAlgo storageAlgo)
        {
            var delta = 0;
            foreach (var restoreFile in restoreFiles)
            {                
                delta += restoreFile.GetSize();
                restoreFile.SetSize(restoreFile.GetSize() + Convert.ToInt32(Math.Round(Convert.ToDouble(restoreFile.GetSize()) * 1.4)));
            }
            return new IncrementRestorePoint(id, delta, restoreFiles, storageAlgo);
        }
    }
}
