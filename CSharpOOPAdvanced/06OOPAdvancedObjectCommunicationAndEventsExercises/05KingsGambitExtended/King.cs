using System;
using System.Collections.Generic;

public delegate void KingUnderAttackhandler();

public class King
{
    public event KingUnderAttackhandler UnderAttack;

    private List<Soldier> soldiers;

    public King(string name)
    {
        this.Name = name;
        this.soldiers = new List<Soldier>();
    }

    public string Name { get; private set; }

    public IReadOnlyCollection<Soldier> Soldiers
    {
        get { return this.soldiers; }
    }

    public void AddSoldier(Soldier soldier)
    {
        this.soldiers.Add(soldier);
        UnderAttack += soldier.KingUnderAttack;
        soldier.SoldierDied += this.OnSoldierDead;
    }

    public void OnAttack()
    {
        Console.WriteLine($"King {this.Name} is under attack!");
        UnderAttack?.Invoke();
    }

    public void OnSoldierDead(Soldier soldier)
    {
        this.UnderAttack -= soldier.KingUnderAttack;
        this.soldiers.Remove(soldier);
    }
}