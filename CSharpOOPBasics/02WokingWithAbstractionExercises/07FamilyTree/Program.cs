﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Program
{
    public static void Main()
    {
        string searchedPerson = Console.ReadLine();
        List<Person> allPeople = new List<Person>();
        CollectData(allPeople);
        PrintParentsAndChildren(allPeople, searchedPerson);
    }

    private static void CollectData(List<Person> allPeople)
    {
        string inputLine;
        while ((inputLine = Console.ReadLine()) != "End")
        {
            if (inputLine.Contains("-"))
            {
                string[] tokens = inputLine.Split('-').Select(x => x.Trim()).ToArray();
                string parentParam = tokens[0];
                string childParam = tokens[1];
                
                Person parent = allPeople.FirstOrDefault(p => (parentParam.Contains("/")) ? p.BirthDate == parentParam : p.Name == parentParam);
                if (parent == null)
                {
                    parent = (parentParam.Contains("/")) ? new Person { BirthDate = parentParam } : new Person { Name = parentParam };
                    allPeople.Add(parent);
                }
                                
                Person child = (childParam.Contains("/")) ? new Person { BirthDate = childParam } : new Person { Name = childParam };
                parent.AddChild(child);
            }
            else
            {
                string[] personData = inputLine.Split();
                string name = $"{personData[0]} {personData[1]}";
                string date = personData[2];
                bool added = false;

                for (int i = 0; i < allPeople.Count; i++)
                {
                    if (allPeople[i].Name == name)
                    {
                        allPeople[i].BirthDate = date;
                        added = true;
                    }

                    if (allPeople[i].BirthDate == date)
                    {
                        allPeople[i].Name = name;
                        added = true;
                    }

                    allPeople[i].AddChildrenInfo(name, date);
                }

                if (!added)
                {
                    allPeople.Add(new Person(name, date));
                }
            }
        }
    }

    private static void PrintParentsAndChildren(List<Person> allPeople, string searchedPersonParam)
    {
        Person person = allPeople.FirstOrDefault(p => (searchedPersonParam.Contains("/")) ? p.BirthDate == searchedPersonParam : p.Name == searchedPersonParam);

        StringBuilder familyTreeBuilder = new StringBuilder();
        familyTreeBuilder.AppendLine($"{person.Name} {person.BirthDate}");

        familyTreeBuilder.AppendLine("Parents:");
        foreach (Person parent in allPeople.Where(p => p.FindChildName(person.Name) != null))
        {
            familyTreeBuilder.AppendLine($"{parent.Name} {parent.BirthDate}");
        }

        familyTreeBuilder.AppendLine("Children:");
        foreach (Person child in allPeople.FirstOrDefault(p => p.Name == person.Name).Children)
        {
            familyTreeBuilder.AppendLine($"{child.Name} {child.BirthDate}");
        }

        Console.WriteLine(familyTreeBuilder);
    }    
}
