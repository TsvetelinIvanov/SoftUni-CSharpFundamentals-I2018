public class AggressiveDriver : Driver
{
    public AggressiveDriver(string name, Car car) : base(name, car, 2.7)
    {

    }

    public override double Speed => ((this.Car.Hp + this.Car.Tyre.Degradation) / this.Car.FuelAmount) * 1.3;
    //public override double Speed => base.Speed * 1.3;
}