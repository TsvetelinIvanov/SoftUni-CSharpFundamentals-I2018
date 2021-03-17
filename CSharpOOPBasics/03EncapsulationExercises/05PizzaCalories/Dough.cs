using System;
using System.Collections.Generic;
using System.Linq;

public class Dough
{
    private const int MinWeight = 1;
    private const int MaxWeight = 200;

    private Dictionary<string, double> validFlorTypes = new Dictionary<string, double>
    {
        ["white"] = 1.5,
        ["wholegrain"] = 1.0,
    };

    private Dictionary<string, double> validBakingTechniques = new Dictionary<string, double>
    {
        ["crispy"] = 0.9,
        ["chewy"] = 1.1,
        ["homemade"] = 1.0,
    };
        
    private string flourType;
    private string bakingTechnique;
    private double weight;    

    public Dough(string flourType, string bakingTechnique, double weight)
    {
        this.FlourType = flourType;
        this.BakingTechnique = bakingTechnique;
        this.Weight = weight;
    }

    public string FlourType
    {
        get { return this.flourType; }
        set
        {
            if (!this.validFlorTypes.Any(f => f.Key == value.ToLower()))
            {
                throw new ArgumentException("Invalid type of dough.");
            }

            this.flourType = value;
        }
    }

    public string BakingTechnique
    {
        get { return this.bakingTechnique; }
        set
        {
            if (!this.validBakingTechniques.Any(b => b.Key == value.ToLower()))
            {
                throw new ArgumentException("Invalid type of dough.");
            }

            this.bakingTechnique = value;
        }
    }

    public double Weight
    {
        get { return this.weight; }
        set
        {
            if (value < MinWeight || value > MaxWeight)
            {
                throw new ArgumentException($"Dough weight should be in the range [{MinWeight}..{MaxWeight}].");
            }

            this.weight = value;
        }         
    }

    public double CalorySize
    {
        get
        {
            return 2 * Weight * validFlorTypes[this.FlourType.ToLower()] *
              validBakingTechniques[this.BakingTechnique.ToLower()];
        }
    }
}