using BashSoft.Attributes;
using BashSoft.Exceptions;
using BashSoft.Executor.Contracts;

namespace BashSoft.Executor.Commands
{
    [Alias(InitializingCommand)]
    public class MakeDirectoryCommand : Command, IExecutable
    {
        private const string InitializingCommand = "mkdir";
        private const int DataLenghtForCreateDirectory = 2;

        [Inject]
        private IDirectoryManager inputOutputManager;

        public MakeDirectoryCommand(string input, string[] data) : base(input, data)
        {

        }

        public override void Execute()
        {
            if (this.Data.Length != DataLenghtForCreateDirectory)
            {
                throw new InvalidCommandException(this.Input);
            }

            string folderName = this.Data[1];
            this.inputOutputManager.CreateDirectoryInCurrentFolder(folderName);
        }
    }

    //Old Version:
    //public class MakeDirectoryCommand : Command, IExecutable
    //{
    //    private const int DataLenghtForCreateDirectory = 2;

    //    public MakeDirectoryCommand(string input, string[] data, IContentComparer judge, IDatabase repository,
    //        IDirectoryManager inputOutputManager) : base(input, data, judge, repository, inputOutputManager)
    //    {

    //    }

    //    public override void Execute()
    //    {
    //        if (this.Data.Length != DataLenghtForCreateDirectory)
    //        {
    //            throw new InvalidCommandException(this.Input);
    //        }

    //        string folderName = this.Data[1];
    //        this.InputOutputManager.CreateDirectoryInCurrentFolder(folderName);
    //    }
    //}
}
