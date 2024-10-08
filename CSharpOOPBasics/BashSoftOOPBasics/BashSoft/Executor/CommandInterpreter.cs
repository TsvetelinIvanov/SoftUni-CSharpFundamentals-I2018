using System;
using BashSoft.Exceptions;
using BashSoft.Executor.Commands;
using BashSoft.IO;
using BashSoft.Judge;
using BashSoft.Repository;

namespace BashSoft.Executor
{
    public class CommandInterpreter
    {       
        private Tester judge;
        private StudentsRepository repository;
        private IOManager inputOutputManager;

        public CommandInterpreter(Tester judge, StudentsRepository repository, IOManager inputOutputManager)
        {
            this.judge = judge;
            this.repository = repository;
            this.inputOutputManager = inputOutputManager;
        }

        public void InterpredCommand(string input)
        {
            string[] data = input.Split();
            string commandName = data[0].ToLower();            

            try
            {
                Command command = this.ParseCommand(input, commandName, data);
                command.Execute();
            }
            catch (Exception e)
            {
                OutputWriter.DisplayException(e.Message);
            }            
        }

        private Command ParseCommand(string input, string command, string[] data)
        {
            switch (command)
            {
                case "open":
                    return new OpenFileCommand(input, data, this.judge, this.repository, this.inputOutputManager);
                case "mkdir":
                    return new MakeDirectoryCommand(input, data, this.judge, this.repository, this.inputOutputManager);
                case "ls":
                    return new TraverseFolderCommand(input, data, this.judge, this.repository, this.inputOutputManager);
                case "cmp":
                    return  new CompareFilesCommand(input, data, this.judge, this.repository, this.inputOutputManager);
                case "cdrel":
                    return new ChangeRelativePathCommand(input, data, this.judge, this.repository, this.inputOutputManager);
                case "cdabs":
                    return new ChangeAbsolutePathCommand(input, data, this.judge, this.repository, this.inputOutputManager);
                case "readdb":
                    return new ReadDatabaseCommand(input, data, this.judge, this.repository, this.inputOutputManager);
                case "help":
                    return new GetHelpCommand(input, data, this.judge, this.repository, this.inputOutputManager);
                case "show":
                    return new ShowCourseCommand(input, data, this.judge, this.repository, this.inputOutputManager);
                case "filter":
                    return new PrintFiltredStudentsCommand(input, data, this.judge, this.repository, this.inputOutputManager);
                case "order":
                    return new PrintOrderedStudentsCommand(input, data, this.judge, this.repository, this.inputOutputManager);
                case "dropdb":
                    return new DropDatabaseCommand(input, data, this.judge, this.repository, this.inputOutputManager);
                default:
                    throw new InvalidCommandException(input);                    
            }
        }          
    }

    //Old version:
    //public class CommandInterpreter
    //{
    //    private const int DataLengthForOpenFile = 2;
    //    private const int DataLenghtForCreateDirectory = 2;
    //    private const int DataLengthForTraverseFolders = 1;
    //    private const int DataLengthForTraverseFoldersWithGivenDepth = 2;
    //    private const int DataLengthForCompareFiles = 3;
    //    private const int DataLengthForChangePathRelatively = 2;
    //    private const int DataLengthForChangePathAbsolute = 2;
    //    private const int DataLengthForReadDatabaseFromFile = 2;
    //    private const int DataLengthForGetHelp = 1;
    //    private const int DataLengthForShowWantedDataByCourse = 2;
    //    private const int DataLengthForShowWantedDataByCourseAndUsername = 3;
    //    private const int DataLengthForFilterStudents = 5;
    //    private const int DataLengthForOrderStudents = 5;
    //    //private const int DataLengthForDownloadFile = ;
    //    //private const int DataLengthForDownloadFileAsynchronously = ;

    //    private Tester judge;
    //    private StudentsRepository repository;
    //    private IOManager inputOutputManager;

