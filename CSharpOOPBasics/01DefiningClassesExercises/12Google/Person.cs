using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Person
{
    private string name;
    private Company company;
    private Car car;
    private List<Pokemon> pokemons;
    private List<Parent> parents;
    private List<Child> children;

    public Person(string name)
    {
        this.Name = name;
        this.Pokemons = new List<Pokemon>();
        this.Parents = new List<Parent>();
        this.Children = new List<Child>();
    }

    public string Name
    {
        get { return this.name; }
        set { this.name = value; }
    }

    public Company Company
    {
        get { return this.company; }
        set { this.company = value; }
    }

    public Car Car
    {
        get { return this.car; }
        set { this.car = value; }
    }

    public List<Pokemon> Pokemons
    {
        get { return this.pokemons; }
        set { this.pokemons = value; }
    }

    public List<Parent> Parents
    {
        get { return this.parents; }
        set { this.parents = value; }
    }

    public List<Child> Children
    {
        get { return this.children; }
        set { this.children = value; }
    }

    public override string ToString()
    {
        StringBuilder personData = new StringBuilder();
        personData.AppendLine(this.Name);
        personData.AppendLine("Company:");
        if (this.Company != null)
        {
            personData.AppendLine(this.Company.ToString());
        }

        personData.AppendLine("Car:");
        if (this.Car != null)
        {
            personData.AppendLine(this.Car.ToString());
        }

        personData.AppendLine("Pokemon:");
        if (this.Pokemons.Count > 0)
        {
            personData.AppendLine(string.Join(Environment.NewLine, this.Pokemons.Select(p => p.ToString())));
        }

        personData.AppendLine("Parents:");
        if (this.Parents.Count > 0)
        {
            personData.AppendLine(string.Join(Environment.NewLine, this.Parents.Select(p => p.ToString())));
        }

        personData.AppendLine("Children:");
        if (this.Children.Count > 0)
        {
            personData.AppendLine(string.Join(Environment.NewLine, this.Children.Select(ch => ch.ToString())));
        }

        return personData.ToString();
    }
}