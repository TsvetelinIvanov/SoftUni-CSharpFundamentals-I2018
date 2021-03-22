public class Ferrari : ICar
{
    private string model;
    private string driver;

    public Ferrari(string driver)
    {
        this.Model = "488-Spider";
        this.Driver = driver;
    }

    public string Model
    {
        get { return this.model; }
        set { this.model = value; }
    }

    public string Driver
    {
        get { return this.driver; }
        set { this.driver = value; }
    }

    public string UseBrakes()
    {
        return "Brakes!";
    }

    public string PushGasPedal()
    {
        return "Zadu6avam sA!";
    }

    public override string ToString()
    {
        return $"{this.Model}/{this.UseBrakes()}/{this.PushGasPedal()}/{this.Driver}";
    }
}