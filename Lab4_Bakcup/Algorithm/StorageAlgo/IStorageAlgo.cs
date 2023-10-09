namespace Lab4_Bakcup
{
    interface IStorageAlgo
    {
        public void SavePoint(IRestorePoint restorePoint);
        public void DeletePoint(IRestorePoint restorePoint);
    }
}
