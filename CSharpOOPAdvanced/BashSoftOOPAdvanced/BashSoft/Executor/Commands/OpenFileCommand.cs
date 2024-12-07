using System.Diagnostics;
using BashSoft.Attributes;
using BashSoft.Exceptions;
using BashSoft.Executor.Contracts;

namespace BashSoft.IO.Commands
{
    [Alias(InitializingCommand)]
    public class OpenFileCommand : Command, IExecutable
    {
        private const string InitializingCommand = "open";
        private const int DataLengthForOpenFile = 2;

        public OpenFileCommand(string input, string[] data) : base(input, data)
        {

        }

        public override void Execute()
        {
            if (this.Data.Length != DataLengthForOpenFile)
            {
                throw new InvalidCommandException(this.Input);
            }

            string fileName = this.Data[1];
            Process.Start(SessionData.currentPath + "\\" + fileName);           
        }
    }

    //Old Version:
    //public class OpenFileCommand : Command, IExecutable
    //{
    //    private const int DataLengthForOpenFile = 2;

    //    public OpenFileCommand(string input, string[] data, IContentComparer judge, IDatabase repository,
    //        IDirectoryManager inputOutputManager) : base(input, data, judge, repository, inputOutputManager)
    //    {

    //    }

    //    public override void Execute()
    //    {
    //        if (this.Data.Length != DataLengthForOpenFile)
    //        {
    //            throw new InvalidCommandException(this.Input);
    //        }

    //        string fileName = this.Data[1];
    //        Process.Start(SessionData.currentPath + "\\" + fileName);
    //    }
    //}
}
