﻿namespace BashSoft.Executor.Contracts
{
    public interface IFilteredTaker
    {
        void FilterAndTake(string courseName, string givenFilter, int? studentsToTake = null);
    }
}