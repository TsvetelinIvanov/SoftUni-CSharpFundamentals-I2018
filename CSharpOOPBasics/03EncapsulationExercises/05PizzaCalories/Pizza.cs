using System;
using System.Collections.Generic;
using System.Linq;

public class Pizza
{
    private const int MinLength = 1;
    private const int MaxLength = 15;
    private const int MinToppingsCount = 0;
    private const int MaxToppingsCount = 10;

    private string name;
    private Dough dough;
    private List<Topping> toppings;

    public Pizza(string name)
    {
        this.Name = name;
        this.Toppings = new List<Topping>();
    }

    public string Name
    {
        get { return this.name; }
        set
        {
            if (value.Length < MinLength || value.Length > MaxLength)
            {
                throw new ArgumentException($"Pizza name should be between {MinLength} and {MaxLength} symbols.");
            }

            this.name = value;
        }
    }

    public Dough Dough
    {
        get { return this.dough; }
        set { this.dough = value; }
    }

    public List<Topping> Toppings
    {
        get { return this.toppings; }
        set { this.toppings = value; }
    }

    public double CalorySize
    {
        get { return this.Dough.CalorySize + this.Toppings.Select(t => t.CalorySize).Sum(); }
    }

    public int ToppingsCount
    {
        get { return Toppings.Count(); }
    }    

    public void AddTopping(Topping topping)
    {
        if (ToppingsCount > MaxToppingsCount)
        {
            throw new ArgumentException($"Number of toppings should " +
                $"be in range [{MinToppingsCount}..{MaxToppingsCount}].");
        }

        this.Toppings.Add(topping);
    }

    public override string ToString()
    {
        return $"{this.Name} - {this.CalorySize:f2} Calories.";
    }
}