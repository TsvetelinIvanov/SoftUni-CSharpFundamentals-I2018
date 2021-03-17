using System;
using System.Text;
using System.Text.RegularExpressions;

public class Student : Human
{
    private const string FacultyNumberPattern = @"^([a-zA-z0-9]{5,10})$";

    private string facultyNumber;

    public Student(string firstName, string lastName, string facultyNumber)
        : base(firstName, lastName)
    {
        this.FacultyNumber = facultyNumber;
    }

    public string FacultyNumber
    {
        get { return this.facultyNumber; }
        set
        {
            if (!Regex.IsMatch(value, FacultyNumberPattern))
            {
                throw new ArgumentException("Invalid faculty number!");
            }

            this.facultyNumber = value;
        }
    }

    public override string ToString()
    {
        StringBuilder studentData = new StringBuilder(base.ToString());
        studentData.Append("Faculty number: " + facultyNumber);

        return studentData.ToString();
    }
}