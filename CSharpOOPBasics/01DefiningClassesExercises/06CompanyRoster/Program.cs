using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    static void Main(string[] args)
    {
        List<Department> departments = new List<Department>();
        int n = int.Parse(Console.ReadLine());
        for (int person = 0; person < n; person++)
        {
            string[] employeeInfo = Console.ReadLine().Split(new char[] { ' ' },StringSplitOptions.RemoveEmptyEntries);
            string departmentName = employeeInfo[3];

            if (!departments.Any(d => d.Name == departmentName))
            {
                Department department1 = new Department(departmentName);
                departments.Add(department1);
            }

            Department department = departments.FirstOrDefault(d => d.Name == departmentName);
            Employee employee = ParseEmployee(employeeInfo);
            department.AddEmployee(employee);
        }

        Department highestAverageSalaryDepartment = departments.OrderByDescending(d => d.AverageSalary).First();
        Console.WriteLine($"Highest Average Salary: {highestAverageSalaryDepartment.Name}");
        foreach (Employee employee1 in highestAverageSalaryDepartment.Employees.OrderByDescending(e => e.Salary))
        {
            Console.WriteLine($"{employee1.Name} {employee1.Salary:f2} {employee1.Email} {employee1.Age}");
        }
    }

    private static Employee ParseEmployee(string[] employeeInfo)
    {
        string name = employeeInfo[0];
        decimal salary = decimal.Parse(employeeInfo[1]);
        string position = employeeInfo[2];
        string email = "n/a";
        int age = -1;

        if (employeeInfo.Length == 6)
        {
            email = employeeInfo[4];
            age = int.Parse(employeeInfo[5]);
        }
        else if (employeeInfo.Length == 5)
        {
            bool isAge = int.TryParse(employeeInfo[4], out age);
            if (!isAge)
            {
                email = employeeInfo[4];
                age = -1;
            }
        }

        Employee employee = new Employee(name, position, salary, age, email);
        
        return employee;
    }
}
