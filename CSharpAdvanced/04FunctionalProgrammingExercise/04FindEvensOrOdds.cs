using System;
using System.Collections.Generic;
using System.Linq;

namespace _04FindEvensOrOdds
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbersStartAndEnd = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();
            int startNumber = numbersStartAndEnd[0];
            int endNumber = numbersStartAndEnd[1];
            string command = Console.ReadLine();
            List<int> numbers = new List<int>();
            Func<int, bool> evenOrOddChecker = CreateEvenOrOddChecker(command);
            for (int i = startNumber; i <= endNumber; i++)
            {
                if (evenOrOddChecker(i))
                {
                    numbers.Add(i);
                }
            }

            Console.WriteLine(string.Join(" ", numbers));
        }

        private static Func<int, bool> CreateEvenOrOddChecker(string command)
        {
            switch (command)
            {
                case "even":
                    return x => x % 2 == 0;
                case "odd":
                    return x => x % 2 != 0;
                default:
                    return null;
            }
        }
    }
}
