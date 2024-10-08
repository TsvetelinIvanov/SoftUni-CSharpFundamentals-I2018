using BashSoft.Exceptions;
using BashSoft.IO;
using BashSoft.Judge;
using BashSoft.Repository;

namespace BashSoft.Executor.Commands
{
    public class PrintOrderedStudentsCommand : Command
    {
        private const int DataLengthForOrderStudents = 5;

        public PrintOrderedStudentsCommand(string input, string[] data, Tester judge, StudentsRepository repository, IOManager inputOutputManager)
            : base(input, data, judge, repository, inputOutputManager)
        {

        }

        public override void Execute()
        {
            if (this.Data.Length != DataLengthForOrderStudents)
            {
                throw new InvalidCommandException(this.Input);
            }

            string courseName = this.Data[1];
            string comparison = this.Data[2].ToLower();
            string takeCommand = this.Data[3].ToLower();
            string takeQuantity = this.Data[4].ToLower();

            this.TryParseParametersForPrintOrderedStudents(takeCommand, takeQuantity, courseName, comparison);
        }

        private void TryParseParametersForPrintOrderedStudents(string takeCommand, string takeQuantity, string courseName, string comparison)
        {
            if (takeCommand == "take")
            {
                if (takeQuantity == "all")
                {
                    this.Repository.FilterAndTake(courseName, comparison);
                }
                else
                {
                    int studentsToTake;
                    bool hasParsed = int.TryParse(takeQuantity, out studentsToTake);
                    if (hasParsed)
                    {
                        this.Repository.OrderAndTake(courseName, comparison, studentsToTake);
                    }
                    else
                    {
                        throw new InvalidTakeQantityParameterException();
                    }
                }
            }
            else
            {
                throw new InvalidTakeQantityParameterException();
            }
        }
    }
}
