using System;

public abstract class Vehicle : IVehicle
{
    private double fuelQuantity;
    private double fuelConsumptionLPerKm;
    private double tankCapacity;

    public Vehicle(double fuelQuantity, double fuelConsumptionLPerKm, double tankCapacity)
    {        
        this.FuelQuantity = fuelQuantity;
        this.FuelConsumptionLPerKm = fuelConsumptionLPerKm;
        this.TankCapacity = tankCapacity;
    }

    public double FuelQuantity
    {
        get { return this.fuelQuantity; }
        set
        {
            if (value > this.TankCapacity)
            {
                value = 0;
            }

            this.fuelQuantity = value;
        }
    }

    public double FuelConsumptionLPerKm
    {
        get { return this.fuelConsumptionLPerKm; }
        set { this.fuelConsumptionLPerKm = value; }
    }

    public double TankCapacity
    {
        get { return this.tankCapacity; }
        set { this.tankCapacity = value; }
    }

    public abstract void Drive(double distance);

    public virtual void Refuel(double quantity)
    {
        if (quantity <= 0)
        {
            Console.WriteLine("Fuel must be a positive number");
            
            return;
        }

        if (this.FuelQuantity + quantity > this.TankCapacity)
        {
            Console.WriteLine($"Cannot fit {quantity} fuel in the tank");
            
            return;
        }

        this.FuelQuantity += quantity;
    }
}
