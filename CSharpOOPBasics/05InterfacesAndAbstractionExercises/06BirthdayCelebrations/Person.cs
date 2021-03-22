public class Person : IIDable, IOrganicable
{
    private string name;
    private int age;
    private string id;
    private string birthDate;

    public Person(string name, int age, string id, string birthDate)
    {
        this.Name = name;
        this.Age = age;
        this.Id = id;
        this.BirthDate = birthDate;
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
}