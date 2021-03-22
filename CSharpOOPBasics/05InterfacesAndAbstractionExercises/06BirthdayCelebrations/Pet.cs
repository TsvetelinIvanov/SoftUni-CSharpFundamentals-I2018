public class Pet : IOrganicable
{
    private string name;
    private string birthDate;

    public Pet(string name, string birthDate)
    {
        this.Name = name;
        this.BirthDate = birthDate;
    }

    public string Name
    {
        get { return this.name; }
        set { this.name = value; }
    }

    public string BirthDate
    {
        get { return this.birthDate; }
        set { this.birthDate = value; }
    }
}