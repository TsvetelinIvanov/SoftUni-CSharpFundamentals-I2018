using System.Collections.Generic;
using System.Linq;

public class Department
{
    string name;
    private List<Employee> employees;    

    public Department(string name)
    {
        this.Name = name;
        this.Employees = new List<Employee>();        
    }

    public string Name
    {
        get { return this.name; }
        set { this.name = value; }
    }

    public List<Employee> Employees
    {
        get { return employees; }
        private set { this.employees = value; }
    }

    public decimal AverigeSalary => this.Employees.Select(e => e.Salary).Average();

    public void AddEmployee(Employee employee)
    {
        this.Employees.Add(employee);
    }
}