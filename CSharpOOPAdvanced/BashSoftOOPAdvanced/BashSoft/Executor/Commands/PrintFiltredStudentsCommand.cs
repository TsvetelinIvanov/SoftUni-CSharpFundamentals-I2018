using BashSoft.Attributes;
using BashSoft.Exceptions;
using BashSoft.Executor.Contracts;

namespace BashSoft.IO.Commands
{
    [Alias(InitializingCommand)]
    public class PrintFiltredStudentsCommand : Command, IExecutable
    {
        private const string InitializingCommand = "filter";
        private const int DataLengthForPrintFiltredStudents = 5;

        [Inject]
        private IDatabase repository;

        public PrintFiltredStudentsCommand(string input, string[] data) : base(input, data)
        {

        }

        public override void Execute()
        {
            if (this.Data.Length != DataLengthForPrintFiltredStudents)
            {
                throw new InvalidCommandException(this.Input);
            }

            string courseName = this.Data[1];
            string filter = this.Data[2].ToLower();
            string takeCommand = this.Data[3].ToLower();
            string takeQuantity = this.Data[4].ToLower();

            this.TryParseParametersForPrintFiltredStudents(takeCommand, takeQuantity, courseName, filter);
        }

        private void TryParseParametersForPrintFiltredStudents(string takeCommand, string takeQuantity, string courseName, string filter)
        {
            if (takeCommand == "take")
            {
                if (takeQuantity == "all")
                {
                    this.repository.FilterAndTake(courseName, filter);
                }
                else
                {
                    int studentsToTake;
                    bool hasParsed = int.TryParse(takeQuantity, out studentsToTake);
                    if (hasParsed)
                    {
                        this.repository.FilterAndTake(courseName, filter, studentsToTake);
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

    //Old Version:
    //public class PrintFiltredStudentsCommand : Command, IExecutable
    //{
    //    private const int DataLengthForPrintFiltredStudents = 5;

    //    public PrintFiltredStudentsCommand(string input, string[] data, IContentComparer judge, IDatabase repository,
    //        IDirectoryManager inputOutputManager) : base(input, data, judge, repository, inputOutputManager)
    //    {

    //    }

    //    public override void Execute()
    //    {
    //        if (this.Data.Length != DataLengthForPrintFiltredStudents)
    //        {
    //            throw new InvalidCommandException(this.Input);
    //        }

    //        string courseName = this.Data[1];
    //        string filter = this.Data[2].ToLower();
    //        string takeCommand = this.Data[3].ToLower();
    //        string takeQuantity = this.Data[4].ToLower();

    //        this.TryParseParametersForPrintFiltredStudents(takeCommand, takeQuantity, courseName, filter);
    //    }

    //    private void TryParseParametersForPrintFiltredStudents(string takeCommand, string takeQuantity,
    //        string courseName, string filter)
    //    {
    //        if (takeCommand == "take")
    //        {
    //            if (takeQuantity == "all")
    //            {
    //                this.Repository.FilterAndTake(courseName, filter);
    //            }
    //            else
    //            {
    //                int studentsToTake;
    //                bool hasParsed = int.TryParse(takeQuantity, out studentsToTake);
    //                if (hasParsed)
    //                {
    //                    this.Repository.FilterAndTake(courseName, filter, studentsToTake);
    //                }
    //                else
    //                {
    //                    throw new InvalidTakeQantityParameterException();
    //                }
    //            }
    //        }
    //        else
    //        {
    //            throw new InvalidTakeQantityParameterException();
    //        }
    //    }
    //}
}