using System;
using System.Collections.Generic;
using System.Text;

public class Engineer : SpecialisedSoldier, IEngineer
{
    private List<Repair> repairs;

    public Engineer(string id, string firstName, string lastName, decimal salary, string corps) : base(id, firstName, lastName, salary, corps)
    {
        this.Repairs = new List<Repair>();
    }

    public List<Repair> Repairs
    {
        get { return this.repairs; }
        set { this.repairs = value; }
    }

    public override string ToString()
    {
        StringBuilder engineerBuilder = new StringBuilder();
        engineerBuilder.AppendLine(base.ToString());
        engineerBuilder.AppendLine($"Corps: {this.Corps}{Environment.NewLine}Repairs:");
        foreach (Repair repair in this.Repairs)
        {
            engineerBuilder.AppendLine("  " + repair.ToString());
        }

        string builtEngineer = engineerBuilder.ToString().TrimEnd();

        return builtEngineer;
    }
}