    //    public CommandInterpreter(Tester judge, StudentsRepository repository, IOManager inputOutputManager)
    //    {
    //        this.judge = judge;
    //        this.repository = repository;
    //        this.inputOutputManager = inputOutputManager;
    //    }

    //    public void InterpredCommand(string input)
    //    {
    //        string[] data = input.Split();
    //        string command = data[0];
    //        command = command.ToLower();

    //        try
    //        {
    //            this.ParseCommand(input, command, data);
    //        }
    //        catch (DirectoryNotFoundException dfne)
    //        {
    //            OutputWriter.DisplayException(dfne.Message);
    //        }
    //        catch (ArgumentOutOfRangeException aoore)
    //        {
    //            OutputWriter.DisplayException(aoore.Message);
    //        }
    //        catch (ArgumentException ae)
    //        {
    //            OutputWriter.DisplayException(ae.Message);
    //        }
    //        catch (Exception e)
    //        {
    //            OutputWriter.DisplayException(e.Message);
    //        }
    //    }

    //    private void ParseCommand(string input, string command, string[] data)
    //    {
    //        switch (command)
    //        {
    //            case "open":
    //                TryOpenFile(input, data);
    //                break;
    //            case "mkdir":
    //                TryCreateDirectory(input, data);
    //                break;
    //            case "ls":
    //                TryTraverseFolders(input, data);
    //                break;
    //            case "cmp":
    //                TryCompareFiles(input, data);
    //                break;
    //            case "cdrel":
    //                TryChangePathRelatively(input, data);
    //                break;
    //            case "cdabs":
    //                TryChangePathAbsolute(input, data);
    //                break;
    //            case "readdb":
    //                TryReadDatabaseFromFile(input, data);
    //                break;
    //            case "help":
    //                TryGetHelp(input, data);
    //                break;
    //            case "show":
    //                TryShowWantedData(input, data);
    //                break;
    //            case "filter":
    //                TryFilterAndTake(input, data);
    //                break;
    //            case "order":
    //                TryOrderAndTake(input, data);
    //                break;
    //            case "dropdb":
    //                TryDropDb(input, data);
    //                break;
    //            //case "decorder":
    //            //    TryOrderStudentsByDecending(input, data);
    //            //    break;
    //            //case "download":
    //            //    TryDownloadFile(input, data);
    //            //    break;
    //            //case "downloadasync":
    //            //    TryDownloadFileAsynchronously(input, data);
    //            //    break;
    //            default:
    //                DisplyInvalidCommandMessage(input);
    //                break;
    //        }
    //    }

    //    private void TryOpenFile(string input, string[] data)
    //    {
    //        if (data.Length == DataLengthForOpenFile)
    //        {
    //            string fileName = data[1];
    //            Process.Start(SessionData.currentPath + "\\" + fileName);
    //        }
    //        else
    //        {
    //            this.DisplyInvalidCommandMessage(input);
    //        }
    //    }

    //    private void TryCreateDirectory(string input, string[] data)
    //    {
    //        if (data.Length == DataLenghtForCreateDirectory)
    //        {
    //            string folderName = data[1];
    //            this.inputOutputManager.CreateDirectoryInCurrentFolder(folderName);
    //        }
    //        else
    //        {
    //            this.DisplyInvalidCommandMessage(input);
    //        }
    //    }

    //    private void TryTraverseFolders(string input, string[] data)
    //    {
    //        if (data.Length == DataLengthForTraverseFolders)
    //        {
    //            int depth = 0;
    //            this.inputOutputManager.TraverseDirectory(depth);
    //        }
    //        else if (data.Length == DataLengthForTraverseFoldersWithGivenDepth)
    //        {
    //            int depth;
    //            bool hasParsed = int.TryParse(data[1], out depth);
    //            if (hasParsed)
    //            {
    //                this.inputOutputManager.TraverseDirectory(depth);
    //            }
    //            else
    //            {
    //                OutputWriter.DisplayException(ExceptionMessages.UnableToParseNumberExceptionMessage);
    //            }
    //        }
    //        else
    //        {
    //            this.DisplyInvalidCommandMessage(input);
    //        }
    //    }

