using System;
using System.Collections.Generic;

namespace _03IteratorTest
{
    public class ListIterator
    {
        private List<string> collection;
        private int currentIndex;

        public ListIterator(IEnumerable<string> collection)
        {
            if (collection == null)
            {
                throw new ArgumentNullException();
            }

            this.collection = new List<string>(collection);
        }

        public bool Move()
        {
            if (this.currentIndex + 1 < this.collection.Count)
            {
                this.currentIndex++;

                return true;
            }
            else
            {
                return false;
            }
        }

        public bool HasNext()
        {
            if (this.currentIndex + 1 < this.collection.Count)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public string Print()
        {
            if (this.collection.Count == 0)
            {
                throw new InvalidOperationException("Invalid Operation!");
            }

            return this.collection[this.currentIndex];
        }
    }
}