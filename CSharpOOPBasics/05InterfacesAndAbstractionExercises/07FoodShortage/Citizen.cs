public class Citizen : Person, IBuyer
{    
    private string id;
    private string birthDate;    

    public Citizen(string name, int age, string id, string birthDate)
        : base(name, age)
    {
        this.Id = id;
        this.BirthDate = birthDate;
    }    

    public string Id
    {
        get { return this.id; }
        set { this.id = value; }
    }

    public string BirthDate
    {
        get { return this.birthDate; }
        set { this.birthDate = value; }
    }   

    public override void BuyFood()
    {
        this.Food += 10;
    }
}