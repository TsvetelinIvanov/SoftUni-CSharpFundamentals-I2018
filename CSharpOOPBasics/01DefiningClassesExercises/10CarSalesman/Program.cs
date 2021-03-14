using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    static void Main(string[] args)
    {
        List<Car> cars = new List<Car>();
        List<Engine> engines = new List<Engine>();
        int enginesCount = int.Parse(Console.ReadLine());
        for (int i = 0; i < enginesCount; i++)
        {
            Engine engine = ReadEngineDataInput();
            engines.Add(engine);
        }

        int carsCount = int.Parse(Console.ReadLine());
        for (int i = 0; i < carsCount; i++)
        {
            Car car = ReadCarDataInput(engines);
            cars.Add(car);
        }

        cars.ForEach(c => Console.WriteLine(c.ToString()));
    }

    private static Engine ReadEngineDataInput()
    {
        string[] engineDataInput = Console.ReadLine()
            .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        string model = engineDataInput[0];
        int power = int.Parse(engineDataInput[1]);

        if (engineDataInput.Length == 4)
        {
            int displacement = int.Parse(engineDataInput[2]);
            string efficiency = engineDataInput[3];
            Engine engine = new Engine(model, power, displacement, efficiency);

            return engine;
        }
        else if (engineDataInput.Length == 3)
        {
            int displacement = -1;
            bool isDisplacement = int.TryParse(engineDataInput[2], out displacement);
            if (isDisplacement)
            {
                Engine engine = new Engine(model, power, displacement);

                return engine;
            }
            else
            {
                string efficiency = engineDataInput[2];
                Engine engine = new Engine(model, power, efficiency);

                return engine;
            }
        }
        else
        {
            Engine engine = new Engine(model, power);
            return engine;
        }
    }

    private static Car ReadCarDataInput(List<Engine> engines)
    {
        string[] carDataInput = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        string model = carDataInput[0];
        string engineModel = carDataInput[1];
        Engine engine = engines.Single(e => e.Model == engineModel);

        if (carDataInput.Length == 4)
        {
            int weight = int.Parse(carDataInput[2]);
            string color = carDataInput[3];
            Car car = new Car(model, engine, weight, color);
            return car;
        }
        else if (carDataInput.Length == 3)
        {
            int weight = -1;
            bool isWeight = int.TryParse(carDataInput[2], out weight);
            if (isWeight)
            {
                Car car = new Car(model, engine, weight);

                return car;
            }
            else
            {
                string color = carDataInput[2];
                Car car = new Car(model, engine, color);

                return car;
            }
        }
        else
        {
            Car car = new Car(model, engine);
            return car;
        }
    }    
}