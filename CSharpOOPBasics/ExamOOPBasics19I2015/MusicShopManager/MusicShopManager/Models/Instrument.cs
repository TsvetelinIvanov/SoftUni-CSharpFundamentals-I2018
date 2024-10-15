using System;
using System.Text;
﻿using MusicShopManager.Interfaces;

namespace MusicShopManager.Models
{
    public abstract class Instrument : Article, IInstrument
    {
        private string color;

        protected Instrument(string make, string model, decimal price, string color) : base(make, model, price)
        {
            this.Color = color;
        }

        public string Color
        {
            get { return this.color; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("The color of an instrument is required.");
                }

                this.color = value;
            }
        }

        public virtual bool IsElectronic { get; private set; }

        public override string ToString()
        {
            StringBuilder instrumentBuilder = new StringBuilder();
            instrumentBuilder.Append(base.ToString())
                .AppendFormat("Color: {0}", this.Color)
                .AppendLine()
                .AppendFormat("Electronic: {0}", this.IsElectronic ? "yes" : "no")
                .AppendLine();

            return instrumentBuilder.ToString();
        }
    }
}
