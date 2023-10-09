using System;
using System.Collections.Generic;
using System.IO;

namespace Lab4_Bakcup
{
    class Program
    {
        static void Main(string[] args)
        {
            Backup backup = new Backup(new SplitStorageAlgo());
            PseudoFile a = new PseudoFile("1.txt", 100);
            backup.AddFiles(new List<PseudoFile> { a });
            backup.CreateRestorePoint(new CreateIncrementRestorePointAlgo());
            PseudoFile b = new PseudoFile("2.txt", 100);
            backup.AddFiles(new List<PseudoFile> { b });
            backup.CreateRestorePoint(new CreateFullRestorePointAlgo());
            PseudoFile c = new PseudoFile("3.txt", 100);
            backup.AddFiles(new List<PseudoFile> { c });          
            backup.CreateRestorePoint(new CreateIncrementRestorePointAlgo());
            backup.SetLimit(new SizeLimitAlgo(350));
            Console.WriteLine(backup.GetSize());
        }
    }
}
