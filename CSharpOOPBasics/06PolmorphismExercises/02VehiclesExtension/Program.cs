using System;

public class Program
{
    static void Main(string[] args)
    {
        Car car = ReadCarData();
        Truck truck = ReadTruckData();
        Bus bus = ReadBusData();

        DriveAndRefuel(car, truck, bus);

        Console.WriteLine($"Car: {car.FuelQuantity:f2}");
        Console.WriteLine($"Truck: {truck.FuelQuantity:f2}");
        Console.WriteLine($"Bus: {bus.FuelQuantity:f2}");
    }

    private static Car ReadCarData()
    {
        string[] carData = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        double fuelQuantity = double.Parse(carData[1]);
        double consumptionLPerKm = double.Parse(carData[2]);
        double tankCapacity = double.Parse(carData[3]);
        Car car = new Car(fuelQuantity, consumptionLPerKm, tankCapacity);

        return car;
    }

    private static Truck ReadTruckData()
    {
        string[] truckData = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        double fuelQuantity = double.Parse(truckData[1]);
        double consumptionLPerKm = double.Parse(truckData[2]);
        double tankCapacity = double.Parse(truckData[3]);
        Truck truck = new Truck(fuelQuantity, consumptionLPerKm, tankCapacity);

        return truck;
    }

    private static Bus ReadBusData()
    {
        string[] busData = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        double fuelQuantity = double.Parse(busData[1]);
        double consumptionLPerKm = double.Parse(busData[2]);
        double tankCapacity = double.Parse(busData[3]);
        Bus bus = new Bus(fuelQuantity, consumptionLPerKm, tankCapacity);

        return bus;
    }        

    private static void DriveAndRefuel(Car car, Truck truck, Bus bus)
    {
        int commandsCount = int.Parse(Console.ReadLine());
        for (int i = 0; i < commandsCount; i++)
        {
            string[] commandLine = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            string command = commandLine[0];
            string vehicleType = commandLine[1];
            double distanceOrFuelQuantity = double.Parse(commandLine[2]);
            switch (command)
            {
                case "Drive":
                    if (vehicleType == "Car")
                    {
                        car.Drive(distanceOrFuelQuantity);
                    }
                    else if (vehicleType == "Truck")
                    {
                        truck.Drive(distanceOrFuelQuantity);
                    }
                    else if (vehicleType == "Bus")
                    {
                        bus.Drive(distanceOrFuelQuantity);
                    }

                    break;
                case "DriveEmpty":
                    if (vehicleType == "Bus")
                    {
                        bus.IsBusEmpty = true;
                        bus.Drive(distanceOrFuelQuantity);
                    }

                    break;
                case "Refuel":
                    if (vehicleType == "Car")
                    {
                        car.Refuel(distanceOrFuelQuantity);
                    }
                    else if (vehicleType == "Truck")
                    {
                        truck.Refuel(distanceOrFuelQuantity);
                    }
                    else if (vehicleType == "Bus")
                    {
                        bus.Refuel(distanceOrFuelQuantity);
                    }

                    break;
            }
        }
    }
}