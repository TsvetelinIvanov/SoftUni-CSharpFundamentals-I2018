using System;

public abstract class Harvester : Unit
{
    private const double OreOutputBottom = 0;
    private const double EnergyRequirementBottom = 0;
    private const double EnergyRequirementCeiling = 10000; //20000;

    private double oreOutput;
    private double energyRequirement;

    protected Harvester(string id, double oreOutput, double energyRequirement) : base(id)
    {
        this.OreOutput = oreOutput;
        this.EnergyRequirement = energyRequirement;
    }

    public double OreOutput
    {
        get { return this.oreOutput; }
        private set
        {
            if (value < OreOutputBottom)
            {
                throw new ArgumentException("Harvester is not registered, because of it's OreOutput");
            }

            this.oreOutput = value;
        }
    }

    public double EnergyRequirement
    {
        get { return this.energyRequirement; }
        private set
        {
            if (value < EnergyRequirementBottom || value > EnergyRequirementCeiling)
            {
                throw new ArgumentException("Harvester is not registered, because of it's EnergyRequirement");
            }

            this.energyRequirement = value;
        }
    }

    public override string Type => "Harvester";

    public override string ToString()
    {
        return $"{this.Type} Harvester - {this.Id}{Environment.NewLine}" +
            $"Ore Output: {this.OreOutput}{Environment.NewLine}" +
            $"Energy Requirement: {this.EnergyRequirement}";
    }
}