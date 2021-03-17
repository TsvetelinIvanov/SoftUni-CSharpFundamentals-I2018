using System;
using System.Collections.Generic;
using System.Linq;

public class Topping
{
    private const int MinWeight = 1;
    private const int MaxWeight = 50;

    private Dictionary<string, double> validTypes = new Dictionary<string, double>
    {
        ["meat"] = 1.2,
        ["veggies"] = 0.8,
        ["cheese"] = 1.1,
        ["sauce"] = 0.9,
    };

    private string type;
    private double weight;

    public Topping(string type, double weight)
    {
        this.Type = type;
        ValidateWeight(type, weight);
        this.Weight = weight;
    }    

    public string Type
    {
        get { return this.type; }
        set
        {
            if (!this.validTypes.Any(t => t.Key == value.ToLower()))
            {
                throw new ArgumentException($"Cannot place {value} on top of your pizza.");
            }

            this.type = value;
        }
    }

    public double Weight
    {
        get { return this.weight; }
        set { this.weight = value; }
    }

    public double CalorySize
    {
        get { return 2 * Weight * validTypes[type.ToLower()]; }
    }

    private void ValidateWeight(string type, double weight)
    {
        if (weight < MinWeight || weight > MaxWeight)
        {
            throw new ArgumentException($"{type} weight should be in the range [{MinWeight}..{MaxWeight}].");
        }
    }
}