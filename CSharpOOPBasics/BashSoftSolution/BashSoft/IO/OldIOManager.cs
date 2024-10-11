using System.Collections.Generic;
using System.IO;

namespace BashSoft
{
    public static class OldIOManager
    {
        public static void TraverseDirectory(string path)
        {
            OutputWriter.WriteEmptyLine();
            int initialIndentitation = path.Split('\\').Length;
            Queue<string> subFolders = new Queue<string>();
            subFolders.Enqueue(path);

            while (subFolders.Count != 0)
            {
                string currentPath = subFolders.Dequeue();
                int indentitation = currentPath.Split('\\').Length - initialIndentitation;
                OutputWriter.WriteMessageOnNewLine(string.Format("{0}{1}", new string('-', indentitation), currentPath));

                foreach (string drectoryPath in Directory.GetDirectories(currentPath))
                {
                    subFolders.Enqueue(drectoryPath);
                }
            }
        }

        public static void CreateDirectoryInCurrentFolder(string name)
        {
            string path = GetCurrentDirectoryPath() + "\\" + name;
            Directory.CreateDirectory(path);
        }

        private static string GetCurrentDirectoryPath()
        {
            string path = Directory.GetCurrentDirectory();

            return path;
        }
    }
}
