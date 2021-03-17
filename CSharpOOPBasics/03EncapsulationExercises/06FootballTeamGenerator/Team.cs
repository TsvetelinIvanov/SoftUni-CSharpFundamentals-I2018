using System;
using System.Collections.Generic;
using System.Linq;

public class Team
{
    private string name;
    private List<Player> players;

    public Team(string name)
    {
        this.Name = name;
        this.Players = new List<Player>();
    }

    public string Name
    {
        get { return this.name; }
        set
        {
            if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
            {
                Console.WriteLine("A name should not be empty.");

                return;
            }

            this.name = value;
        }
    }

    public List<Player> Players
    {
        get { return this.players; }
        set { this.players = value; }
    }

    public double Rating
    {
        get
        {
            if (this.Players.Count == 0)
            {
                return 0;
            }

            return this.Players.Select(p => p.Rating).Average();
        }
    }
}