using System;

namespace StorageMaster
{
    public abstract class Product
    {
        private double price;
        private double weight;

        protected Product(double price, double weight)
        {
            this.Price = price;
            this.Weight = weight;
        }

        public double Weight 
        {
            get { return weight ; }
            private set { weight  = value; }
        }

        public double Price 
        {
            get { return price; }
            private set
            {
                if (value < 0)
                {
                    throw new InvalidOperationException("Price cannot be negative!");
                }

                price = value;
            }
        }
    }
}
