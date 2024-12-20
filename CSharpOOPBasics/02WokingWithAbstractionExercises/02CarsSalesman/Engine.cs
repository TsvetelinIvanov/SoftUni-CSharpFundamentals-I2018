﻿using System.Text;

public class Engine
{
    private const string Offset = "  ";

    public string model;
    public int power;
    public int displacement;
    public string efficiency;

    public Engine(string model, int power)
    {
        this.model = model;
        this.power = power;
        this.displacement = -1;
        this.efficiency = "n/a";
    }

    public Engine(string model, int power, int displacement) : this(model, power)
    {        
        this.displacement = displacement;        
    }

    public Engine(string model, int power, string efficiency) : this(model, power)
    {        
        this.efficiency = efficiency;
    }

    public Engine(string model, int power, int displacement, string efficiency) : this(model, power)
    {        
        this.displacement = displacement;
        this.efficiency = efficiency;
    }

    public override string ToString()
    {
        StringBuilder carBuilder = new StringBuilder();
        carBuilder.AppendFormat("{0}{1}:\n", Offset, this.model);
        carBuilder.AppendFormat("{0}{0}Power: {1}\n", Offset, this.power);
        carBuilder.AppendFormat("{0}{0}Displacement: {1}\n", Offset, this.displacement == -1 ? "n/a" : this.displacement.ToString());
        carBuilder.AppendFormat("{0}{0}Efficiency: {1}\n", Offset, this.efficiency);

        return carBuilder.ToString();
    }
}
