using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    static void Main(string[] args)
    {
        List<Cat> cats = ReadCatsInfo();
        Cat cat = GetCat(cats);
        Console.WriteLine(cat);
    }

    private static List<Cat> ReadCatsInfo()
    {
        List<Cat> cats = new List<Cat>();
        string input;
        while ((input = Console.ReadLine()) != "End")
        {
            string[] catsInfo = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            string breed = catsInfo[0];
            string name = catsInfo[1];
            double characteristicValue = double.Parse(catsInfo[2]);
            Cat cat = new Cat(name, breed, characteristicValue);
            cats.Add(cat);
        }

        return cats;
    }

    private static Cat GetCat(List<Cat> cats)
    {
        string name = Console.ReadLine();
        Cat cat = cats.First(c => c.Name == name);

        return cat;
    }    
}