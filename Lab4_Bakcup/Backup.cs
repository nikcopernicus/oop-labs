using System;
using System.Collections.Generic;

namespace Lab4_Bakcup
{
    class Backup
    {
        public int Id;
        public DateTime CreationTime;
        public int BackupSize;
        public List<IRestorePoint> RestorePoints;
        public List<PseudoFile> BackupedFiles;
        public IStorageAlgo StorageAlgo;
        public IClearLimitAlgo ClearLimitAlgo;
        public Backup(IStorageAlgo storageAlgo)
        {
            Id = 0;
            CreationTime = DateTime.Now;
            BackupSize = 0;
            RestorePoints = new List<IRestorePoint>();
            BackupedFiles = new List<PseudoFile>();
            StorageAlgo = storageAlgo;
            ClearLimitAlgo = null;
        }
        public void AddFiles(List<PseudoFile> backupedFiles)
        {
            foreach (var backupedFile in backupedFiles)
            {
                BackupedFiles.Add(backupedFile);
            }
        }
        public void DeleteFiles(List<PseudoFile> backupedFiles)
        {
            foreach (var backupedFile in backupedFiles)
            {
                BackupedFiles.Remove(backupedFile);
            }
        }
        public void CreateRestorePoint(ICreateRestorePointAlgo restorePointAlgo)
        {
            IRestorePoint newRestorePoint = restorePointAlgo.CreateRestorePoint(Id, BackupedFiles, RestorePoints, StorageAlgo);
            RestorePoints.Add(newRestorePoint);
            BackupSize += newRestorePoint.RestorePointSize;
            Id++;
            newRestorePoint.StorageAlgo.SavePoint(newRestorePoint);
            Clear();
        }
        public void SetLimit(IClearLimitAlgo clearLimitAlgo)
        {
            ClearLimitAlgo = clearLimitAlgo;
            Clear();
        }
        public void Clear()
        {
            if (ClearLimitAlgo == null)
            {
                return;
            }
            List<IRestorePoint> removedPoints = new List<IRestorePoint>();
            List<IRestorePoint> limitPoints = ClearLimitAlgo.ClearLimit(RestorePoints);
            foreach (IRestorePoint limitPoint in limitPoints)
            {
                foreach (IRestorePoint point in RestorePoints)
                {
                    if (point.Id > limitPoint.Id)
                    {
                        if (point.GetType() == typeof(FullRestorePoint))
                        {
                            removedPoints.Add(limitPoint);
                        }
                    }
                }
            }
            foreach (IRestorePoint removePoint in removedPoints)
            {
                RestorePoints.Remove(removePoint);
                BackupSize -= removePoint.RestorePointSize;
                removePoint.StorageAlgo.DeletePoint(removePoint);
            }
            if (limitPoints.Count - removedPoints.Count > 0)
            {
                Console.WriteLine("Warning: unable to remove some restore points!");
            }
        }
    }
}
