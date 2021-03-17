using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    static void Main(string[] args)
    {
        try
        {
            List<Person> people = new List<Person>();
            List<Product> products = new List<Product>();
            string[] peopleInput = ReadInput();
            string[] productsInput = ReadInput();
            people = AddPeople(people, peopleInput);
            products = AddProducts(products, productsInput);
            ProcessBuyings(people, products);
            foreach (Person person in people)
            {
                Console.WriteLine(person);
            }
        }
        catch (ArgumentException ae)
        {
            Console.WriteLine(ae.Message);
        }
    }

    private static string[] ReadInput()
    {
        string[] input = Console.ReadLine().Split(';');
        if (input[input.Length - 1] == string.Empty)
        {
            input = input.Take(input.Length - 1).ToArray();
        }

        return input;
    }

    private static List<Person> AddPeople(List<Person> people, string[] peopleInput)
    {
        for (int i = 0; i < peopleInput.Length; i++)
        {
            string name = peopleInput[i].Split('=').First();
            string money = peopleInput[i].Split('=').Last();
            Person person = new Person(name, decimal.Parse(money));
            people.Add(person);
        }

        return people;
    }

    private static List<Product> AddProducts(List<Product> products, string[] productsInput)
    {
        for (int i = 0; i < productsInput.Length; i++)
        {
            string name = productsInput[i].Split('=').First();
            string cost = productsInput[i].Split('=').Last();
            Product product = new Product(name, decimal.Parse(cost));
            products.Add(product);
        }

        return products;
    }

    private static void ProcessBuyings(List<Person> people, List<Product> products)
    {
        string buyingsInput;
        while ((buyingsInput = Console.ReadLine()) != "END")
        {
            try
            {
                string buyingPerson = buyingsInput.Split().First();
                string boughtProduct = buyingsInput.Split().Last();
                Person person = people.First(p => p.Name == buyingPerson);
                Product product = products.First(p => p.Name == boughtProduct);
                if (person.Money >= product.Cost)
                {
                    person.Money -= product.Cost;
                    person.BagOfProducts.Add(product);
                    Console.WriteLine($"{person.Name} bought {product.Name}");
                }
                else
                {
                    Console.WriteLine($"{person.Name} can't afford {product.Name}");
                }

            }
            catch (Exception)
            {
                throw;
            }
        }
    }           
}