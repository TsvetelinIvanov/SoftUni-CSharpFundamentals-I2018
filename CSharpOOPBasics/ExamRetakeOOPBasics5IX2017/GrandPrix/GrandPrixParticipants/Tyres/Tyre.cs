using System;

public abstract class Tyre
{
    private const double TyreBlowLimit = 0;

    private string name;
    private double hardness;
    private double degradation;

    protected Tyre(string name, double hardness)
    {
        this.Name = name;
        this.Hardness = hardness;
        this.Degradation = 100;
    }

    public string Name
    {
        get { return this.name; }
        private set { this.name = value; }
    }

    public double Hardness
    {
        get { return this.hardness; }
        private set { this.hardness = value; }
    }

    public virtual double Degradation
    {
        get { return this.degradation; }
        protected set
        {
            if (value < TyreBlowLimit)
            {
                throw new ArgumentException(OutputMessages.BlownTyre);
            }

            this.degradation = value;
        }
    }

    public virtual void CompleteLap()
    {
        this.Degradation -= this.Hardness;
    }
}