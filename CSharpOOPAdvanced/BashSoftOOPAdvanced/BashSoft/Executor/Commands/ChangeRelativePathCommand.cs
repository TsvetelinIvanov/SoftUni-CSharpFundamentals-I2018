using BashSoft.Attributes;
using BashSoft.Exceptions;
using BashSoft.Executor.Contracts;

namespace BashSoft.Executor.Commands
{
    [Alias(InitializingCommand)]
    public class ChangeRelativePathCommand : Command, IExecutable
    {
        private const string InitializingCommand = "cdrel";
        private const int DataLengthForChangeRelativePath = 2;

        [Inject]
        private IDirectoryManager inputOutputManager;

        public ChangeRelativePathCommand(string input, string[] data) : base(input, data)
        {

        }

        public override void Execute()
        {
            if (this.Data.Length != DataLengthForChangeRelativePath)
            {
                throw new InvalidCommandException(this.Input);
            }

            string relativePath = this.Data[1];
            this.inputOutputManager.ChangeCurrentDirectoryRelative(relativePath);
        }
    }
    
    //Old Version:
    //public class ChangeRelativePathCommand : Command, IExecutable
    //{
    //    private const int DataLengthForChangeRelativePath = 2;

    //    public ChangeRelativePathCommand(string input, string[] data, IContentComparer judge, IDatabase repository,
    //        IDirectoryManager inputOutputManager) : base(input, data, judge, repository, inputOutputManager)
    //    {

    //    }

    //    public override void Execute()
    //    {
    //        if (this.Data.Length != DataLengthForChangeRelativePath)
    //        {
    //            throw new InvalidCommandException(this.Input);
    //        }

    //        string relativePath = this.Data[1];
    //        this.InputOutputManager.ChangeCurrentDirectoryRelative(relativePath);
    //    }
    //}
}
