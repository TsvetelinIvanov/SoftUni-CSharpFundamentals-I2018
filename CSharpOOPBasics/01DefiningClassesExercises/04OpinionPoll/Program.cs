using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    static void Main(string[] args)
    {
        List<Person> people = new List<Person>();
        int n = int.Parse(Console.ReadLine());
        for (int i = 0; i < n; i++)
        {
            Person person = new Person();
            string[] nameAndAge = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            person.Name = nameAndAge[0];
            person.Age = int.Parse(nameAndAge[1]);
            people.Add(person);
        }

        foreach (Person person in people.Where(p => p.Age > 30).OrderBy(p => p.Name))
        {
            Console.WriteLine("{0} - {1}", person.Name, person.Age);
        }
    }
}
