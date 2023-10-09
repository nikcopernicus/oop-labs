using System;
using System.Collections.Generic;

namespace Lab4_Bakcup
{
    class FullRestorePoint : IRestorePoint
    {
        public int Id { get; set; }
        public DateTime CreationTime { get; set; }
        public int RestorePointSize { get; set; }
        public List<PseudoFile> RestorePointFiles { get; set; }
        public IStorageAlgo StorageAlgo { get; set; }

        public FullRestorePoint(int id, int restorePointSize, List<PseudoFile> restorePointFiles, IStorageAlgo storageAlgo)
        {
            Id = id;
            CreationTime = DateTime.Now;
            RestorePointSize = restorePointSize;
            RestorePointFiles = new List<PseudoFile>(restorePointFiles);
            StorageAlgo = storageAlgo;
        }
    }
}
