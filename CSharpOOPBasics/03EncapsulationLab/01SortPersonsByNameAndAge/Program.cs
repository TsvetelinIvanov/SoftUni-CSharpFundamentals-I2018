using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    static void Main(string[] args)
    {
        int personsCount = int.Parse(Console.ReadLine());
        List<Person> persons = new List<Person>();
        for (int i = 0; i < personsCount; i++)
        {
            string[] input = Console.ReadLine().Split();
            Person person = new Person(input[0], input[1], int.Parse(input[2]));
            persons.Add(person);
        }

        persons.OrderBy(p => p.FirstName).ThenBy(p => p.Age).ToList().ForEach(p => Console.WriteLine(p.ToString()));
    }
}
