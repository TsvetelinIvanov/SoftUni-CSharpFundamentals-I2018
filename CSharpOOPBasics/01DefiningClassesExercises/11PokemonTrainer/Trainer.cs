using System.Collections.Generic;
using System.Linq;

public class Trainer
{
    private string name;
    private int badgesCount;
    private List<Pokemon> pokemons;

    public Trainer(string name)
    {
        this.Name = name;
        this.BadgesCount = 0;
        this.Pokemons = new List<Pokemon>();
    }

    public string Name
    {
        get { return this.name; }
        set { this.name = value; }
    }

    public int BadgesCount
    {
        get { return this.badgesCount; }
        set { this.badgesCount = value; }
    }

    public List<Pokemon> Pokemons
    {
        get { return this.pokemons; }
        set { this.pokemons = value; }
    }

    public void AddBadge()
    {
        this.BadgesCount++;
    }

    public void ClearDeadPokemons()
    {
        if (this.Pokemons.Count > 0 && this.Pokemons.Any(p => p.Health <= 0))
        this.Pokemons = this.Pokemons.Where(p => p.Health > 0).ToList();
    }
}