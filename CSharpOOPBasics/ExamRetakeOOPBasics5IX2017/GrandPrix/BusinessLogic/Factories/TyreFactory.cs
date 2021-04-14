using System;
using System.Collections.Generic;

public class TyreFactory
{
    public Tyre CreateTyre(List<string> commandArgs)
    {
        string type = commandArgs[0];
        double hardness = double.Parse(commandArgs[1]);

        switch (type)
        {
            case "Hard":
                return new HardTyre(hardness);
            case "Ultrasoft":
                double grip = double.Parse(commandArgs[2]);
                return new UltrasoftTyre(hardness, grip);
            default:
                throw new ArgumentException(OutputMessages.InvalidTyreType);
        }        
    }
}