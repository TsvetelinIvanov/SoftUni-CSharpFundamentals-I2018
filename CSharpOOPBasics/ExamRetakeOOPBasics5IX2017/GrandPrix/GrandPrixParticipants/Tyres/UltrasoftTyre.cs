using System;

public class UltrasoftTyre : Tyre
{
    private const double TyreBlowLimit = 0;

    private double grip;

    public UltrasoftTyre(double hardness, double grip) : base("Ultrasoft", hardness)
    {
        this.Grip = grip;
    }

    public override double Degradation
    {
        get => base.Degradation;
        protected set
        {
            if (value < TyreBlowLimit)
            {
                throw new ArgumentException(OutputMessages.BlownTyre);
            }

            base.Degradation = value;
        }
    }

    public double Grip
    {
        get { return this.grip; }
        private set { this.grip = value; }
    }

    public override void CompleteLap()
    {
        this.Degradation -= (this.Hardness + this.Grip);
    }

    //public override void CompleteLap()
    //{
    //    base.CompleteLap();

    //    this.Degradation -= this.Grip;
    //}
}