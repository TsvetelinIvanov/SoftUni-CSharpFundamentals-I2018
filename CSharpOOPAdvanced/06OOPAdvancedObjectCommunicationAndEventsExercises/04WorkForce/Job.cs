using System;

public delegate void JobCompletedHandler(Job job);

public class Job
{
    public event JobCompletedHandler JobCompletedHandler;

    private int hoursRequired;
    private Employee assignedEmployee;

    public Job(string name, int hoursRequired, Employee employee)
    {
        this.Name = name;
        this.hoursRequired = hoursRequired;
        this.assignedEmployee = employee;
    }

    public string Name { get; private set; }

    public void Update()
    {
        this.hoursRequired -= this.assignedEmployee.HoursPerWeek;

        if (hoursRequired <= 0)
        {
            Console.WriteLine($"Job {this.Name} done!");
            this.JobCompletedHandler.Invoke(this);
        }
    }

    public override string ToString()
    {
        return $"Job: {this.Name} Hours Remaining: {this.hoursRequired}";
    }
}
