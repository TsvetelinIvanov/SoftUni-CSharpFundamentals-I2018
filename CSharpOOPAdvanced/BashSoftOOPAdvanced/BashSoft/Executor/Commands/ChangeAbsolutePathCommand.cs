using BashSoft.Attributes;
using BashSoft.Exceptions;
using BashSoft.Executor.Contracts;

namespace BashSoft.Executor.Commands
{
    [Alias(InitializingCommand)]
    public class ChangeAbsolutePathCommand : Command, IExecutable
    {
        private const string InitializingCommand = "cdabs";
        private const int DataLengthForChangeAbsolutePath = 2;

        [Inject]
        private IDirectoryManager inputOutputManager;

        public ChangeAbsolutePathCommand(string input, string[] data) : base(input, data)
        {

        }

        public override void Execute()
        {
            if (this.Data.Length != DataLengthForChangeAbsolutePath)
            {
                throw new InvalidCommandException(this.Input);
            }

            string absolutePath = this.Data[1];
            this.inputOutputManager.ChangeCurrentDirectoryAbsolute(absolutePath);
        }
    }

    //Old Version:
    //public class ChangeAbsolutePathCommand : Command, IExecutable
    //{
    //    private const int DataLengthForChangeAbsolutePath = 2;

    //    public ChangeAbsolutePathCommand(string input, string[] data, IContentComparer judge, IDatabase repository,
    //        IDirectoryManager inputOutputManager) : base(input, data, judge, repository, inputOutputManager)
    //    {

    //    }

    //    public override void Execute()
    //    {
    //        if (this.Data.Length != DataLengthForChangeAbsolutePath)
    //        {
    //            throw new InvalidCommandException(this.Input);
    //        }

    //        string absolutePath = this.Data[1];
    //        this.InputOutputManager.ChangeCurrentDirectoryAbsolute(absolutePath);
    //    }
    //}
}
