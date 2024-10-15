using System.Text;
using MusicShopManager.Interfaces;

namespace MusicShopManager.Models
{
    public class AcousticGuitar : Guitar, IAcousticGuitar
    {
        public AcousticGuitar(string make, string model, decimal price, string color, string bodyWood, string fingerboardWood, bool caseIncluded, StringMaterial stringMaterial)
            : base(make, model, price, color, bodyWood, fingerboardWood)
        {
            this.CaseIncluded = caseIncluded;
            this.StringMaterial = stringMaterial;
        }

        public bool CaseIncluded { get; private set; }

        public StringMaterial StringMaterial { get; private set; }

        public override string ToString()
        {
            StringBuilder acousticGuitarBuilder = new StringBuilder();
            acousticGuitarBuilder.Append(base.ToString())
                .AppendFormat("Case included: {0}", this.CaseIncluded ? "yes" : "no")
                .AppendLine()
                .AppendFormat("String material: {0}", this.StringMaterial.ToString())
                .AppendLine();

            return acousticGuitarBuilder.ToString();
        }
    }
}
