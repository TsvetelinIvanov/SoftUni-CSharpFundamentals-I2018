using System;
using System.Collections.Generic;

public class Program
{
    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());
        Family family = new Family();
        family.FamilyMembers = new List<Person>();
        for (int i = 0; i < n; i++)
        {
            Person person = new Person();
            string[] nameAndAge = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            person.Name = nameAndAge[0];
            person.Age = int.Parse(nameAndAge[1]);
            family.AddFamilyMember(person);
        }

        Person oldestMember = family.GetOldestMember();
        Console.WriteLine(oldestMember.Name + " " + oldestMember.Age);
    }
}