    //    private void TryCompareFiles(string input, string[] data)
    //    {
    //        if (data.Length == DataLengthForCompareFiles)
    //        {
    //            string firstPath = data[1];
    //            string secondPath = data[2];
    //            this.judge.CompareContent(firstPath, secondPath);
    //        }
    //        else
    //        {
    //            this.DisplyInvalidCommandMessage(input);
    //        }
    //    }

    //    private void TryChangePathRelatively(string input, string[] data)
    //    {
    //        if (data.Length == DataLengthForChangePathRelatively)
    //        {
    //            string relativePath = data[1];
    //            this.inputOutputManager.ChangeCurrentDirectoryRelative(relativePath);
    //        }
    //        else
    //        {
    //            this.DisplyInvalidCommandMessage(input);
    //        }
    //    }

    //    private void TryChangePathAbsolute(string input, string[] data)
    //    {
    //        if (data.Length == DataLengthForChangePathAbsolute)
    //        {
    //            string absolutePath = data[1];
    //            this.inputOutputManager.ChangeCurrentDirectoryAbsolute(absolutePath);
    //        }
    //        else
    //        {
    //            this.DisplyInvalidCommandMessage(input);
    //        }
    //    }

    //    private void TryReadDatabaseFromFile(string input, string[] data)
    //    {
    //        if (data.Length == DataLengthForReadDatabaseFromFile)
    //        {
    //            string filename = data[1];
    //            this.repository.LoadData(filename);
    //        }
    //        else
    //        {
    //            this.DisplyInvalidCommandMessage(input);
    //        }
    //    }

    //    private void TryGetHelp(string input, string[] data)
    //    {
    //        if (data.Length == DataLengthForGetHelp)
    //        {
    //            OutputWriter.WriteMessageOnNewLine($"{new string('_', 100)}");
    //            OutputWriter.WriteMessageOnNewLine(string.Format("|{0, -98}|", "make directory - mkdir: path "));
    //            OutputWriter.WriteMessageOnNewLine(string.Format("|{0, -98}|", "traverse directory - ls: depth "));
    //            OutputWriter.WriteMessageOnNewLine(string.Format("|{0, -98}|", "comparing files - cmp: path1 path2"));
    //            OutputWriter.WriteMessageOnNewLine(string.Format("|{0, -98}|", "change directory - changeDirREl:relative path"));
    //            OutputWriter.WriteMessageOnNewLine(string.Format("|{0, -98}|", "change directory - changeDir:absolute path"));
    //            OutputWriter.WriteMessageOnNewLine(string.Format("|{0, -98}|", "read students data base - readDb: path"));
    //            OutputWriter.WriteMessageOnNewLine(string.Format("|{0, -98}|", "filter {courseName} excelent/average/poor  take 2/5/all students - filterExcelent (the output is written on the console)"));
    //            OutputWriter.WriteMessageOnNewLine(string.Format("|{0, -98}|", "order increasing students - order {courseName} ascending/descending take 20/10/all (the output is written on the console)"));
    //            OutputWriter.WriteMessageOnNewLine(string.Format("|{0, -98}|", "download file - download: path of file (saved in current directory)"));
    //            OutputWriter.WriteMessageOnNewLine(string.Format("|{0, -98}|", "download file asinchronously - downloadAsynch: path of file (save in the current directory)"));
    //            OutputWriter.WriteMessageOnNewLine(string.Format("|{0, -98}|", "get help – help"));
    //            OutputWriter.WriteMessageOnNewLine($"{new string('_', 100)}");
    //            OutputWriter.WriteEmptyLine();
    //        }
    //        else
    //        {
    //            this.DisplyInvalidCommandMessage(input);
    //        }
    //    }

