﻿namespace BashSoft.Executor.Contracts
{
    public interface IContentComparer
    {
        void CompareContent(string userOutputPath, string expectedOutputPath);
    }
}