using System;

public class Car : Vehicle
{
    private const double ConsumptionIncreaser = 0.9;

    public Car(double fuelQuantity, double fuelConsumptionLPerKm, double tankCapacity)
        : base(fuelQuantity, fuelConsumptionLPerKm, tankCapacity)
    {

    }

    private double IncreasedConsumpionLPerKm => base.FuelConsumptionLPerKm + ConsumptionIncreaser;

    public override void Drive(double distance)
    {
        if (this.IncreasedConsumpionLPerKm * distance <= base.FuelQuantity)
        {
            base.FuelQuantity -= this.IncreasedConsumpionLPerKm * distance;
            Console.WriteLine($"Car travelled {distance} km");
        }
        else
        {
            Console.WriteLine("Car needs refueling");
        }
    }
}