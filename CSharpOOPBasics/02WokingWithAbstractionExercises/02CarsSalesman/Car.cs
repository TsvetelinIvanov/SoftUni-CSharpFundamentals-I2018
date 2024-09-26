using System.Text;

public class Car
{
    private const string Offset = "  ";

    public string model;
    public Engine engine;
    public int weight;
    public string color;

    public Car(string model, Engine engine)
    {
        this.model = model;
        this.engine = engine;
        this.weight = -1;
        this.color = "n/a";
    }

    public Car(string model, Engine engine, int weight) : this(model, engine)
    {       
        this.weight = weight;        
    }

    public Car(string model, Engine engine, string color) : this(model, engine)
    {        
        this.color = color;
    }

    public Car(string model, Engine engine, int weight, string color) : this(model, engine)
    {        
        this.weight = weight;
        this.color = color;
    }


    public override string ToString()
    {
        StringBuilder carBuilder = new StringBuilder();
        carBuilder.AppendFormat("{0}:\n", this.model);
        carBuilder.Append(this.engine.ToString());
        carBuilder.AppendFormat("{0}Weight: {1}\n", Offset, this.weight == -1 ? "n/a" : this.weight.ToString());
        carBuilder.AppendFormat("{0}Color: {1}", Offset, this.color);

        return carBuilder.ToString();
    }
}
