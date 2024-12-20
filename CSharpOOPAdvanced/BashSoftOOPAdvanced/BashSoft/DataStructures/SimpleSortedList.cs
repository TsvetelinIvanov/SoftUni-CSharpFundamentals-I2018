using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
﻿using BashSoft.Exceptions;
using BashSoft.Executor.Contracts;

namespace BashSoft.DataStructures
{
    public class SimpleSortedList<T> : ISimpleOrderedBag<T> where T : IComparable<T>
    {
        private const int DefaultCapacity = 16;

        private T[] innerCollection;
        private int size;
        private IComparer<T> comparison;        

        public SimpleSortedList(IComparer<T> comparison, int capacity)
        {
            this.comparison = comparison;
            this.InitializeInnerCollection(capacity);
        }

        public SimpleSortedList(IComparer<T> comparison) : this(comparison, DefaultCapacity)
        {

        }

        public SimpleSortedList(int capacity) : this(Comparer<T>.Create((x, y) => x.CompareTo(y)), capacity)
        {

        }

        public SimpleSortedList() : this(DefaultCapacity)
        {

        }

        public int Size
        {
            get { return this.size; }
        }

        public int Capacity
        {
            get { return this.innerCollection.Length; }
        }

        private void InitializeInnerCollection(int capacity)
        {
            if (capacity < 0)
            {
                throw new ArgumentException("Capacity cannot be negative!");
            }

            this.innerCollection = new T[capacity];
        }

        public void Add(T element)
        {
            if (element == null)
            {
                throw new ArgumentNullException();
            }

            if (this.innerCollection.Length <= this.Size)
            {
                this.Resize();
            }

            this.innerCollection[this.Size] = element;
            this.size++;
            Array.Sort(this.innerCollection, 0, this.Size, this.comparison);
        }

        private void Resize()
        {
            T[] newCollection = new T[this.Size * 2];
            Array.Copy(innerCollection, newCollection, this.Size);
            this.innerCollection = newCollection;
        }

        public void AddAll(ICollection<T> collection)
        {
            if (collection == null)
            {
                throw new ArgumentNullException();
            }

            if (this.Size + collection.Count >= this.innerCollection.Length)
            {
                this.MultyResize(collection);
            }

            foreach (T element in collection)
            {
                this.innerCollection[this.Size] = element;
                this.size++;
            }

            Array.Sort(this.innerCollection, 0, this.Size, this.comparison);
        }

        private void MultyResize(ICollection<T> collection)
        {
            int newSize = this.innerCollection.Length * 2;
            while (this.Size + collection.Count >= newSize)
            {
                newSize *= 2;
            }

            T[] newCollection = new T[newSize];
            Array.Copy(this.innerCollection, newCollection, this.Size);
            this.innerCollection = newCollection;
        }

        public bool Remove(T element)
        {
            if (element == null)
            {
                throw new ArgumentNullException();
            }

            bool hasBeenRemoved = false;
            int indexOfRemovedElement = 0;
            for (int i = 0; i < this.Size; i++)
            {
                if (this.innerCollection[i].Equals(element))
                {
                    indexOfRemovedElement = i;
                    this.innerCollection[i] = default(T);                    
                    hasBeenRemoved = true;

                    break;
                }
            }

            if (hasBeenRemoved)
            {
                for (int i = indexOfRemovedElement; i < this.Size - 1; i++)
                {
                    this.innerCollection[i] = this.innerCollection[i + 1];
                }

                this.innerCollection[this.Size - 1] = default(T);
                this.size--;
            }

            return hasBeenRemoved;
        }        

        public string JoinWith(string coupler)
        {
            if (coupler == null)
            {
                throw new ArgumentNullException();
            }

            StringBuilder builder = new StringBuilder();
            foreach (T element in this)
            {
                builder.Append(element);
                builder.Append(coupler);
            }

            builder.Remove(builder.Length - coupler.Length, coupler.Length);

            return builder.ToString();
        }

        public T TakeElement(int index)
        {
            if (index < 0 || index >= this.Size)
            {
                throw new InvalidIndexException(index);
            }

            T element = this.innerCollection[index];

            return element;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < this.Size; i++)
            {
                yield return this.innerCollection[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
