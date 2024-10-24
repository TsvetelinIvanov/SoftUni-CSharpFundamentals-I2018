using System;
using System.Collections.Generic;

public class Program
{
    static void Main(string[] args)
    {
        SortedSet<Person> namePeople = new SortedSet<Person>(new PersonNameComparer());
        SortedSet<Person> agePeople = new SortedSet<Person>(new PersonAgeComparer());

        int n = int.Parse(Console.ReadLine());
        for (int i = 0; i < n; i++)
        {
            string[] personData = Console.ReadLine().Split();
            string name = personData[0];
            int age = int.Parse(personData[1]);
            Person person = new Person(name, age);
            
            namePeople.Add(person);
            agePeople.Add(person);
        }

        Console.WriteLine(string.Join(Environment.NewLine, namePeople));
        Console.WriteLine(string.Join(Environment.NewLine, agePeople));
    }
}
