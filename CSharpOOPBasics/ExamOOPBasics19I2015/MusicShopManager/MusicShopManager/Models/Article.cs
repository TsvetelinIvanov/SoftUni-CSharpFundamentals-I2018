using MusicShopManager.Interfaces;
using System;
using System.Text;

namespace MusicShopManager.Models
{
    public abstract class Article : IArticle
    {
        private string make;
        private string model;
        private decimal price;

        protected Article(string make, string model, decimal price)
        {
            this.Make = make;
            this.Model = model;
            this.Price = price;
        }

        public string Make
        {
            get { return this.make; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("The make of an article is required.");
                }

                this.make = value;
            }
        }

        public string Model
        {
            get { return this.model; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("The model of an article is required.");
                }

                this.model = value;
            }
        }

        public decimal Price
        {
            get { return this.price; }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("The price of an article must be positive.");
                }

                this.price = value;
            }
        }

        public override string ToString()
        {
            StringBuilder articleBuilder = new StringBuilder();
            articleBuilder.AppendFormat("= {0} {1} =", this.Make, this.Model)
                .AppendLine()
                .AppendFormat("Price: ${0:f2}", this.Price)
                .AppendLine();

            return articleBuilder.ToString();
        }
    }
}