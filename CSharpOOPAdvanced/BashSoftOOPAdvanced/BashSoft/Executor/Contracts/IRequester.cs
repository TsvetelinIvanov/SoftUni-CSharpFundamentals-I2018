using System.Collections.Generic;

namespace BashSoft.Executor.Contracts
{
    public interface IRequester
    {
        void GetStudentsScoresFromCourse(string courseName, string userName);

        void GetAllStudentsFromCourse(string courseName);

        ISimpleOrderedBag<ICourse> GetAllCoursesSorted(IComparer<ICourse> comparer);

        ISimpleOrderedBag<IStudent> GetAllStudentsSorted(IComparer<IStudent> comparer);
    }
}
