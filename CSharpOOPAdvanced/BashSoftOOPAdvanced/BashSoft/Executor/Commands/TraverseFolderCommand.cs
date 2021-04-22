using BashSoft.Attributes;
using BashSoft.Exceptions;
using BashSoft.Executor.Contracts;

namespace BashSoft.IO.Commands
{
    [Alias(InitializingCommand)]
    public class TraverseFolderCommand : Command, IExecutable
    {
        private const string InitializingCommand = "ls";
        private const int DataLengthForTraverseFolders = 1;
        private const int DataLengthForTraverseFoldersWithGivenDepth = 2;

        [Inject]
        private IDirectoryManager inputOutputManager;

        public TraverseFolderCommand(string input, string[] data) : base(input, data)
        {

        }

        public override void Execute()
        {
            if (this.Data.Length == DataLengthForTraverseFolders)
            {
                int depth = 0;
                this.inputOutputManager.TraverseDirectory(depth);
            }
            else if (this.Data.Length == DataLengthForTraverseFoldersWithGivenDepth)
            {
                int depth;
                bool hasParsed = int.TryParse(this.Data[1], out depth);
                if (hasParsed)
                {
                    this.inputOutputManager.TraverseDirectory(depth);
                }
                else
                {
                    throw new UnableToParseNumberException();
                }
            }
            else
            {
                throw new InvalidCommandException(this.Input);
            }
        }
    }
    
    //Old Version:
    //public class TraverseFolderCommand : Command, IExecutable
    //{
    //    private const int DataLengthForTraverseFolders = 1;
    //    private const int DataLengthForTraverseFoldersWithGivenDepth = 2;

    //    public TraverseFolderCommand(string input, string[] data, IContentComparer judge, IDatabase repository,
    //        IDirectoryManager inputOutputManager) : base(input, data, judge, repository, inputOutputManager)
    //    {

    //    }

    //    public override void Execute()
    //    {
    //        if (this.Data.Length == DataLengthForTraverseFolders)
    //        {
    //            int depth = 0;
    //            this.InputOutputManager.TraverseDirectory(depth);
    //        }
    //        else if (this.Data.Length == DataLengthForTraverseFoldersWithGivenDepth)
    //        {
    //            int depth;
    //            bool hasParsed = int.TryParse(this.Data[1], out depth);
    //            if (hasParsed)
    //            {
    //                this.InputOutputManager.TraverseDirectory(depth);
    //            }
    //            else
    //            {
    //                throw new UnableToParseNumberException();
    //            }
    //        }
    //        else
    //        {
    //            throw new InvalidCommandException(this.Input);
    //        }
    //    }
    //}
}