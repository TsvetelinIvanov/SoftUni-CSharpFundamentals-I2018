using System;
using System.Collections.Generic;

namespace BashSoft.Executor.Contracts
{
    public interface ISimpleOrderedBag<T> : IEnumerable<T> where T : IComparable<T>
    {
        int Size { get; }

        int Capacity { get; }

        bool Remove(T element);

        void Add(T element);

        void AddAll(ICollection<T> elements);

        string JoinWith(string joiner);

        T TakeElement(int index);
    }
}