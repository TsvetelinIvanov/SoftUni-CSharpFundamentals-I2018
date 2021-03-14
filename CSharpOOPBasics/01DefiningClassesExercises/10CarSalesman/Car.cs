using System.Text;

public class Car
{
    private string model;
    private Engine engine;
    private int weight;
    private string color;

    public Car(string model, Engine engine)
    {
        this.Model = model;
        this.Engine = engine;
        this.Weight = -1;
        this.Color = "n/a";
    }

    public Car(string model, Engine engine, int weight)
        : this(model, engine)
    {        
        this.Weight = weight;        
    }

    public Car(string model, Engine engine, string color)
        : this(model, engine)
    {
        this.Color = color;
    }

    public Car(string model, Engine engine, int weight, string color)
        : this(model, engine)
    {
        this.Weight = weight;
        this.Color = color;
    }

    public string Model
    {
        get { return this.model; }
        set { this.model = value; }
    }

    public Engine Engine
    {
        get { return this.engine; }
        set { this.engine = value; }
    }

    public int Weight
    {
        get { return this.weight; }
        set { this.weight = value; }
    }

    public string Color
    {
        get { return this.color; }
        set { this.color = value; }
    }

    public override string ToString()
    {
        StringBuilder carData = new StringBuilder();
        carData.AppendFormat("{0}:\r\n", this.Model);
        carData.Append(this.Engine.ToString());
        carData.AppendFormat("  Weight: {0}\r\n", this.Weight == -1 ? "n/a" : this.Weight.ToString());
        carData.AppendFormat("  Color: {0}", this.Color);
        return carData.ToString();
    }
}