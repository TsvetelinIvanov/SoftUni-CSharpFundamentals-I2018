using MusicShopManager.Interfaces;

namespace MusicShopManager.Models
{
    public class BassGuitar : Guitar, IBassGuitar
    {
        private const int DefaultNumberOfStrings = 4;

        public BassGuitar(string make, string model, decimal price, string color, string bodyWood, string figerboardWood) : base(make, model, price, color, bodyWood, figerboardWood)
        {

        }

        public override int NumberOfStrings => DefaultNumberOfStrings;

        public override bool IsElectronic => true;
    }
}