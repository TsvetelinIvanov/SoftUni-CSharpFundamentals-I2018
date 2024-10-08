using BashSoft.Exceptions;
using BashSoft.IO;
using BashSoft.Judge;
using BashSoft.Repository;

namespace BashSoft.Executor.Commands
{
    public class ShowCourseCommand : Command
    {
        private const int DataLengthForShowDataByCourse = 2;
        private const int DataLengthForShowDataByCourseAndUsername = 3;

        public ShowCourseCommand(string input, string[] data, Tester judge, StudentsRepository repository, IOManager inputOutputManager)
            : base(input, data, judge, repository, inputOutputManager)
        {

        }

        public override void Execute()
        {
            if (this.Data.Length == DataLengthForShowDataByCourse)
            {
                string courseName = this.Data[1];
                this.Repository.GetAllStudentsFromCourse(courseName);
            }
            else if (this.Data.Length == DataLengthForShowDataByCourseAndUsername)
            {
                string courseName = this.Data[1];
                string userName = this.Data[2];
                this.Repository.GetStudentsScoresFromCourse(courseName, userName);
            }
            else
            {
                throw new InvalidCommandException(this.Input);
            }           
        }
    }
}
