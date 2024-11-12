public class PartTimeEmployee : Employee
{
    private const int WorkingHoursPerWeek = 20;

    public PartTimeEmployee(string name) : base(name, WorkingHoursPerWeek)
    {

    }
}
