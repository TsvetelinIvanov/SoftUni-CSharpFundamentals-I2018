using System;
using System.Collections.Generic;
using System.Linq;

namespace StorageMaster
{
    public abstract class Vehicle
    {
        private int capacity;
        private readonly List<Product> trunk; 

        protected Vehicle(int capacity)
        {
            this.Capacity = capacity;
            this.trunk = new List<Product>();
        }

        public int Capacity
        {
            get { return capacity; }
            private set { capacity = value; }
        }

        public IReadOnlyCollection<Product> Trunk
        {                      
            get { return this.trunk.AsReadOnly(); }
        }

        public bool IsFull => this.Trunk.Sum(p => p.Weight) >= this.Capacity;

        //public bool IsEmpty => this.Trunk.Count == 0;
        public bool IsEmpty => !this.Trunk.Any();

        public void LoadProduct(Product product)
        {
            if (IsFull) 
            {
                throw new InvalidOperationException("Vehicle is full!");
            }

            //It isn't in instructions:
            //if (product.Weight + this.Trunk.Sum(p => p.Weight) >= this.Capacity)
            //{
            //    throw new InvalidOperationException("Vehicle is full!");
            //}

            this.trunk.Add(product);
        }

        public Product Unload()
        {
            if (IsEmpty)
            {
                throw new InvalidOperationException("No products left in vehicle!");
            }

            Product product = this.trunk[trunk.Count - 1];
            this.trunk.RemoveAt(trunk.Count - 1);

            return product;
        }
    }
}