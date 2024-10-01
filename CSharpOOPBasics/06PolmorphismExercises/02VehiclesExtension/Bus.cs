using System;

public class Bus : Vehicle
{
    private const double ConsumptionIncreaser = 1.4;

    private bool isBusEmpty;

    public Bus(double fuelQuantity, double fuelConsumptionLPerKm, double tankCapacity) 
        : base(fuelQuantity, fuelConsumptionLPerKm, tankCapacity)
    {
        this.IsBusEmpty = false;
    }

    public bool IsBusEmpty
    {
        get { return this.isBusEmpty; }
        set { this.isBusEmpty = value; }
    }

    private double IncreasedConsumpionLPerKm => (this.IsBusEmpty) ? base.FuelConsumptionLPerKm : base.FuelConsumptionLPerKm + ConsumptionIncreaser;

    public override void Drive(double distance)
    {
        if (this.IncreasedConsumpionLPerKm * distance <= base.FuelQuantity)
        {
            base.FuelQuantity -= this.IncreasedConsumpionLPerKm * distance;
            Console.WriteLine($"Bus travelled {distance} km");
        }
        else
        {
            Console.WriteLine("Bus needs refueling");
        }
    }
}
