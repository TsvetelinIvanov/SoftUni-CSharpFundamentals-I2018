public class Employee
{
    private string name;
    private int age;
    private decimal salary;
    private string position;
    private string email;

    public Employee(string name, string position, decimal salary, int age, string email)
    {
        this.Name = name;
        this.Position = position;
        this.Salary = salary;
        this.Age = age;
        this.Email = email;
    }

    public string Name
    {
        get { return name;  }
        set { name = value; }
    }

    public string Position
    {
        get { return position; }
        set { position = value; }
    }

    public decimal Salary
    {
        get { return salary; }
        set { salary = value; }
    }

    public int Age
    {
        get { return age; }
        set { age = value; }
    }

    public string Email
    {
        get { return email; }
        set { email = value; }
    }
}