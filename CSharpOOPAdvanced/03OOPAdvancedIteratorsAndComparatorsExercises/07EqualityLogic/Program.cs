﻿using System;
using System.Collections.Generic;

public class Program
{
    static void Main(string[] args)
    {
        SortedSet<Person> sortedPeople = new SortedSet<Person>();
        HashSet<Person> hashPeople = new HashSet<Person>(new PersonEqualityComparer());

        int n = int.Parse(Console.ReadLine());
        for (int i = 0; i < n; i++)
        {
            string[] personData = Console.ReadLine().Split();
            string name = personData[0];
            int age = int.Parse(personData[1]);
            
            Person person = new Person(name, age);
            sortedPeople.Add(person);
            hashPeople.Add(person);
        }

        Console.WriteLine(sortedPeople.Count);
        Console.WriteLine(hashPeople.Count);
    }
}
