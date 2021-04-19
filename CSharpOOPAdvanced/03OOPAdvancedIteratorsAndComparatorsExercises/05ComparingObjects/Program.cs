using System;
using System.Collections.Generic;

public class Program
{
    static void Main(string[] args)
    {
        List<Person> people = new List<Person>();

        string input;
        while ((input = Console.ReadLine()) != "END")
        {
            string[] personData = input.Split();
            string name = personData[0];
            int age = int.Parse(personData[1]);
            string town = personData[2];
            Person person = new Person(name, age, town);
            people.Add(person);
        }

        int personToComparingIndex = int.Parse(Console.ReadLine());
        Person personToComparing = people[personToComparingIndex - 1];

        int matchesCounter = 0;
        foreach (Person person in people)
        {
            int comparingResult = personToComparing.CompareTo(person);
            if (comparingResult == 0)
            {
                matchesCounter++;
            }

        }

        if (matchesCounter == 1)
        {
            Console.WriteLine("No matches");
        }
        else
        {
            Console.WriteLine($"{matchesCounter} {people.Count - matchesCounter} {people.Count}");
        }
    }
}