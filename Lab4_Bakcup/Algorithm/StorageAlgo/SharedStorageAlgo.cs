using System;

namespace Lab4_Bakcup
{
    class SharedStorageAlgo : IStorageAlgo
    {
        public void DeletePoint(IRestorePoint restorePoint)
        {
            Console.WriteLine("Deleted restore archive:\nrestore point id - " + restorePoint.Id + "\nrestore point size - " + restorePoint.RestorePointSize);
            Console.WriteLine("Deleted Archive " + restorePoint.Id + ".rar files:");
            foreach (var restorePointFile in restorePoint.RestorePointFiles)
            {
                Console.WriteLine(restorePointFile.GetName());
            }
            Console.WriteLine();
        }
        public void SavePoint(IRestorePoint restorePoint)
        {
            Console.WriteLine("Restore archive saved:\nrestore point id - " + restorePoint.Id + "\nrestore point size - " + restorePoint.RestorePointSize);
            Console.WriteLine("SavedArchive " + restorePoint.Id + ".rar files:");
            foreach (var restorePointFile in restorePoint.RestorePointFiles)
            {
                Console.WriteLine(restorePointFile.GetName());
            }
            Console.WriteLine();
        }
    }
}
