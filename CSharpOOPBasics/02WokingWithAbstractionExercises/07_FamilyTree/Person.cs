using System;
using System.Collections.Generic;

public class Person
{
    private string name;
    private string birthday;
    private List<Person> parents;
    private List<Person> children;

    public Person()
    {
        this.Parents = new List<Person>();
        this.Children = new List<Person>();
    }

    //public Person(string name) : this()
    //{
    //    this.Name = name;
    //}

    //public Person(string name, string birthday) : this()
    //{
    //    this.Name = name;
    //    this.Birthday = birthday;
    //}

    public string Name
    {
        get { return this.name; }
        set { this.name = value; }
    }

    public string Birthday
    {
        get { return this.birthday; }
        set { this.birthday = value; }
    }

    public List<Person> Parents
    {
        get { return this.parents; }
        set { this.parents = value; }
    }

    public List<Person> Children
    {
        get { return this.children; }
        set { this.children = value; }
    }

    public static Person CreatePerson(string personImput)
    {
        Person person = new Person();
        if (IsBirthday(personImput))
        {
            person.Birthday = personImput;
        }
        else
        {
            person.Name = personImput;
        }

        return person;
    }

    private static bool IsBirthday(string input)
    {
        return Char.IsDigit(input[0]);
    }

    public override string ToString()
    {
        return $"{this.Name} {this.Birthday}";
    }
}
