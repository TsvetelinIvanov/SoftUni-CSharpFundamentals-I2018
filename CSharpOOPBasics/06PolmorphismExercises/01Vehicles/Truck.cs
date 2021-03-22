using System;

public class Truck : Vehicle
{
    private const double ConsumptionIncreaser = 1.6;
    private const double HoleLossDecreaseCoefficient = 0.95;

    public Truck(double fuelQuantity, double fuelConsumptionLPerKm)
        : base(fuelQuantity, fuelConsumptionLPerKm)
    {

    }

    private double IncreasedConsumpionLPerKm => base.FuelConsumptionLPerKm + ConsumptionIncreaser;

    public override void Drive(double distance)
    {
        if (this.IncreasedConsumpionLPerKm * distance <= base.FuelQuantity)
        {
            base.FuelQuantity -= this.IncreasedConsumpionLPerKm * distance;
            Console.WriteLine($"Truck travelled {distance} km");
        }
        else
        {
            Console.WriteLine("Truck needs refueling");
        }
    }

    public override void Refuel(double quantity)
    {
        base.FuelQuantity += quantity * HoleLossDecreaseCoefficient;
    }
}