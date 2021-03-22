public abstract class Vehicle : IVehicle
{
    private double fuelQuantity;
    private double fuelConsumptionLPerKm;

    public Vehicle(double fuelQuantity, double fuelConsumptionLPerKm)
    {
        this.FuelQuantity = fuelQuantity;
        this.FuelConsumptionLPerKm = fuelConsumptionLPerKm;
    }

    public double FuelQuantity
    {
        get { return this.fuelQuantity; }
        set { this.fuelQuantity = value; }
    }

    public double FuelConsumptionLPerKm
    {
        get { return this.fuelConsumptionLPerKm; }
        set { this.fuelConsumptionLPerKm = value; }
    }

    public abstract void Drive(double distance);

    public virtual void Refuel(double quantity)
    {
        this.FuelQuantity += quantity;
    }
}