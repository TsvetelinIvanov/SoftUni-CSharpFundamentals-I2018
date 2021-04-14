public abstract class Driver
{
    private const double TimeInBox = 20;
    private const double TimeInLap = 60;

    private string name;
    private double totalTime;
    private Car car;
    private double fuelConsumptionPerKm;

    protected Driver(string name, Car car, double fuelConsumptionPerKm)
    {
        this.Name = name;        
        this.Car = car;
        this.FuelConsumptionPerKm = fuelConsumptionPerKm;
        this.TotalTime = 0.0;
        this.IsRacing = true;
    }

    public string Name
    {
        get { return this.name; }
        private set { this.name = value; }
    }

    public double TotalTime
    {
        get { return this.totalTime; }
        set { this.totalTime = value; }
    }

    public Car Car
    {
        get { return this.car; }
        private set { this.car = value; }
    }

    public double FuelConsumptionPerKm
    {
        get { return this.fuelConsumptionPerKm; }
        private set { this.fuelConsumptionPerKm = value; }
    }

    public virtual double Speed => (this.Car.Hp + this.Car.Tyre.Degradation) / this.Car.FuelAmount;

    public string FailureReason { get; private set; }

    public bool IsRacing { get; private set; }

    private string Status => IsRacing ? this.TotalTime.ToString("f3") : this.FailureReason;

    private void Box()
    {
        this.TotalTime += TimeInBox;
    }

    internal void Refuel(double fuelAmount)
    {
        this.Box();        
        this.Car.Refuel(fuelAmount);
    }

    internal void ChangeTyres(Tyre tyre)
    {
        this.Box();
        this.Car.ChangeTyres(tyre);
    }

    internal void CompleteLap(int trackLength)
    {
        this.TotalTime += TimeInLap / (trackLength / this.Speed);
        this.Car.CompleteLap(trackLength, this.FuelConsumptionPerKm);
    }

    internal void Fail(string massege)
    {
        this.IsRacing = false;
        this.FailureReason = massege;
    }

    public override string ToString()
    {
        return $"{this.Name} {this.Status}";
    }
}