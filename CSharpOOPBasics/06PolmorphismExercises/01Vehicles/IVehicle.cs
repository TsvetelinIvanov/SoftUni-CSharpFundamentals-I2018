public interface IVehicle
{
    double FuelQuantity { get; set; }

    double FuelConsumptionLPerKm { get; set; }

    void Drive(double distance);

    void Refuel(double quantity);
}