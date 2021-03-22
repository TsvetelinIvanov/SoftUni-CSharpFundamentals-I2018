using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    static void Main(string[] args)
    {
        List<Person> buyers = GetBuyers();
        ProcessBuyings(buyers);
        int boughtFood = buyers.Select(b => b.Food).Sum();
        Console.WriteLine(boughtFood);
    }

    private static List<Person> GetBuyers()
    {
        List<Person> buyers = new List<Person>();
        int buyersCount = int.Parse(Console.ReadLine());
        for (int i = 0; i < buyersCount; i++)
        {
            string[] buyerData = Console.ReadLine().Split();
            string name = buyerData[0];
            int age = int.Parse(buyerData[1]);
            if (buyerData.Length == 4)
            {
                string id = buyerData[2];
                string birthDate = buyerData[3];
                Citizen person = new Citizen(name, age, id, birthDate);
                buyers.Add(person);
            }
            else if (buyerData.Length == 3)
            {
                string group = buyerData[2];
                Rebel rebel = new Rebel(name, age, group);
                buyers.Add(rebel);
            }
        }

        return buyers;
    }

    private static void ProcessBuyings(List<Person> buyers)
    {
        string name;
        while ((name = Console.ReadLine()) != "End")
        {
            if (buyers.Any(b => b.Name == name))
            {
                Person buyer = buyers.Single(b => b.Name == name);
                buyer.BuyFood();
            }            
        }
    }    
}