using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    static void Main(string[] args)
    {
        List<Car> cars = new List<Car>();
        int carsCount = int.Parse(Console.ReadLine());
        for (int i = 0; i < carsCount; i++)
        {
            string[] carsData = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            string model = carsData[0];
            double fuelAmount = double.Parse(carsData[1]);
            double fuelConsumptionPerKm = double.Parse(carsData[2]);
            
            Car car = new Car(model, fuelAmount, fuelConsumptionPerKm);
            cars.Add(car);
        }

        string commandInput;
        while ((commandInput = Console.ReadLine()) != "End")
        {
            string[] command = commandInput.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            string model = command[1];
            int distance = int.Parse(command[2]);
            Car car = cars.Single(c => c.Model == model);

            car.DriveCar(distance);
        }

        cars.ForEach(c => Console.WriteLine(c.ToString()));
    }
}
