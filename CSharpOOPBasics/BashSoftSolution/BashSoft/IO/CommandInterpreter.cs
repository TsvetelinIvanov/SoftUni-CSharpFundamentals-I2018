﻿using System.Diagnostics;
﻿using BashSoft.Judge;
﻿using BashSoft.Repository;
﻿using BashSoft.StaticData;

namespace BashSoft.IO
{
    public static class CommandInterpreter
    {
        private const int DataLengthForOpenFile = 2;
        private const int DataLenghtForCreateDirectory = 2;
        private const int DataLengthForTraverseFolders = 1;
        private const int DataLengthForTraverseFoldersWithGivenDepth = 2;
        private const int DataLengthForCompareFiles = 3;
        private const int DataLengthForChangePathRelatively = 2;
        private const int DataLengthForChangePathAbsolute = 2;
        private const int DataLengthForReadDatabaseFromFile = 2;
        private const int DataLengthForGetHelp = 1;
        private const int DataLengthForShowWantedDataByCourse = 2;
        private const int DataLengthForShowWantedDataByCourseAndUsername = 3;
        private const int DataLengthForFilterStudents = 5;
        private const int DataLengthForOrderStudents = 5;
        //private const int DataLengthForOrderStudentsByDecending = ;
        //private const int DataLengthForDownloadFile = ;
        //private const int DataLengthForDownloadFileAsynchronously = ;

        public static void InterpredCommand(string input)
        {
            string[] data = input.Split();
            string command = data[0];
            switch (command)
            {
                case "open":
                    TryOpenFile(input, data);
                    break;
                case "mkdir":
                    TryCreateDirectory(input, data);
                    break;
                case "ls":
                    TryTraverseFolders(input, data);
                    break;
                case "cmp":
                    TryCompareFiles(input, data);
                    break;
                case "cdRel":
                    TryChangePathRelatively(input, data);
                    break;
                case "cdAbs":
                    TryChangePathAbsolute(input, data);
                    break;
                case "readDb":
                    TryReadDatabaseFromFile(input, data);
                    break;
                case "help":
                    TryGetHelp(input, data);
                    break;
                case "show":
                    TryShowWantedData(input, data);
                    break;
                case "filter":
                    TryFilterAndTake(input, data);
                    break;
                case "order":
                    TryOrderAndTake(input, data);
                    break;
                //case "decOrder":
                //    TryOrderStudentsByDecending(input, data);
                //    break;
                //case "download":
                //    TryDownloadFile(input, data);
                //    break;
                //case "downloadAsync":
                //    TryDownloadFileAsynchronously(input, data);
                //    break;
                default:
                    DisplyInvalidCommandMessage(input);
                    break;
            }
        }

        private static void TryOpenFile(string input, string[] data)
        {
            if (data.Length == DataLengthForOpenFile)
            {
                string fileName = data[1];
                Process.Start(SessionData.currentPath + "\\" + fileName);
            }
            else
            {
                DisplyInvalidCommandMessage(input);
            }
        }

        private static void TryCreateDirectory(string input, string[] data)
        {
            if (data.Length == DataLenghtForCreateDirectory)
            {
                string folderName = data[1];
                IOManager.CreateDirectoryInCurrentFolder(folderName);
            }
            else
            {
                DisplyInvalidCommandMessage(input);
            }
        }

        private static void TryTraverseFolders(string input, string[] data)
        {
            if (data.Length == DataLengthForTraverseFolders)
            {
                int depth = 0;
                IOManager.TraverseDirectory(depth);
            }
            else if (data.Length == DataLengthForTraverseFoldersWithGivenDepth)
            {
                int depth;
                bool hasParsed = int.TryParse(data[1], out depth);
                if (hasParsed)
                {
                    IOManager.TraverseDirectory(depth);
                }
                else
                {
                    OutputWriter.DisplayException(ExceptionMessages.UnableToParseNumberExceptionMessage);
                }
            }
            else
            {
                DisplyInvalidCommandMessage(input);
            }
        }

        private static void TryCompareFiles(string input, string[] data)
        {
            if (data.Length == DataLengthForCompareFiles)
            {
                string firstPath = data[1];
                string secondPath = data[2];
                Tester.CompareContent(firstPath, secondPath);
            }
            else
            {
                DisplyInvalidCommandMessage(input);
            }
        }

        private static void TryChangePathRelatively(string input, string[] data)
        {
            if (data.Length == DataLengthForChangePathRelatively)
            {
                string relativePath = data[1];
                IOManager.ChangeCurrentDirectoryRelative(relativePath);
            }
            else
            {
                DisplyInvalidCommandMessage(input);
            }
        }

        private static void TryChangePathAbsolute(string input, string[] data)
        {
            if (data.Length == DataLengthForChangePathAbsolute)
            {
                string absolutePath = data[1];
                IOManager.ChangeCurrentDirectoryAbsolute(absolutePath);
            }
            else
            {
                DisplyInvalidCommandMessage(input);
            }
        }

        private static void TryReadDatabaseFromFile(string input, string[] data)
        {
            if (data.Length == DataLengthForReadDatabaseFromFile)
            {
                string filename = data[1];
                StudentsRepository.InitializeData(filename);
            }
            else
            {
                DisplyInvalidCommandMessage(input);
            }
        }

