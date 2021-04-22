using System;

public abstract class AbstractHero : IAttacker
{
    private const string TargetNullMessage = "Target is null.";
    private const string NoTargetMessage = "{0} has no target.";
    private const string TargetDeadMessage = "{0} is dead.";
    private const string SetTargetMessage = "{0} targets {1}.";

    private string id;
    private int damage;
    private ITarget target;
    private IHandler logger;

    public AbstractHero(string id, int damage, IHandler logger)
    {
        this.id = id;
        this.damage = damage;
        this.logger = logger;
    }

    public void Attack()
    {
        if (this.target == null)
        {
            Console.WriteLine(NoTargetMessage, this);
        }
        else if (this.target.IsDead)
        {
            Console.WriteLine(TargetDeadMessage, this.target);
        }
        else
        {
            this.ExecuteClassSpecificAttack(this.target, this.damage);
        }
    }

    public void SetTarget(ITarget target)
    {
        if (target == null)
        {
            Console.WriteLine(TargetNullMessage);
        }
        else
        {
            this.target = target;
            Console.WriteLine(SetTargetMessage, this, target);
        }
    }

    protected abstract void ExecuteClassSpecificAttack(ITarget target, int damage);

    public override string ToString()
    {
        return this.id;
    }
}