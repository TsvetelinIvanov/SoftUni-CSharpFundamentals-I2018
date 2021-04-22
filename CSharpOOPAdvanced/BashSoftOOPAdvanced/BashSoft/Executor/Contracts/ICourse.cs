using System;
using System.Collections.Generic;

namespace BashSoft.Executor.Contracts
{
    public interface ICourse : IComparable<ICourse>
    {
        string Name { get; }

        IReadOnlyDictionary<string, IStudent> StudentsByName { get; }

        void EnrollStudent(IStudent sudent);
    }
}