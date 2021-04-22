using System;
using System.Collections.Generic;
using System.Linq;

namespace _01Database
{
    public class Database
    {
        private const int Capacity = 16;

        private int[] data;
        private int count;

        private Database()
        {
            this.data = new int[Capacity];
        }

        public Database(params int[] inputData) : this()
        {
            if (inputData != null)
            {
                foreach (int number in inputData)
                {
                    this.Add(number);
                }
            }
        }

        public Database(IEnumerable<int> inputData) : this()
        {
            foreach (int number in inputData)
            {
                this.Add(number);
            }
        }

        public int Count
        {
            get { return this.count; }
        }

        public void Add(int number)
        {
            if (this.count == this.data.Length)
            {
                throw new InvalidOperationException("Database is full!");
            }

            data[this.count] = number;
            this.count++;
        }

        public void Remove()
        {
            if (this.count == 0)
            {
                throw new InvalidOperationException("Database is empty!");
            }

            this.count--;
        }

        public int[] Fetch()
        {
            return this.data.Take(this.count).ToArray();
        }
    }
}