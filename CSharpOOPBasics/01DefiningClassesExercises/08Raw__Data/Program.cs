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
            string[] carData = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            string model = carData[0];
            int engineSpeed = int.Parse(carData[1]);
            int enginePower = int.Parse(carData[2]);
            Engine engine = new Engine(engineSpeed, enginePower);
            int cargoWeight = int.Parse(carData[3]);
            string cargoType = carData[4];
            Cargo cargo = new Cargo(cargoWeight, cargoType);
            List<Tire> tires = new List<Tire>();
            for (int j = 5; j <= 12; j += 2)
            {
                double tirePressure = double.Parse(carData[j]);
                int tireAge = int.Parse(carData[j + 1]);
                Tire tire = new Tire(tirePressure, tireAge);
                tires.Add(tire);
            }

            Car car = new Car(model, engine, cargo, tires);
            cars.Add(car);
        }

        string command = Console.ReadLine();

        if (command == "fragile")
        {
            foreach (Car car in cars.Where(c => c.Cargo.Type == "fragile" && c.Tires.Any(t => t.Pressure < 1)))
            {
                Console.WriteLine(car.Model);
            }
        }
        else if (command == "flamable")
        {
            foreach (Car car in cars.Where(c => c.Cargo.Type == "flamable" && c.Engine.Power > 250))
            {
                Console.WriteLine(car.Model);
            }
        }
    }
}