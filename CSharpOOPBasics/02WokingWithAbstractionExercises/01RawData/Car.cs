using System.Collections.Generic;

public class Car
{
    private string model;
    private Cargo cargo;
    private Engine engine;
    public List<Tire> tires;

    public Car(string model, Engine engine, Cargo cargo, List<Tire> tires)
    {
        this.Model = model;
        this.Cargo = cargo;        
        this.Engine = engine;        
        this.tires = tires;
    }
    
    public string Model
    {
        get { return this.model; }
        set { this.model = value; }
    }

    public Cargo Cargo
    {
        get { return this.cargo; }
        set { this.cargo = value; }
    }

    public Engine Engine
    {
        get { return this.engine; }
        set { this.engine = value; }
    }   
}