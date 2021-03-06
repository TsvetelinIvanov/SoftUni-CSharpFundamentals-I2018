using System;

public class SpecialisedSoldier : Private, ISpecialisedSoldier
{
    private string corps;

    public SpecialisedSoldier(string id, string firstName, string lastName, decimal salary, string corps)
        : base(id, firstName, lastName, salary)
    {
        this.Corps = corps;
    }

    public string Corps
    {
        get { return this.corps; }
        set
        {
            if (value != "Airforces" && value != "Marines")
            {
                throw new ArgumentException("Invalid corps!");
            }

            this.corps = value;
        }
    }
}