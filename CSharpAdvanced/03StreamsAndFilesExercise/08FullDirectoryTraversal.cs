using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _08FullDirectoryTraversal
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = Console.ReadLine();
            List<string> files = GetAllDirectories(path);
            if (!files.Any())
            {
                Console.WriteLine("No directories found!");
                Environment.Exit(0);
            }

            Dictionary<string, List<FileInfo>> filesDictionary = new Dictionary<string, List<FileInfo>>();
            foreach (string file in files)
            {
                GetDirectoryFilesByExtention(file, filesDictionary);
            }

            if (!filesDictionary.Any())
            {
                Console.WriteLine("No files found!");
                Environment.Exit(0);
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

        private static List<string> GetAllDirectories(string directoryPath)
        {
            List<string> allDirectories = new List<string>();
            string[] directories = Directory.GetDirectories(directoryPath);
            foreach (string directory in directories)
            {
                allDirectories.AddRange(GetAllDirectories(directory));
            }

            allDirectories.Add(directoryPath);
            return allDirectories;
        }

        private static void GetDirectoryFilesByExtention(string directoryPath,
            Dictionary<string, List<FileInfo>> files)
        {
            string[] fullPaths = Directory.GetFiles(directoryPath);
            foreach (string file in fullPaths)
            {
                string extention = file.Substring(file.LastIndexOf('.'));
                if (!files.ContainsKey(extention))
                {
                    files[extention] = new List<FileInfo>();
                }

                FileInfo fileInfo = new FileInfo(file);
                files[extention].Add(fileInfo);
            }
        }
    }
}
