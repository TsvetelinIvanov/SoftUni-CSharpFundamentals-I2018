using System;
using System.Collections.Generic;

public class Program
{
    static void Main(string[] args)
    {
        List<IPerson> persons = new List<IPerson>();
        List<IResident> residents = new List<IResident>();

        string input;
        while ((input = Console.ReadLine()) != "End")
        {
            string[] citizenData = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            string name = citizenData[0];
            string country = citizenData[1];
            int age = int.Parse(citizenData[2]);
            Citizen citizen = new Citizen(name, country, age);
            persons.Add(citizen);
            residents.Add(citizen);
            //IPerson person = new Citizen(name, country, age);
            //IResident resident = new Citizen(name, country, age);
            //persons.Add(person);
            //residents.Add(resident);
        }

        for (int i = 0; i < persons.Count; i++)
        {
            Console.WriteLine(persons[i].GetName());
            Console.WriteLine(residents[i].GetName());
        }
    }
}