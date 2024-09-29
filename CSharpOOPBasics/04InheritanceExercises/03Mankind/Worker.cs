using System;
using System.Text;

public class Worker : Human
{
    private const int WorkDaysInWeek = 5;

    private decimal weekSalary;
    private double workHoursPerDay;

    public Worker(string firstName, string lastName, decimal weekSalary, double workHoursPerDay) : base(firstName, lastName)
    {
        this.WeekSalary = weekSalary;
        this.WorkHoursPerDay = workHoursPerDay;
    }

    public decimal WeekSalary
    {
        get { return this.weekSalary; }
        set
        {
            if (value <= 10)
            {
                throw new ArgumentException("Expected value mismatch! Argument: weekSalary");
            }

            this.weekSalary = value;
        }
    }

    public double WorkHoursPerDay
    {
        get { return this.workHoursPerDay; }
        set
        {
            if (value < 1 || value > 12)
            {
                throw new ArgumentException("Expected value mismatch! Argument: workHoursPerDay");
            }

            this.workHoursPerDay = value;
        }
    }

    public decimal HourSalary => this.WeekSalary / ((decimal)this.WorkHoursPerDay * WorkDaysInWeek);

    public override string ToString()
    {
        StringBuilder workerDataBuilder = new StringBuilder(base.ToString());
        workerDataBuilder.AppendLine($"Week Salary: {this.WeekSalary:f2}")
            .AppendLine($"Hours per day: {this.WorkHoursPerDay:f2}")
            .Append($"Salary per hour: {this.HourSalary:f2}");

        return workerDataBuilder.ToString();
    }
}