        private static void TryGetHelp(string input, string[] data)
        {
            if (data.Length == DataLengthForGetHelp)
            {
                OutputWriter.WriteMessageOnNewLine($"{new string('_', 100)}");
                OutputWriter.WriteMessageOnNewLine(string.Format("|{0, -98}|", "make directory - mkdir: path "));
                OutputWriter.WriteMessageOnNewLine(string.Format("|{0, -98}|", "traverse directory - ls: depth "));
                OutputWriter.WriteMessageOnNewLine(string.Format("|{0, -98}|", "comparing files - cmp: path1 path2"));
                OutputWriter.WriteMessageOnNewLine(string.Format("|{0, -98}|", "change directory - changeDirREl:relative path"));
                OutputWriter.WriteMessageOnNewLine(string.Format("|{0, -98}|", "change directory - changeDir:absolute path"));
                OutputWriter.WriteMessageOnNewLine(string.Format("|{0, -98}|", "read students data base - readDb: path"));
                OutputWriter.WriteMessageOnNewLine(string.Format("|{0, -98}|", "filter {courseName} excelent/average/poor  take 2/5/all students - filterExcelent (the output is written on the console)"));
                OutputWriter.WriteMessageOnNewLine(string.Format("|{0, -98}|", "order increasing students - order {courseName} ascending/descending take 20/10/all (the output is written on the console)"));
                OutputWriter.WriteMessageOnNewLine(string.Format("|{0, -98}|", "download file - download: path of file (saved in current directory)"));
                OutputWriter.WriteMessageOnNewLine(string.Format("|{0, -98}|", "download file asinchronously - downloadAsynch: path of file (save in the current directory)"));
                OutputWriter.WriteMessageOnNewLine(string.Format("|{0, -98}|", "get help – help"));
                OutputWriter.WriteMessageOnNewLine($"{new string('_', 100)}");
                OutputWriter.WriteEmptyLine();
            }
            else
            {
                DisplyInvalidCommandMessage(input);
            }
        }

        private static void TryShowWantedData(string input, string[] data)
        {
            if (data.Length == DataLengthForShowWantedDataByCourse)
            {
                string courseName = data[1];
                StudentsRepository.GetAllStudentsFromCourse(courseName);
            }
            else if (data.Length == DataLengthForShowWantedDataByCourseAndUsername)
            {
                string coursName = data[1];
                string userName = data[2];
                StudentsRepository.GetStudentsScoresFromCourse(coursName, userName);
            }
            else
            {
                DisplyInvalidCommandMessage(input);
            }
        }

        private static void TryFilterAndTake(string input, string[] data)
        {
            if (data.Length == DataLengthForFilterStudents)
            {
                string courseName = data[1];
                string filter = data[2].ToLower();
                string takeCommand = data[3].ToLower();
                string takeQuantity = data[4].ToLower();

                TryParseParametersForFilterAndTake(takeCommand, takeQuantity, courseName, filter);
            }
            else
            {
                DisplyInvalidCommandMessage(input);
            }
        }

        private static void TryParseParametersForFilterAndTake(string takeCommand, string takeQuantity, string courseName, string filter)
        {
            if (takeCommand == "take")
            {
                if (takeQuantity == "all")
                {
                    StudentsRepository.FilterAndTake(courseName, filter);
                }
                else
                {
                    int studentsToTake;
                    bool hasParsed = int.TryParse(takeQuantity, out studentsToTake);
                    if (hasParsed)
                    {
                        StudentsRepository.FilterAndTake(courseName, filter, studentsToTake);
                    }
                    else
                    {
                        OutputWriter.DisplayException(ExceptionMessages.InvalidTakeQantityParameterExceptionMessage);
                    }
                }
            }
            else
            {
                OutputWriter.DisplayException(ExceptionMessages.InvalidTakeQantityParameterExceptionMessage);
            }
        }        

        private static void TryOrderAndTake(string input, string[] data)
        {
            if (data.Length == DataLengthForOrderStudents)
            {
                string courseName = data[1];
                string comparison = data[2].ToLower();
                string takeCommand = data[3].ToLower();
                string takeQuantity = data[4].ToLower();

                TryParseParametersForOrderAndTake(takeCommand, takeQuantity, courseName, comparison);
            }
            else
            {
                DisplyInvalidCommandMessage(input);
            }
        }

        private static void TryParseParametersForOrderAndTake(string takeCommand, string takeQuantity, string courseName, string comparison)
        {
            if (takeCommand == "take")
            {
                if (takeQuantity == "all")
                {
                    StudentsRepository.FilterAndTake(courseName, comparison);
                }
                else
                {
                    int studentsToTake;
                    bool hasParsed = int.TryParse(takeQuantity, out studentsToTake);
                    if (hasParsed)
                    {
                        StudentsRepository.OrderAndTake(courseName, comparison, studentsToTake);
                    }
                    else
                    {
                        OutputWriter.DisplayException(ExceptionMessages.InvalidTakeQantityParameterExceptionMessage);
                    }
                }
            }
            else
            {
                OutputWriter.DisplayException(ExceptionMessages.InvalidTakeQantityParameterExceptionMessage);
            }
        }

        private static void DisplyInvalidCommandMessage(string input)
        {
            OutputWriter.WriteMessageOnNewLine($"The command {input} is invalid");
        }
    }
}
