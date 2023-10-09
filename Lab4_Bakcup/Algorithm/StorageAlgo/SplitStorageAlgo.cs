using System;

namespace Lab4_Bakcup
{
    class SplitStorageAlgo : IStorageAlgo
    {
        public void DeletePoint(IRestorePoint restorePoint)
        {
            Console.WriteLine("Deleted file folders:\nrestore point id - " + restorePoint.Id + "\nrestore point size - " + restorePoint.RestorePointSize);
            foreach (var restorePointFile in restorePoint.RestorePointFiles)
            {
                Console.WriteLine("File " + restorePointFile.GetName() + " in Folder " + restorePoint.Id + "Folder_File_" + restorePointFile.GetName().Split('.')[0] + " Deleted");
            }
            Console.WriteLine();
        }
        public void SavePoint(IRestorePoint restorePoint)
        {
            Console.WriteLine("File folders Saved:\nrestore point id - " + restorePoint.Id + "\nrestore point size - " + restorePoint.RestorePointSize);
            foreach (var restorePointFile in restorePoint.RestorePointFiles)
            {
                Console.WriteLine("File " + restorePointFile.GetName() + " in Folder " + restorePoint.Id + "Folder_File_" + restorePointFile.GetName().Split('.')[0] + " Saved");
            }
            Console.WriteLine();
        }
    }
}
