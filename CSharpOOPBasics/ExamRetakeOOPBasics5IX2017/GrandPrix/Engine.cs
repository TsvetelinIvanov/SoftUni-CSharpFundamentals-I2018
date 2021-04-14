using System;
using System.Collections.Generic;
using System.Linq;

public class Engine
{
    private RaceTower raceTower;

    public Engine(RaceTower raceTower)
    {
        this.raceTower = raceTower;
    }

    internal void Run()
    {
        while (!this.raceTower.IsRaceOver)
        {            
            string[] commandArgs = Console.ReadLine().Split();
            string command = commandArgs[0];
            List<string> methodArgs = commandArgs.Skip(1).ToList();
            switch (command)
            {
                case "RegisterDriver":
                    this.raceTower.RegisterDriver(methodArgs);
                    break;
                case "Leaderboard":
                    Console.WriteLine(this.raceTower.GetLeaderboard());
                    break;
                case "CompleteLaps":
                    string completedLaps = this.raceTower.CompleteLaps(methodArgs);
                    if (!string.IsNullOrWhiteSpace(completedLaps))                    
                    {
                        Console.WriteLine(completedLaps);
                    }

                    break;
                case "Box":
                    this.raceTower.DriverBoxes(methodArgs);
                    break;
                case "ChangeWeather":
                    this.raceTower.ChangeWeather(methodArgs);
                    break;
                default:
                    Console.WriteLine("INVALID COMMAND");
                    break;
            }
        }
    }
}