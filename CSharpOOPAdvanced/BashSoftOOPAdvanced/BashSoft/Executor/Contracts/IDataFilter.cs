using System.Collections.Generic;

namespace BashSoft.Executor.Contracts
{
    public interface IDataFilter
    {
        void FilterAndTake(Dictionary<string, double> studentsWithMarks, string wantedFilter, int studentsToTake);
    }
}