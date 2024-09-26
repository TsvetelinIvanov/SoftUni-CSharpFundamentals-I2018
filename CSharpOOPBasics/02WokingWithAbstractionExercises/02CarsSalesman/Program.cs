using System;
using System.Collections.Generic;
using System.Linq;

public class CarSalesman
{
    static void Main(string[] args)
    {
        List<Car> cars = new List<Car>();
        List<Engine> engines = new List<Engine>();
        int enginesCount = int.Parse(Console.ReadLine());
        for (int i = 0; i < enginesCount; i++)
        {
            string[] engineParameters = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            string model = engineParameters[0];
            int power = int.Parse(engineParameters[1]);

            int displacement = -1;
            if (engineParameters.Length == 3 && int.TryParse(engineParameters[2], out displacement))
            {
                engines.Add(new Engine(model, power, displacement));
            }
            else if (engineParameters.Length == 3)
            {
                string efficiency = engineParameters[2];
                engines.Add(new Engine(model, power, efficiency));
            }
            else if (engineParameters.Length == 4)
            {
                string efficiency = engineParameters[3];
                engines.Add(new Engine(model, power, int.Parse(engineParameters[2]), efficiency));
            }
            else
            {
                engines.Add(new Engine(model, power));
            }
        }

        int carsCount = int.Parse(Console.ReadLine());
        for (int i = 0; i < carsCount; i++)
        {
            string[] carParameters = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            string model = carParameters[0];
            string engineModel = carParameters[1];
            Engine engine = engines.FirstOrDefault(e => e.model == engineModel);

            int weight = -1;
            if (carParameters.Length == 3 && int.TryParse(parameters[2], out weight))
            {
                cars.Add(new Car(model, engine, weight));
            }
            else if (carParameters.Length == 3)
            {
                string color = carParameters[2];
                cars.Add(new Car(model, engine, color));
            }
            else if (carParameters.Length == 4)
            {
                string color = parameters[3];
                cars.Add(new Car(model, engine, int.Parse(carParameters[2]), color));
            }
            else
            {
                cars.Add(new Car(model, engine));
            }
        }

        foreach (Car car in cars)
        {
            Console.WriteLine(car);
        }
    }
}
