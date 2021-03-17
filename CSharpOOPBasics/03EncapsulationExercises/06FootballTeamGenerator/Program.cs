using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    static void Main(string[] args)
    {
        List<Team> teams = new List<Team>();
        string input;
        while ((input = Console.ReadLine()) != "END")
        {
            string[] inputData = input.Split(';');
            string command = inputData[0];
            switch (command)
            {
                case "Team":
                    teams = AddTeam(teams, inputData);
                    break;
                case "Add":
                    AddPlayer(teams, inputData);
                    break;
                case "Remove":
                    RemovePlayer(teams, inputData);
                    break;
                case "Rating":
                    ShowRating(teams, inputData);
                    break;
            }
        }
    }

    private static List<Team> AddTeam(List<Team> teams, string[] inputData)
    {
        string teamName = inputData[1];
        Team team = new Team(teamName);
        teams.Add(team);

        return teams;
    }    

    private static void AddPlayer(List<Team> teams, string[] inputData)
    {
        string teamName = inputData[1];
        if (!teams.Any(t => t.Name == teamName))
        {
            Console.WriteLine($"Team {teamName} does not exist.");

            return;
        }

        string playerName = inputData[2];
        int endurance = int.Parse(inputData[3]);
        int sprint = int.Parse(inputData[4]);
        int dribble = int.Parse(inputData[5]);
        int passing = int.Parse(inputData[6]);
        int shooting = int.Parse(inputData[7]);
        Player player = new Player(playerName, endurance, sprint, dribble, passing, shooting);
        if (string.IsNullOrEmpty(player.Name) || string.IsNullOrWhiteSpace(player.Name))
        {
            return;
        }

        teams.Single(t => t.Name == teamName).Players.Add(player);
    }

    private static void RemovePlayer(List<Team> teams, string[] inputData)
    {
        string teamName = inputData[1];
        //if (!teams.Any(t => t.Name == teamName))
        //{
        //    Console.WriteLine($"Team {teamName} does not exist.");

        //    return;
        //}

        string playerName = inputData[2];
        Team team = teams.Single(t => t.Name == teamName);
        if (!team.Players.Any(p => p.Name == playerName))
        {
            Console.WriteLine($"Player {playerName} is not in {teamName} team.");

            return;
        }

        Player removedPlayer = team.Players.Single(p => p.Name == playerName);
        team.Players.Remove(removedPlayer);
    }

    private static void ShowRating(List<Team> teams, string[] inputData)
    {
        string teamName = inputData[1];
        if (string.IsNullOrEmpty(teamName) || string.IsNullOrWhiteSpace(teamName))
        {
            Console.WriteLine("A name should not be empty.");

            return;
        }

        if (!teams.Any(t => t.Name == teamName))
        {
            Console.WriteLine($"Team {teamName} does not exist.");

            return;
        }

        Console.WriteLine($"{teamName} - {teams.Single(t => t.Name == teamName).Rating:f0}");
    }    
}