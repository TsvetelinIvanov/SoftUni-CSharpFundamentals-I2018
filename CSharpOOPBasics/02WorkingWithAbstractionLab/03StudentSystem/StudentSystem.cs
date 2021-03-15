using System;
using System.Collections.Generic;

public class StudentSystem
{
    private Dictionary<string, Student> repo;

    public StudentSystem()
    {
        this.Repo = new Dictionary<string, Student>();
    }

    public Dictionary<string, Student> Repo
    {
        get { return repo; }
        private set { repo = value; }
    }

    public void ParseCommand(string command)
    {
        string[] args = command.Split();

        if (args[0] == "Create")
        {
            string name = args[1];
            int age = int.Parse(args[2]);
            double grade = double.Parse(args[3]);
            if (!repo.ContainsKey(name))
            {
                Student student = new Student(name, age, grade);
                Repo[name] = student;
            }
        }
        else if (args[0] == "Show")
        {
            string name = args[1];
            if (Repo.ContainsKey(name))
            {
                Student student = Repo[name];
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