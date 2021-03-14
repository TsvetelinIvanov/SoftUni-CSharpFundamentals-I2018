using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    static void Main(string[] args)
    {
        List<Person> people = CollectDataForPeople();
        string name = Console.ReadLine();
        Person person = people.Single(p => p.Name == name);
        Console.Write(person);
    }

    private static List<Person> CollectDataForPeople()
    {
        List<Person> people = new List<Person>();
        string input = string.Empty;
        while ((input = Console.ReadLine()) != "End")
        {
            string[] personData = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            string name = personData[0];
            if (!people.Any(p => p.Name == name))
            {
                Person person1 = new Person(name);
                people.Add(person1);
            }

            Person person = people.Single(p => p.Name == name);
            CollectDataForPerson(person, personData);
        }

        return people;
    }

    private static void CollectDataForPerson(Person person, string[] personData)
    {
        switch (personData[1])
        {
            case "company":
                string companyName = personData[2];
                string department = personData[3];
                decimal salary = decimal.Parse(personData[4]);
                Company company = new Company(companyName, department, salary);
                person.Company = company;
                break;
            case "car":
                string model = personData[2];
                int speed = int.Parse(personData[3]);
                Car car = new Car(model, speed);
                person.Car = car;
                break;
            case "pokemon":
                string pokemonName = personData[2];
                string pokemonType = personData[3];
                Pokemon pokemon = new Pokemon(pokemonName, pokemonType);
                person.Pokemons.Add(pokemon);
                break;
            case "parents":
                string parentName = personData[2];
                string parentBirthday = personData[3];
                Parent parent = new Parent(parentName, parentBirthday);
                person.Parents.Add(parent);
                break;
            case "children":
                string childName = personData[2];
                string childBirthday = personData[3];
                Child child = new Child(childName, childBirthday);
                person.Children.Add(child);
                break;
            default:
                break;
        }
    }
}