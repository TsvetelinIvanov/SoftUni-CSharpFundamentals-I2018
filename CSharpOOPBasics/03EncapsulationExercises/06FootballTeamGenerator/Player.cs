using System;
using System.Collections.Generic;
using System.Linq;

public class Player
{
    private const int MinSkillLevel = 0;
    private const int MaxSkillLevel = 100;

    private string name;
    private Dictionary<string, int> stats = new Dictionary<string, int>
    {
        ["Endurance"] = 0,
        ["Sprint"] = 0,
        ["Dribble"] = 0,
        ["Passing"] = 0,
        ["Shooting"] = 0,
    };

    public Player(string name, int endurance, int sprint, int dribble, int passing ,int shooting)
    {
        bool isStateValid = IsStateValid(endurance, sprint, dribble, passing, shooting);
        if (!isStateValid)
        {
            return;
        }

        this.Name = name;
        this.Stats["Endurance"] = endurance;
        this.Stats["Sprint"] = sprint;
        this.Stats["Dribble"] = dribble;
        this.Stats["Passing"] = passing;
        this.Stats["Shooting"] = shooting;

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

    public Dictionary<string, int> Stats
    {
        get { return this.stats; }
        set
        {
            this.stats = value;
        }
    }

    public double Rating
    {
        get
        {
            return this.Stats.Values.Average();
        }
    }

    private bool IsStateValid(int endurance, int sprint, int dribble, int passing, int shooting)
    {
        if (endurance < MinSkillLevel || endurance > MaxSkillLevel)
        {
            Console.WriteLine($"Endurance should be between {MinSkillLevel} and {MaxSkillLevel}.");

            return false;
        }

        if (sprint < MinSkillLevel || sprint > MaxSkillLevel)
        {
            Console.WriteLine($"Sprint should be between {MinSkillLevel} and {MaxSkillLevel}.");

            return false;
        }

        if (dribble < MinSkillLevel || dribble > MaxSkillLevel)
        {
            Console.WriteLine($"Dribble should be between {MinSkillLevel} and {MaxSkillLevel}.");

            return false;
        }

        if (passing < MinSkillLevel || passing > MaxSkillLevel)
        {
            Console.WriteLine($"Passing should be between {MinSkillLevel} and {MaxSkillLevel}.");

            return false;
        }

        if (shooting < MinSkillLevel || shooting > MaxSkillLevel)
        {
            Console.WriteLine($"Shooting should be between {MinSkillLevel} and {MaxSkillLevel}.");

            return false;
        }

        return true;
    }
}