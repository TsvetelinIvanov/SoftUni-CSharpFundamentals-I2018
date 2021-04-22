using System;

public class Dragon : ITarget
{
    private const string ThisDeadEvent = "{0} dies";

    private string id;
    private int hp;
    private int reward;
    private bool eventTriggered;
    private IHandler logger;

    public Dragon(string id, int hp, int reward, IHandler logger)
    {
        this.id = id;
        this.hp = hp;
        this.reward = reward;
        this.logger = logger;
    }

    public bool IsDead { get => this.hp <= 0; }

    public void ReceiveDamage(int damage)
    {
        if (!this.IsDead)
        {
            this.hp -= damage;
        }

        if (this.IsDead && !eventTriggered)
        {
            Console.WriteLine(ThisDeadEvent, this);
            this.eventTriggered = true;
        }
    }

    public override string ToString()
    {
        return this.id;
    }
}