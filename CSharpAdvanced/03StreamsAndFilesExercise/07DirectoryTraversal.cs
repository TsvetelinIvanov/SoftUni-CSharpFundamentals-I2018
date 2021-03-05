using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _07DirectoryTraversal
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = Console.ReadLine();
            string[] files = Directory.GetFiles(path);
            Dictionary<string, List<FileInfo>> filesDictionary = new Dictionary<string, List<FileInfo>>();
            foreach (string file in files)
            {
                FileInfo fileInfo = new FileInfo(file);
                string extension = fileInfo.Extension;
                if (!filesDictionary.ContainsKey(extension))
                {
                    filesDictionary[extension] = new List<FileInfo>();
                }

                filesDictionary[extension].Add(fileInfo);
            }

            filesDictionary = filesDictionary.OrderByDescending(f => f.Value.Count).ThenBy(f => f.Key)
                .ToDictionary(x => x.Key, y => y.Value);
            string desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string fullFileName = desktop + "/report.txt";

            using (StreamWriter writer = new StreamWriter(fullFileName))
            {
                foreach (KeyValuePair<string, List<FileInfo>> pair in filesDictionary)
                {
                    string extension = pair.Key;
                    Console.WriteLine(extension);
                    List<FileInfo> fileInfos = pair.Value.OrderByDescending(f => f.Length).ToList();
                    foreach (FileInfo fileInfo in fileInfos)
                    {
                        double fileSize = (double)fileInfo.Length / 1024;
                        writer.WriteLine($"--{fileInfo.Name} - {fileSize}kb");
                    }
                }
            }
        }
    }
}
