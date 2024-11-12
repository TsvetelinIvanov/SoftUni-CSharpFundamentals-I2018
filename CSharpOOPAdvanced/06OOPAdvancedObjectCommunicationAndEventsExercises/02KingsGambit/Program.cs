using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    static void Main(string[] args)
    {
        string kingName = Console.ReadLine();
        King king = new King(kingName);
        List<Soldier> soldiers = new List<Soldier>();
        string[] royalGuardNames = Console.ReadLine().Split();
        foreach (string name in royalGuardNames)
        {
            RoyalGuard royalGuard = new RoyalGuard(name);
            soldiers.Add(royalGuard);
            king.UnderAttackHandler += royalGuard.KingUnderAttack;
        }

        string[] footmanNames = Console.ReadLine().Split();
        foreach (string name in footmanNames)
        {
            Footman footman = new Footman(name);
            soldiers.Add(footman);
            king.UnderAttackHandler += footman.KingUnderAttack;
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
                    Soldier soldier = soldiers.FirstOrDefault(s => s.Name == soldierName);
                    king.UnderAttackHandler -= soldier.KingUnderAttack;
                    soldiers.Remove(soldier);
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
