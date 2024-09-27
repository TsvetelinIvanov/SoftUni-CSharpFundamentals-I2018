using System;
using System.Collections.Generic;

public class StudentSystem
{
    private Dictionary<string, Student> students;

    public StudentSystem()
    {
        this.Students = new Dictionary<string, Student>();
    }

    public Dictionary<string, Student> Students
    {
        get { return this.students; }
        private set { this.students = value; }
    }

    public void ParseCommand(string command)
    {
        string[] args = command.Split();

        if (args[0] == "Create")
        {
            string name = args[1];
            int age = int.Parse(args[2]);
            double grade = double.Parse(args[3]);
            if (!this.Students.ContainsKey(name))
            {
                Student student = new Student(name, age, grade);
                this.Students[name] = student;
            }
        }
        else if (args[0] == "Show")
        {
            string name = args[1];
            if (this.Students.ContainsKey(name))
            {
                Student student = this.Students[name];
                string view = $"{student.Name} is {student.Age} years old.";
                if (student.Grade >= 5.00)
                {
                    view += " Excellent student.";
                }
                else if (student.Grade < 5.00 && student.Grade >= 3.50)
                {
                    view += " Average student.";
                }
                else
                {
                    view += " Very nice person.";
                }

                Console.WriteLine(view);
            }
        }        
    }
}
