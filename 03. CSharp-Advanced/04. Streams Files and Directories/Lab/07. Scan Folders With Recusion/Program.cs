using System;
using System.IO;

namespace _07.ScanFoldersWithRecusion
{
    class Program
    {
        static void Main(string[] args)
        {
            //
            string folderPath = Console.ReadLine();

            Console.WriteLine(ScanFolderRecursively(folderPath, 0));
        }
        static double ScanFolderRecursively(string folderPath, int identation)
        {
            string[] files = Directory.GetFiles(folderPath);

            double fileSizes = 0;
             
            var directories = Directory.GetDirectories(folderPath);

            foreach (var directory in directories)
            {
                fileSizes += ScanFolderRecursively(directory, identation + 4);
            }

            foreach (var filePath in files)
            {
                FileInfo file = new FileInfo(filePath);

                Console.WriteLine($"{new string(' ', identation)}{file.FullName}");
                //Console.WriteLine(file.Length);
                //Console.WriteLine(file.Extension);

                fileSizes += file.Length;
            }

            return fileSizes / 1024.0 / 1024.0;
        }
    }
}
