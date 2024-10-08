using BashSoft.Exceptions;
using BashSoft.IO;
using BashSoft.Judge;
using BashSoft.Repository;

namespace BashSoft.Executor.Commands
{
    public class CompareFilesCommand : Command
    {
        private const int DataLengthForCompareFiles = 3;

        public CompareFilesCommand(string input, string[] data, Tester judge, StudentsRepository repository, IOManager inputOutputManager)
            : base(input, data, judge, repository, inputOutputManager)
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
            this.Judge.CompareContent(firstPath, secondPath);
        }
    }
}
