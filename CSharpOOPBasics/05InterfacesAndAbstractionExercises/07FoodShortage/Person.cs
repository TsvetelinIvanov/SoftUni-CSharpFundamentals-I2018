public class Person : IBuyer
{
    private string name;
    private int age;    
    private int food;

    public Person(string name, int age)
    {
        this.Name = name;
        this.Age = age;        
        this.Food = 0;
    }

    public string Name
    {
        get { return this.name; }
        set { this.name = value; }
    }

    public int Age
    {
        get { return this.age; }
        set { this.age = value; }
    }    

    public int Food
    {
        get { return this.food; }
        set { this.food = value; }
    }

    public virtual void BuyFood()
    {
        this.Food += 100;
    }
}