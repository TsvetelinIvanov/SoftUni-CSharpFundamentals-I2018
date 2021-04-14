using MusicShopManager.Interfaces;
using System;
using System.Text;

namespace MusicShopManager.Models
{
    public class ElectricGuitar : Guitar, IElectricGuitar
    {
        private int numberOfAdapters;
        private int numberOfFrets;

        public ElectricGuitar(string make, string model, decimal price, string color, string bodyWood, string fingerboardWood, int numberOfAdapters, int numberOfFrets) : base(make, model, price, color, bodyWood, fingerboardWood)
        {
            this.NumberOfAdapters = numberOfAdapters;
            this.NumberOfFrets = numberOfFrets;
        }

        public int NumberOfAdapters
        {
            get { return this.numberOfAdapters; }
            private set
            {
                if (value < 0)
                {
                    //throw new ArgumentException("The number of frets of an electronic guitar must be non-negative.");
                    throw new ArgumentException("The number of adapters of an electronic guitar must be non-negative.");
                }

                this.numberOfAdapters = value;
            }
        }

        public int NumberOfFrets
        {
            get { return this.numberOfFrets; }
            private set
            {
                if (value <= 0)
                {
                    //throw new ArgumentException("The number of frets of a guitar must be positive.");
                    throw new ArgumentException("The number of frets of a electronic guitar must be positive.");
                }

                this.numberOfFrets = value;
            }
        }

        public override bool IsElectronic => true;

        public override string ToString()
        {
            StringBuilder electricGuitarBuilder = new StringBuilder();
            electricGuitarBuilder.Append(base.ToString())
                .AppendFormat("Adapters: {0}", this.NumberOfAdapters)
                .AppendLine()
                .AppendFormat("Frets: {0}", this.NumberOfFrets)
                .AppendLine();

            return electricGuitarBuilder.ToString();
        }
    }
}