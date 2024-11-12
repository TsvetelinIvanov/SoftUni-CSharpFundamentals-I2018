using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    static void Main(string[] args)
    {
        JobList jobs = new JobList();
        List<Employee> employees = new List<Employee>();

        string input;
        while ((input = Console.ReadLine()) != "End")
        {
            string[] commandArgs = input.Split();

            string command = commandArgs[0];
            switch (command)
            {
                case "Job":
                    string jobName = commandArgs[1];
                    int hoursRequired = int.Parse(commandArgs[2]);
                    string employeeName = commandArgs[3];
                    Employee employee = employees.First(e => e.Name == employeeName);
                    Job job = new Job(jobName, hoursRequired, employee);
                    jobs.AddJob(job);
                    break;
                case "StandardEmployee":
                    employeeName = commandArgs[1];
                    employee = new StandartEmployee(employeeName);
                    employees.Add(employee);
                    break;
                case "PartTimeEmployee":
                    employeeName = commandArgs[1];
                    employee = new PartTimeEmployee(employeeName);
                    employees.Add(employee);
                    break;
                case "Pass":
                    jobs.ToList().ForEach(j => j.Update());
                    break;
                case "Status":
                    foreach (Job job1 in jobs)
                    {
                        Console.WriteLine(job1); 
                    }
                    
                    break;
            }
        }
    }
}
