using BashSoft.Attributes;
using BashSoft.Exceptions;
using BashSoft.Executor.Contracts;

namespace BashSoft.Executor.Commands
{
    [Alias(InitializingCommand)]
    public class ShowCourseCommand : Command, IExecutable
    {
        private const string InitializingCommand = "show";
        private const int DataLengthForShowDataByCourse = 2;
        private const int DataLengthForShowDataByCourseAndUsername = 3;

        [Inject]
        private IDatabase repository;

        public ShowCourseCommand(string input, string[] data) : base(input, data)
        {

        }

        public override void Execute()
        {
            if (this.Data.Length == DataLengthForShowDataByCourse)
            {
                string courseName = this.Data[1];
                this.repository.GetAllStudentsFromCourse(courseName);
            }
            else if (this.Data.Length == DataLengthForShowDataByCourseAndUsername)
            {
                string courseName = this.Data[1];
                string userName = this.Data[2];
                this.repository.GetStudentsScoresFromCourse(courseName, userName);
            }
            else
            {
                throw new InvalidCommandException(this.Input);
            }
        }
    }

    //Old Version:
    //public class ShowCourseCommand : Command, IExecutable
    //{
    //    private const int DataLengthForShowDataByCourse = 2;
    //    private const int DataLengthForShowDataByCourseAndUsername = 3;

    //    public ShowCourseCommand(string input, string[] data, IContentComparer judge, IDatabase repository,
    //        IDirectoryManager inputOutputManager) : base(input, data, judge, repository, inputOutputManager)
    //    {

    //    }

    //    public override void Execute()
    //    {
    //        if (this.Data.Length == DataLengthForShowDataByCourse)
    //        {
    //            string courseName = this.Data[1];
    //            this.Repository.GetAllStudentsFromCourse(courseName);
    //        }
    //        else if (this.Data.Length == DataLengthForShowDataByCourseAndUsername)
    //        {
    //            string coursName = this.Data[1];
    //            string userName = this.Data[2];
    //            this.Repository.GetStudentsScoresFromCourse(coursName, userName);
    //        }
    //        else
    //        {
    //            throw new InvalidCommandException(this.Input);
    //        }
    //    }
    //}
}
