using BashSoft.Exceptions;
using BashSoft.IO;
using BashSoft.Judge;
using BashSoft.Repository;

namespace BashSoft.Executor.Commands
{
    public class TraverseFolderCommand : Command
    {
        private const int DataLengthForTraverseFolders = 1;
        private const int DataLengthForTraverseFoldersWithGivenDepth = 2;

        public TraverseFolderCommand(string input, string[] data, Tester judge, StudentsRepository repository, IOManager inputOutputManager) : base(input, data, judge, repository, inputOutputManager)
        {

        }

        public override void Execute()
        {
            if (this.Data.Length == DataLengthForTraverseFolders)
            {
                int depth = 0;
                this.InputOutputManager.TraverseDirectory(depth);
            }
            else if (this.Data.Length == DataLengthForTraverseFoldersWithGivenDepth)
            {
                bool hasParsed = int.TryParse(this.Data[1], out int depth);
                if (hasParsed)
                {
                    this.InputOutputManager.TraverseDirectory(depth);
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
}