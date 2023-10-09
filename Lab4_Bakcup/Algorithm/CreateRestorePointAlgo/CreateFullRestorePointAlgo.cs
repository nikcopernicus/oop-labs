using System.Collections.Generic;

namespace Lab4_Bakcup
{
    class CreateFullRestorePointAlgo : ICreateRestorePointAlgo
    {
        public IRestorePoint CreateRestorePoint(int id, List<PseudoFile> restoreFiles, List<IRestorePoint> restorePoints, IStorageAlgo storageAlgo)
        {
            var size = 0;
            foreach (var restoreFile in restoreFiles)
            {
                size += restoreFile.GetSize();
            }
            return new FullRestorePoint(id, size, restoreFiles,storageAlgo);
        }
    }
}
