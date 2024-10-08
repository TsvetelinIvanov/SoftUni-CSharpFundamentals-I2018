using BashSoft.Exceptions;
using BashSoft.IO;
using BashSoft.Judge;
using BashSoft.Repository;

namespace BashSoft.Executor.Commands
{
    public class ChangeAbsolutePathCommand : Command
    {
        private const int DataLengthForChangeAbsolutePath = 2;

        public ChangeAbsolutePathCommand(string input, string[] data, Tester judge, StudentsRepository repository, IOManager inputOutputManager) 
            : base(input, data, judge, repository, inputOutputManager)
        {

        }

        public override void Execute()
        {
            if (this.Data.Length != DataLengthForChangeAbsolutePath)
            {
                throw new InvalidCommandException(this.Input);
            }

            string absolutePath = this.Data[1];
            this.InputOutputManager.ChangeCurrentDirectoryAbsolute(absolutePath);
        }
    }
}
