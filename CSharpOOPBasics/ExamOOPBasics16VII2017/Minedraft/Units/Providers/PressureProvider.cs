public class PressureProvider : Provider
{
    public const double EnergyOutputIncreaser = 1.5;

    public PressureProvider(string id, double energyOutput) : base(id, energyOutput * EnergyOutputIncreaser)
    {

    }

    public override string Type => "Pressure";
}