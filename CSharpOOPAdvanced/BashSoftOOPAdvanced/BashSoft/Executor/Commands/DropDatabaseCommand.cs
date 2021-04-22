using BashSoft.Attributes;
using BashSoft.Exceptions;
using BashSoft.Executor.Contracts;

namespace BashSoft.IO.Commands
{
    [Alias(InitializingCommand)]
    public class DropDatabaseCommand : Command, IExecutable
    {
        private const string InitializingCommand = "dropdb";
        private const int DataLengthForDropDatabase = 1;

        [Inject]
        private IDatabase repository;

        public DropDatabaseCommand(string input, string[] data) : base(input, data)
        {

        }

        public override void Execute()
        {
            if (this.Data.Length != DataLengthForDropDatabase)
            {
                throw new InvalidCommandException(this.Input);
            }

            this.repository.UnloadData();
            OutputWriter.WriteMessageOnNewLine("Database dropped!");
        }
    }

    //Old Version:
    //public class DropDatabaseCommand : Command, IExecutable
    //{
    //    private const int DataLengthForDropDatabase = 1;

    //    public DropDatabaseCommand(string input, string[] data, IContentComparer judge, IDatabase repository,
    //        IDirectoryManager inputOutputManager) : base(input, data, judge, repository, inputOutputManager)
    //    {

    //    }

    //    public override void Execute()
    //    {
    //        if (this.Data.Length != DataLengthForDropDatabase)
    //        {
    //            throw new InvalidCommandException(this.Input);
    //        }

    //        this.Repository.UnloadData();
    //        OutputWriter.WriteMessageOnNewLine("Database dropped!");
    //    }
    //}
}