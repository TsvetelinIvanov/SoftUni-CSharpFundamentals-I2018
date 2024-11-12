using System;
using System.Collections.Generic;

public delegate void KingUnderAttackHandler();

public class King
{
    public event KingUnderAttackHandler UnderAttackHandler;

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
        this.UnderAttackHandler += soldier.KingUnderAttack;
        soldier.SoldierDiedHandler += this.OnSoldierDead;
    }

    public void OnAttack()
    {
        Console.WriteLine($"King {this.Name} is under attack!");
        this.UnderAttackHandler?.Invoke();
    }

    public void OnSoldierDead(Soldier soldier)
    {
        this.UnderAttackHandler -= soldier.KingUnderAttack;
        this.soldiers.Remove(soldier);
    }
}
