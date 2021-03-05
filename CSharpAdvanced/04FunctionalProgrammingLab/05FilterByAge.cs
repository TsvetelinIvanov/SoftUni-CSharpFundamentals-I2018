using System;
using System.Collections.Generic;
using System.Linq;

namespace _05FilterByAge
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<string, int> people = new Dictionary<string, int>();
            for (int i = 0; i < n; i++)
            {
                string[] nameAndAge = Console.ReadLine()
                    .Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries);
                people.Add(nameAndAge[0], int.Parse(nameAndAge[1]));
            }

            string condition = Console.ReadLine();
            int age = int.Parse(Console.ReadLine());
            string format = Console.ReadLine();

            Func<int, bool> tester = CreateTester(condition, age);
            Action<KeyValuePair<string, int>> printer = CreatePrinter(format);
            
            people.Where(p => tester(p.Value)).ToList().ForEach(printer);
        }

        private static Func<int, bool> CreateTester(string condition, int age)
        {
            if (condition == "younger")
            {
                return x => x < age;
            }                
            else if (condition == "older")
            {
                return x => x >= age;
            }
            else
            {
                return null;
            }
        }

        private static Action<KeyValuePair<string, int>> CreatePrinter(string format)
        {
            switch (format)
            {
                case "name":
                    return x => Console.WriteLine(x.Key);
                case "age":
                    return x => Console.WriteLine(x.Value);
                case "name age":
                    return x => Console.WriteLine($"{x.Key} - {x.Value}");
                default:
                    return null;
            }
        }        
    }
}
