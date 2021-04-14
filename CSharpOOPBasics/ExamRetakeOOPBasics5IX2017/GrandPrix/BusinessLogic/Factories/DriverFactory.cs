using System;
using System.Collections.Generic;
using System.Linq;

public class DriverFactory
{
    public Driver CreateDriver(List<string> commandArgs)
    {
        string type = commandArgs[0];
        string name = commandArgs[1];
        int hp = int.Parse(commandArgs[2]);
        double fuelAmount = double.Parse(commandArgs[3]);
        List<string> tyreData = commandArgs.Skip(4).ToList();
        TyreFactory tyreFactory = new TyreFactory();
        Tyre tyre = tyreFactory.CreateTyre(tyreData);
        Car car = new Car(hp, fuelAmount, tyre);

        switch (type)
        {
            case "Aggressive":
                return new AggressiveDriver(name, car);
            case "Endurance":
                return new EnduranceDriver(name, car);
            default:
                throw new AggregateException(OutputMessages.InvalidDriverType);
        }        
    }
}