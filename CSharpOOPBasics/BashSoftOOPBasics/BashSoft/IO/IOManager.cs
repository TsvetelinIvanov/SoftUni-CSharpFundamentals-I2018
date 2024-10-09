using System;
using System.Collections.Generic;
using System.IO;
using BashSoft.Exceptions;
using BashSoft.StaticData;

namespace BashSoft.IO
{
    public class IOManager
    {
        public void TraverseDirectory(int depth)
        {
            OutputWriter.WriteEmptyLine();
            int initialIndentitation = SessionData.currentPath.Split('\\').Length;
            Queue<string> subFolders = new Queue<string>();
            subFolders.Enqueue(SessionData.currentPath);
            while (subFolders.Count != 0)
            {
                string currentPath = subFolders.Dequeue();
                int indentitation = currentPath.Split('\\').Length - initialIndentitation;
                OutputWriter.WriteMessageOnNewLine(string.Format("{0}{1}", new string('-', indentitation), currentPath));
                try
                {
                    foreach (string file in Directory.GetFiles(currentPath))
                    {
                        int indexOfLastSlash = file.LastIndexOf('\\');
                        string fileName = file.Substring(indexOfLastSlash);
                        OutputWriter.WriteMessageOnNewLine(new string('-', indexOfLastSlash) + fileName);
                    }

                    foreach (string drectoryPath in Directory.GetDirectories(currentPath))
                    {
                        subFolders.Enqueue(drectoryPath);
                    }
                }
                catch (UnauthorizedAccessException)
                {
                    OutputWriter.DisplayException(ExceptionMessages.UnauthorizedAccessExceptionMessage);
                }

                if (depth - indentitation < 0)
                {
                    break;
                }
            }
        }

        public void CreateDirectoryInCurrentFolder(string name)
        {
            string path = SessionData.currentPath + "\\" + name;
            try
            {
                Directory.CreateDirectory(path);
            }
            catch (ArgumentException)
            {
                throw new InvalidFileNameException();
                //throw new ArgumentException(ExceptionMessages.ForbiddenSymbolsContainedInName);
            }
        }        

        public void ChangeCurrentDirectoryRelative(string relativePath)
        {
            if (relativePath == "..")
            {
                try
                {
                    string currentPath = SessionData.currentPath;
                    int indexOfLastSlash = currentPath.LastIndexOf('\\');
                    string newPath = currentPath.Substring(0, indexOfLastSlash);
                    SessionData.currentPath = newPath;
                }
                catch (ArgumentOutOfRangeException)
                {
                    throw new InvalidPathException();
                    //throw new ArgumentOutOfRangeException("indexOfLastSlash",  ExceptionMessages.InvalidDestinationExceptionMessage);
                    //OutputWriter.DisplayException(ExceptionMessages.UnableToGoHigherInPartitionHierarchy);
                }
            }
            else
            {
                string currentPath = SessionData.currentPath;
                currentPath += "\\" + relativePath;
                ChangeCurrentDirectoryAbsolute(currentPath);
            }
        }

        public void ChangeCurrentDirectoryAbsolute(string absolutePath)
        {
            if (!Directory.Exists(absolutePath))
            {
                throw new InvalidPathException();
                //throw new DirectoryNotFoundException(ExceptionMessages.InvalidPath);
                //OutputWriter.DisplayExtention(DisplayException.InvalidPath);
                //return;
            }

            SessionData.currentPath = absolutePath; 
        }
    }
}
