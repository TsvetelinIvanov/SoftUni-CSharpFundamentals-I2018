using System;

public class Car
{
    private string model;
    private double fuelAmount;
    private double fuelConsumptionPerKm;
    private int traveledDistance = 0;

    public Car(string model, double fuelAmount, double fuelConsumptionPerKm)
    {
        this.Model = model;
        this.FuelAmount = fuelAmount;
        this.FuelConsumptionPerKm = fuelConsumptionPerKm;        
    }

    public string Model
    {
        get { return this.model; }
        set { this.model = value; }
    }

    public double FuelAmount
    {
        get { return this.fuelAmount; }
        set { this.fuelAmount = value; }
    }

    public double FuelConsumptionPerKm
    {
        get { return this.fuelConsumptionPerKm; }
        set { this.fuelConsumptionPerKm = value; }
    }

    public int TraveledDistance
    {
        get { return this.traveledDistance; }
        set { this.traveledDistance = value; }
    }

    public void DriveCar(int distance)
    {
        if (distance * this.FuelConsumptionPerKm <= this.FuelAmount)
        {
            this.TraveledDistance += distance;
            this.FuelAmount -= distance * this.FuelConsumptionPerKm;
        }
        else
        {
            Console.WriteLine("Insufficient fuel for the drive");
        }
    }

    public override string ToString()
    {
        return $"{this.Model} {this.FuelAmount:f2} {this.TraveledDistance}";
    }
}
