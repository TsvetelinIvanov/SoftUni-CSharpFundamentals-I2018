using BashSoft.Attributes;
using BashSoft.Exceptions;
using BashSoft.Executor.Contracts;

namespace BashSoft.IO.Commands
{
    [Alias(InitializingCommand)]
    public class GetHelpCommand : Command, IExecutable
    {
        private const string InitializingCommand = "help";
        private const int DataLengthForGetHelp = 1;

        public GetHelpCommand(string input, string[] data) : base(input, data)
        {

        }

        public override void Execute()
        {
            if (this.Data.Length != DataLengthForGetHelp)
            {
                throw new InvalidCommandException(this.Input);
            }

            this.DisplayHelp();
        }

        private void DisplayHelp()
        {
            OutputWriter.WriteMessageOnNewLine($"{new string('_', 100)}");
            OutputWriter.WriteMessageOnNewLine(string.Format("|{0, -98}|", "make directory - mkdir: path "));
            OutputWriter.WriteMessageOnNewLine(string.Format("|{0, -98}|", "traverse directory - ls: depth "));
            OutputWriter.WriteMessageOnNewLine(string.Format("|{0, -98}|", "comparing files - cmp: path1 path2"));
            OutputWriter.WriteMessageOnNewLine(string.Format("|{0, -98}|", "change directory - changeDirREl: relative path"));
            OutputWriter.WriteMessageOnNewLine(string.Format("|{0, -98}|", "change directory - changeDir: absolute path"));
            OutputWriter.WriteMessageOnNewLine(string.Format("|{0, -98}|", "read students data base - readDb: path"));
            OutputWriter.WriteMessageOnNewLine(string.Format("|{0, -98}|", "filter {courseName} excelent/average/poor  take 2/5/all students - filterExcelent (the output is written on the console)"));
            OutputWriter.WriteMessageOnNewLine(string.Format("|{0, -98}|", "order increasing students - order {courseName} ascending/descending take 10/20/all (the output is written on the console)"));
            OutputWriter.WriteMessageOnNewLine(string.Format("|{0, -98}|", "download file - download: path of file (saved in current directory)"));
            OutputWriter.WriteMessageOnNewLine(string.Format("|{0, -98}|", "download file asinchronously - downloadAsynch: path of file (save in the current directory)"));
            OutputWriter.WriteMessageOnNewLine(string.Format("|{0, -98}|", "display data entities - display students/courses ascending/descending"));
            OutputWriter.WriteMessageOnNewLine(string.Format("|{0, -98}|", "get help – help"));
            OutputWriter.WriteMessageOnNewLine($"{new string('_', 100)}");
            OutputWriter.WriteEmptyLine();
        }
    }

    //Old Version:
    //public class GetHelpCommand : Command, IExecutable
    //{
    //    private const int DataLengthForGetHelp = 1;

    //    public GetHelpCommand(string input, string[] data, IContentComparer judge, IDatabase repository,
    //        IDirectoryManager inputOutputManager) : base(input, data, judge, repository, inputOutputManager)
    //    {

    //    }

    //    public override void Execute()
    //    {
    //        if (this.Data.Length != DataLengthForGetHelp)
    //        {
    //            throw new InvalidCommandException(this.Input);
    //        }

    //        this.DisplayHelp();
    //    }

    //    private void DisplayHelp()
    //    {
    //        OutputWriter.WriteMessageOnNewLine($"{new string('_', 100)}");
    //        OutputWriter.WriteMessageOnNewLine(string.Format("|{0, -98}|", "make directory - mkdir: path "));
    //        OutputWriter.WriteMessageOnNewLine(string.Format("|{0, -98}|", "traverse directory - ls: depth "));
    //        OutputWriter.WriteMessageOnNewLine(string.Format("|{0, -98}|", "comparing files - cmp: path1 path2"));
    //        OutputWriter.WriteMessageOnNewLine(string.Format("|{0, -98}|", "change directory - changeDirREl: relative path"));
    //        OutputWriter.WriteMessageOnNewLine(string.Format("|{0, -98}|", "change directory - changeDir: absolute path"));
    //        OutputWriter.WriteMessageOnNewLine(string.Format("|{0, -98}|", "read students data base - readDb: path"));
    //        OutputWriter.WriteMessageOnNewLine(string.Format("|{0, -98}|", "filter {courseName} excelent/average/poor  take 2/5/all students - filterExcelent (the output is written on the console)"));
    //        OutputWriter.WriteMessageOnNewLine(string.Format("|{0, -98}|", "order increasing students - order {courseName} ascending/descending take 10/20/all (the output is written on the console)"));
    //        OutputWriter.WriteMessageOnNewLine(string.Format("|{0, -98}|", "download file - download: path of file (saved in current directory)"));
    //        OutputWriter.WriteMessageOnNewLine(string.Format("|{0, -98}|", "download file asinchronously - downloadAsynch: path of file (save in the current directory)"));
    //        OutputWriter.WriteMessageOnNewLine(string.Format("|{0, -98}|", "display data entities - display students/courses ascending/descending"));
    //        OutputWriter.WriteMessageOnNewLine(string.Format("|{0, -98}|", "get help – help"));
    //        OutputWriter.WriteMessageOnNewLine($"{new string('_', 100)}");
    //        OutputWriter.WriteEmptyLine();
    //    }
    //}
}
