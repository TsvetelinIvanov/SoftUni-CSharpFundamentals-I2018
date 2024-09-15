using System.Text;

public class Engine
{
    private string model;
    private int power;
    private int displacement;
    private string efficiency;

    public Engine(string model, int power)
    {
        this.Model = model;
        this.Power = power;
        this.Displacement = -1;
        this.Efficiency = "n/a";
    }

    public Engine(string model, int power, int displacement) : this(model, power)
    {        
        this.Displacement = displacement;        
    }

    public Engine(string model, int power, string efficiency) : this(model, power)
    {
        this.Efficiency = efficiency;
    }

    public Engine(string model, int power, int displacement, string efficiency) : this(model, power)
    {
        this.Displacement = displacement;
        this.Efficiency = efficiency;
    }

    public string Model
    {
        get { return this.model; }
        set { this.model = value; }
    }

    public int Power
    {
        get { return this.power; }
        set { this.power = value; }
    }

    public int Displacement
    {
        get { return this.displacement; }
        set { this.displacement = value; }
    }

    public string Efficiency
    {
        get { return this.efficiency; }
        set { this.efficiency = value; }
    }

    public override string ToString()
    {
        StringBuilder engineData = new StringBuilder();
        engineData.AppendFormat("  {0}:\r\n", this.Model);
        engineData.AppendFormat("    Power: {0}\r\n", this.Power);
        engineData.AppendFormat("    Displacement: {0}\r\n", this.Displacement == -1 ? "n/a" : this.Displacement.ToString());
        engineData.AppendFormat("    Efficiency: {0}\r\n", this.Efficiency);

        return engineData.ToString();
    }
}
