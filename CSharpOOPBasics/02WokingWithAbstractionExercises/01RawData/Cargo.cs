public class Cargo
{
    private string type;
    private int weight;

    public Cargo(string type, int weight)
    {
        this.type = type;
        this.weight = weight;
    }

    public string Type
    {
        get { return this.type; }
        set { this.type = value; }
    }

    public int Weight
    {
        get { return this.weight; }
        set { this.weight = value; }
    }    
}