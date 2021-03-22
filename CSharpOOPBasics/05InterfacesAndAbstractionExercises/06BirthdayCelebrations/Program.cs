using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    static void Main(string[] args)
    {
        List<IOrganicable> organicCreatures = new List<IOrganicable>();
        string input;
        while ((input = Console.ReadLine()) != "End")
        {
            string[] creatureData = input.Split();
            string creatureType = creatureData[0];
            if (creatureType == "Citizen")
            {
                string name = creatureData[1];
                int age = int.Parse(creatureData[2]);
                string id = creatureData[3];
                string birthDate = creatureData[4];
                Person person = new Person(name, age, id, birthDate);
                organicCreatures.Add(person);
            }
            else if (creatureType == "Pet")
            {
                string name = creatureData[1];
                string birthDate = creatureData[2];
                Pet pet = new Pet(name, birthDate);
                organicCreatures.Add(pet);
            }
        }

        string searchJear = Console.ReadLine();
        List<IOrganicable> searchedOrganicCratures = organicCreatures
            .Where(o => o.BirthDate.EndsWith(searchJear)).ToList();
        foreach (IOrganicable organicCreature in searchedOrganicCratures)
        {
            Console.WriteLine(organicCreature.BirthDate);
        }
    }
}