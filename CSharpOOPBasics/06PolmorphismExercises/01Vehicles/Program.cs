using System;

public class Program
{
    static void Main(string[] args)
    {       
        Car car = ReadCarData();
        Truck truck = ReadTruckData();       
        
        DriveOrRefuel(car, truck);

        Console.WriteLine($"Car: {car.FuelQuantity:f2}");
        Console.WriteLine($"Truck: {truck.FuelQuantity:f2}");
    }

    private static Car ReadCarData()
    {
        string[] carData = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        double fuelQuantity = double.Parse(carData[1]);
        double consumptionLPerKm = double.Parse(carData[2]);
        Car car = new Car(fuelQuantity, consumptionLPerKm);

        return car;
    }

    private static Truck ReadTruckData()
    {
        string[] truckData = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        double fuelQuantity = double.Parse(truckData[1]);
        double consumptionLPerKm = double.Parse(truckData[2]);
        Truck truck = new Truck(fuelQuantity, consumptionLPerKm);

        return truck;
    }    

    private static void DriveOrRefuel(Car car, Truck truck)
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

                    break;
            }
        }
    }
}