using System;
using System.Collections.Generic;
using System.Linq;

namespace DungeonsAndCodeWizards
{
    public abstract class Bag
    {
        private const int DefaultCapacity = 100;

        private int capacity;
        private readonly List<Item> items;

        protected Bag(int capacity = DefaultCapacity)
        {
            this.Capacity = capacity;
            this.items = new List<Item>();
        }

        public int Capacity
        {
            get { return this.capacity; }
            private set { this.capacity = value; }
        }

        public IReadOnlyCollection<Item> Items => this.items.AsReadOnly();        

        private int Load => this.items.Sum(i => i.Weight);

        public void AddItem(Item item)
        {
            if (this.Load + item.Weight > this.Capacity)
            {
                throw new InvalidOperationException("Bag is full!");
            }

            this.items.Add(item);
        }

        public Item GetItem(string name)
        {
            if (this.Items.Count == 0)
            {
                throw new InvalidOperationException("Bag is empty!");
            }

            if (!this.Items.Any(i => i.GetType().Name == name))
            {
                //throw new InvalidOperationException($"No item with name {name} in bag!");
                throw new ArgumentException($"No item with name {name} in bag!");
            }

            Item item = Items.First(i => i.GetType().Name == name);
            this.items.Remove(item);

            return item;
        }
    }
}