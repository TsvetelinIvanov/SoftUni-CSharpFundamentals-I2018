using BashSoft.Attributes;
using BashSoft.Exceptions;
using BashSoft.Executor.Contracts;

namespace BashSoft.IO.Commands
{
    [Alias(InitializingCommand)]
    public class ReadDatabaseCommand : Command, IExecutable
    {
        private const string InitializingCommand = "readdb";
        private const int DataLengthForReadDatabase = 2;

        [Inject]
        private IDatabase repository;

        public ReadDatabaseCommand(string input, string[] data) : base(input, data)
        {

        }

        public override void Execute()
        {
            if (this.Data.Length != DataLengthForReadDatabase)
            {
                throw new InvalidCommandException(this.Input);
            }

            string filename = this.Data[1];
            this.repository.LoadData(filename);
        }
    }

    //Old Version:
    //public class ReadDatabaseCommand : Command, IExecutable
    //{
    //    private const int DataLengthForReadDatabase = 2;

    //    public ReadDatabaseCommand(string input, string[] data, IContentComparer judge, IDatabase repository,
    //        IDirectoryManager inputOutputManager) : base(input, data, judge, repository, inputOutputManager)
    //    {

    //    }

    //    public override void Execute()
    //    {
    //        if (this.Data.Length != DataLengthForReadDatabase)
    //        {
    //            throw new InvalidCommandException(this.Input);
    //        }

    //        string filename = this.Data[1];
    //        this.Repository.LoadData(filename);
    //    }
    //}
}