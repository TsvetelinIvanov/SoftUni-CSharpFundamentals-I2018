public class SonicHarvester : Harvester
{
    public SonicHarvester(string id, double oreOutput, double energyRequirement, int sonicFactor)
        : base(id, oreOutput, energyRequirement / sonicFactor)
    {

    }

    public override string Type => "Sonic";
}
