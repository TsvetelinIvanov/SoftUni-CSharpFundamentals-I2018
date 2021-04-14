using System;

public abstract class Provider : Unit
{
    private const double EnergyOutputBottom = 0;
    private const double EnergyOutputCeiling = 10000;

    private double energyOutput;

    protected Provider(string id, double energyOutput) : base(id)
    {
        this.EnergyOutput = energyOutput;
    }

    public double EnergyOutput
    {
        get { return this.energyOutput; }
        private set
        {
            if (value < EnergyOutputBottom || value >= EnergyOutputCeiling)
            {
                throw new ArgumentException("Provider is not registered, because of it's EnergyOutput");
            }

            this.energyOutput = value;
        }
    }

    public override string Type => "Provider";

    public override string ToString()
    {
        return $"{this.Type} Provider - {this.Id}{Environment.NewLine}" +
            $"Energy Output: {this.EnergyOutput}";
    }
}