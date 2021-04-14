using System;

public class Car
{
    private const double FuelMin = 0;
    private const double FuelMax = 160;

    private int hp;
    private double fuelAmount;
    private Tyre tyre;

    public Car(int hp, double fuelAmount, Tyre tyre)
    {
        this.Hp = hp;
        this.FuelAmount = fuelAmount;
        this.Tyre = tyre;
    }

    public int Hp
    {
        get { return this.hp; }
        private set { this.hp = value; }
    }

    public double FuelAmount
    {
        get { return this.fuelAmount; }
        private set
        {
            if (value < FuelMin)
            {
                throw new ArgumentException(OutputMessages.OutOfFuel);
            }

            this.fuelAmount = Math.Min(value, FuelMax);
        }
    }

    public Tyre Tyre
    {
        get { return this.tyre; }
        private set { this.tyre = value; }
    }

    internal void Refuel(double fuelAmount)
    {
        this.FuelAmount += fuelAmount;
    }

    internal void ChangeTyres(Tyre tyre)
    {
        this.Tyre = tyre;
    }

    internal void CompleteLap(int trackLength, double fuelConsumption)
    {
        this.FuelAmount -= trackLength * fuelConsumption;

        this.Tyre.CompleteLap();
    }
}