public class HammerHarvester : Harvester
{
    private const double OreOutputIncreaser = 3;
    private const double EnergyRequirementIncreaser = 2;

    public HammerHarvester(string id, double oreOutput, double energyRequirement)
        : base(id, oreOutput * OreOutputIncreaser, energyRequirement * EnergyRequirementIncreaser)
    {

    }

    public override string Type => "Hammer";
}
