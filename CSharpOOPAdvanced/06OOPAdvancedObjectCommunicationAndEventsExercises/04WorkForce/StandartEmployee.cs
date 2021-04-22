public class StandartEmployee : Employee
{
    private const int workingHoursPerWeek = 40;

    public StandartEmployee(string name) : base(name, workingHoursPerWeek)
    {

    }
}