using System;

public class Car : ICar
{
    public string Model { get; set; }
    public string Color { get; set; }

    public Car(string model, string color)
    {
        this.Model = model;
        this.Color = color;
    }

    public string Start()
    {
        return "Engine start";
    }

    public string Stop()
    {
        return "Breaaak!";
    }

    public override string ToString()
    {
        return $"{this.Color} {this.GetType()} {this.Model}{Environment.NewLine}" +
            $"{this.Start()}{Environment.NewLine}{this.Stop()}";
    }
}