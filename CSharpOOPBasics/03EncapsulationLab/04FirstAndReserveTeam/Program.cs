using System;
using System.Collections.Generic;

public class Program
{
    static void Main(string[] args)
    {
        int personsCount = int.Parse(Console.ReadLine());
        List<Person> persons = new List<Person>();
        for (int i = 0; i < personsCount; i++)
        {
            string[] input = Console.ReadLine().Split();
            Person person = new Person(input[0], input[1], int.Parse(input[2]), decimal.Parse(input[3]));
            persons.Add(person);
        }

        Team team = new Team("SoftUni");
        foreach (Person player in persons)
        {
            team.AddPlayer(player);
        }

        Console.WriteLine($"First team has {team.FirstTeam.Count} players.");
        Console.WriteLine($"Reserve team has {team.ReserveTeam.Count} players.");
    }
}