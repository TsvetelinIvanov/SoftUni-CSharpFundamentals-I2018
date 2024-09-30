using System.Collections.Generic;
using System.Text;

public class LeutenantGeneral : Private, ILeutenantGeneral
{
    private List<Private> privates;

    public LeutenantGeneral(string id, string firstName, string lastName, decimal salary) : base(id, firstName, lastName, salary)
    {
        this.Privates = new List<Private>();
    }

    public List<Private> Privates
    {
        get { return this.privates; }
        set { this.privates = value; }
    }

    public override string ToString()
    {
        StringBuilder LieutenantGeneralBuilder = new StringBuilder();
        LieutenantGeneralBuilder.AppendLine(base.ToString());
        LieutenantGeneralBuilder.AppendLine("Privates:");
        foreach (Private private1 in this.Privates)
        {
            LieutenantGeneralBuilder.AppendLine("  " + private1.ToString());
        }

        string builtLieutenantGeneral = LieutenantGeneralBuilder.ToString().TrimEnd();

        return builtLieutenantGeneral;
    }
}
