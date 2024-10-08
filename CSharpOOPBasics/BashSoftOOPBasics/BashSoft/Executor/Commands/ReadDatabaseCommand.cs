using BashSoft.Exceptions;
using BashSoft.IO;
using BashSoft.Judge;
using BashSoft.Repository;

namespace BashSoft.Executor.Commands
{
    public class ReadDatabaseCommand : Command
    {
        private const int DataLengthForReadDatabase = 2;

        public ReadDatabaseCommand(string input, string[] data, Tester judge, StudentsRepository repository, IOManager inputOutputManager)
            : base(input, data, judge, repository, inputOutputManager)
        {

        }

        public override void Execute()
        {
            if (this.Data.Length != DataLengthForReadDatabase)
            {
                throw new InvalidCommandException(this.Input);
            }

            string filename = this.Data[1];
            this.Repository.LoadData(filename);
        }
    }
}
