using System;
using System.Collections.Generic;

namespace Lab4_Bakcup
{
    interface IRestorePoint
    {
        public int Id { get; set; }
        public DateTime CreationTime { get; set; }
        public int RestorePointSize { get; set; }
        public List<PseudoFile> RestorePointFiles { get; set; }
        public IStorageAlgo StorageAlgo { get; set; }
    }
}
