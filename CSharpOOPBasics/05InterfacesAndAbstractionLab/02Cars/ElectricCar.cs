using System;

public class ElectricCar : Car, IElectricCar
{
    public int Battery { get; set; }

    public ElectricCar(string model, string color, int battery) : base(model, color)
    {
        this.Battery = battery;
    }

    public override string ToString()
    {
        return $"{this.Color} {this.GetType()} {this.Model} with {this.Battery} Batteries{Environment.NewLine}" +
            $"{this.Start()}{Environment.NewLine}" + ;
            $"{this.Stop()}";
    }
}
