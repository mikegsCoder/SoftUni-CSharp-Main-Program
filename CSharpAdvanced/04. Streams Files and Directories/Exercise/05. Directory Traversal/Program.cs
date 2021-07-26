using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _05._Directory_Traversal
{
    class Program
    {
        static void Main(string[] args)
        {
            string directoryPath = Directory.GetCurrentDirectory();
            string[] fileNames = Directory.GetFiles(directoryPath);
            Dictionary<string, Dictionary<string, double>> filesData =
                new Dictionary<string, Dictionary<string, double>>();

            foreach (string fileName in fileNames)
            {
                FileInfo fileinfo = new FileInfo(fileName);
                string extension = fileinfo.Extension;
                long size = fileinfo.Length;
                double kbSize = Math.Round(size / 1024.0, 3);

                if (!filesData.ContainsKey(extension))
                {
                    filesData.Add(extension, new Dictionary<string, double>());
                }

                filesData[extension].Add(fileinfo.Name, kbSize);
            }

            Dictionary<string, Dictionary<string, double>> sortedDict =
                filesData.OrderByDescending(x => x.Value.Count)
                .ThenBy(x => x.Key)
                .ToDictionary(kvp => kvp.Key, kvp => kvp.Value);

            List<string> result = new List<string>();

            foreach (var item in sortedDict)
            {
                result.Add(item.Key);

                foreach (var fileData in item.Value.OrderBy(x => x.Value))
                {
                    result.Add($"--{fileData.Key} - {fileData.Value}kb");
                }
            }

            string filePath = Path.Combine(Environment.
                GetFolderPath(Environment.SpecialFolder.Desktop), "report.txt");
            File.WriteAllLines(filePath, result);
        }
    }
}
