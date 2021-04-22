using BashSoft.Attributes;
using BashSoft.Exceptions;
using BashSoft.Executor.Contracts;

namespace BashSoft.IO.Commands
{
    [Alias(InitializingCommand)]
    public class CompareFilesCommand : Command, IExecutable
    {
        private const string InitializingCommand = "cmp";
        private const int DataLengthForCompareFiles = 3;

        [Inject]
        private IContentComparer judge;

        public CompareFilesCommand(string input, string[] data) : base(input, data)
        {

        }

        public override void Execute()
        {
            if (this.Data.Length != DataLengthForCompareFiles)
            {
                throw new InvalidCommandException(this.Input);
            }

            string firstPath = this.Data[1];
            string secondPath = this.Data[2];
            this.judge.CompareContent(firstPath, secondPath);
        }
    }

    //    Old Version:
    //    public class CompareFilesCommand : Command, IExecutable
    //{
    //    private const int DataLengthForCompareFiles = 3;

    //    public CompareFilesCommand(string input, string[] data, IContentComparer judge, IDatabase repository,
    //        IDirectoryManager inputOutputManager) : base(input, data, judge, repository, inputOutputManager)
    //    {

    //    }

    //    public override void Execute()
    //    {
    //        if (this.Data.Length != DataLengthForCompareFiles)
    //        {
    //            throw new InvalidCommandException(this.Input);
    //        }

    //        string firstPath = this.Data[1];
    //        string secondPath = this.Data[2];
    //        this.Judge.CompareContent(firstPath, secondPath);
    //    }
    //}
}