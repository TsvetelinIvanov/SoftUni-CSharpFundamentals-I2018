using System;
using System.Linq;

public class Program
{
    static void Main(string[] args)
    {
        string kingName = Console.ReadLine();
        King king = new King(kingName);
        
        string[] royalGuardNames = Console.ReadLine().Split();
        foreach (string name in royalGuardNames)
        {
            RoyalGuard royalGuard = new RoyalGuard(name);
            king.AddSoldier(royalGuard);
        }
        
        string[] footmanNames = Console.ReadLine().Split();
        foreach (string name in footmanNames)
        {
            Footman footman = new Footman(name);
            king.AddSoldier(footman);
        }

        string input;
        while((input = Console.ReadLine()) != "End")
        {
            string[] commandArgs = input.Split();
            string command = commandArgs[0];
            switch (command)
            {
                case "Kill":
                    string soldierName = commandArgs[1];
                    Soldier soldier = king.Soldiers.FirstOrDefault(s => s.Name == soldierName);                   
                    soldier.TakeAttack();
                    break;
                case "Attack":
                    king.OnAttack();
                    break;
                default:
                    break;
            }
        }
    }
}
