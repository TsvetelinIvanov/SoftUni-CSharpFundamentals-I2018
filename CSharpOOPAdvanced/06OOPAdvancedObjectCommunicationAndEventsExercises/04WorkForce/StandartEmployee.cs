public class StandartEmployee : Employee
{
    private const int WorkingHoursPerWeek = 40;

    public StandartEmployee(string name) : base(name, WorkingHoursPerWeek)
    {

    }
}
