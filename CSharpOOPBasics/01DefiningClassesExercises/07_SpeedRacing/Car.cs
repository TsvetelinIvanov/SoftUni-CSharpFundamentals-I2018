using System;

public class Car
{
    private string model;
    private double fuelAmount;
    private double fuelConsumptionFor1km;
    private int traveledDistance = 0;

    public Car(string model, double fuelAmount, double fuelConsumptionFor1km)
    {
        this.Model = model;
        this.FuelAmount = fuelAmount;
        this.FuelConsumptionFor1km = fuelConsumptionFor1km;        
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

    public double FuelConsumptionFor1km
    {
        get { return this.fuelConsumptionFor1km; }
        set { this.fuelConsumptionFor1km = value; }
    }

    public int TraveledDistance
    {
        get { return this.traveledDistance; }
        set { this.traveledDistance = value; }
    }

    public void DriveCar(int distance)
    {
        if (distance * FuelConsumptionFor1km <= FuelAmount)
        {
            TraveledDistance += distance;
            FuelAmount -= distance * FuelConsumptionFor1km;
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