    //    private void TryShowWantedData(string input, string[] data)
    //    {
    //        if (data.Length == DataLengthForShowWantedDataByCourse)
    //        {
    //            string courseName = data[1];
    //            this.repository.GetAllStudentsFromCourse(courseName);
    //        }
    //        else if (data.Length == DataLengthForShowWantedDataByCourseAndUsername)
    //        {
    //            string coursName = data[1];
    //            string userName = data[2];
    //            this.repository.GetStudentsScoresFromCourse(coursName, userName);
    //        }
    //        else
    //        {
    //            this.DisplyInvalidCommandMessage(input);
    //        }
    //    }

    //    private void TryFilterAndTake(string input, string[] data)
    //    {
    //        if (data.Length == DataLengthForFilterStudents)
    //        {
    //            string courseName = data[1];
    //            string filter = data[2].ToLower();
    //            string takeCommand = data[3].ToLower();
    //            string takeQuantity = data[4].ToLower();

    //            this.TryParseParametersForFilterAndTake(takeCommand, takeQuantity, courseName, filter);
    //        }
    //        else
    //        {
    //            this.DisplyInvalidCommandMessage(input);
    //        }
    //    }

    //    private void TryParseParametersForFilterAndTake(string takeCommand, string takeQuantity, string courseName, string filter)
    //    {
    //        if (takeCommand == "take")
    //        {
    //            if (takeQuantity == "all")
    //            {
    //                this.repository.FilterAndTake(courseName, filter);
    //            }
    //            else
    //            {
    //                int studentsToTake;
    //                bool hasParsed = int.TryParse(takeQuantity, out studentsToTake);
    //                if (hasParsed)
    //                {
    //                    this.repository.FilterAndTake(courseName, filter, studentsToTake);
    //                }
    //                else
    //                {
    //                    OutputWriter.DisplayException(ExceptionMessages.InvalidTakeQantityParameterExceptionMessage);
    //                }
    //            }
    //        }
    //        else
    //        {
    //            OutputWriter.DisplayException(ExceptionMessages.InvalidTakeQantityParameterExceptionMessage);
    //        }
    //    }

    //    private void TryOrderAndTake(string input, string[] data)
    //    {
    //        if (data.Length == DataLengthForOrderStudents)
    //        {
    //            string courseName = data[1];
    //            string comparison = data[2].ToLower();
    //            string takeCommand = data[3].ToLower();
    //            string takeQuantity = data[4].ToLower();

    //            this.TryParseParametersForOrderAndTake(takeCommand, takeQuantity, courseName, comparison);
    //        }
    //        else
    //        {
    //            this.DisplyInvalidCommandMessage(input);
    //        }
    //    }

    //    private void TryParseParametersForOrderAndTake(string takeCommand, string takeQuantity, string courseName, string comparison)
    //    {
    //        if (takeCommand == "take")
    //        {
    //            if (takeQuantity == "all")
    //            {
    //                this.repository.FilterAndTake(courseName, comparison);
    //            }
    //            else
    //            {
    //                int studentsToTake;
    //                bool hasParsed = int.TryParse(takeQuantity, out studentsToTake);
    //                if (hasParsed)
    //                {
    //                    this.repository.OrderAndTake(courseName, comparison, studentsToTake);
    //                }
    //                else
    //                {
    //                    OutputWriter.DisplayException(ExceptionMessages.InvalidTakeQantityParameterExceptionMessage);
    //                }
    //            }
    //        }
    //        else
    //        {
    //            OutputWriter.DisplayException(ExceptionMessages.InvalidTakeQantityParameterExceptionMessage);
    //        }
    //    }

    //    private void TryDropDb(string input, string[] data)
    //    {
    //        if (data.Length != 1)
    //        {
    //            this.DisplyInvalidCommandMessage(input);
    
    //            return;
    //        }

    //        this.repository.UnloadData();
    //        OutputWriter.WriteMessageOnNewLine("Database dropped!");
    //    }
    
    //    private void DisplyInvalidCommandMessage(string input)
    //    {
    //        OutputWriter.WriteMessageOnNewLine($"The command {input} is invalid");
    //    }
    //}
}
