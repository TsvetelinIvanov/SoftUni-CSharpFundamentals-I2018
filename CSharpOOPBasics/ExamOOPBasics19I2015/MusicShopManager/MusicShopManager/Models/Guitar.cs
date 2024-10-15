using System;
using System.Text;
﻿using MusicShopManager.Interfaces;
 
namespace MusicShopManager.Models
{
    public abstract class Guitar : Instrument, IGuitar
    {
        private const int DefaultNumberOfStrings = 6;

        private string bodyWood;
        private string fingerboardWood;

        protected Guitar(string make, string model, decimal price, string color, string bodyWood, string fingerboardWood)
            : base(make, model, price, color)
        {
            this.BodyWood = bodyWood;
            this.FingerboardWood = fingerboardWood;
        }

        public string BodyWood
        {
            get { return this.bodyWood; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("The body wood of a guitar is required.");
                }

                this.bodyWood = value;
            }
        }

        public string FingerboardWood
        {
            get { return this.fingerboardWood; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("The fingerboard wood of a guitar is required.");
                }

                this.fingerboardWood = value;
            }
        }

        public virtual int NumberOfStrings
        {
            get { return DefaultNumberOfStrings; }
        }

        public override string ToString()
        {
            StringBuilder guitarBuilder = new StringBuilder();
            guitarBuilder.Append(base.ToString())
                .AppendFormat("Strings: {0}", this.NumberOfStrings)
                .AppendLine()
                .AppendFormat("Body wood: {0}", this.bodyWood)
                .AppendLine()
                .AppendFormat("Fingerboard wood: {0}", this.fingerboardWood)
                .AppendLine();

            return guitarBuilder.ToString();
        }
    }
}
