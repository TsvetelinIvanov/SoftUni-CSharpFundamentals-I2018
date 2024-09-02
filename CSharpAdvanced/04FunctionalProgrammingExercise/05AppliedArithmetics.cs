using System;
using System.Collections.Generic;
using System.Linq;

namespace _05AppliedArithmetics
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToList();
            Func<int, int> adder = x => x + 1;
            Func<int, int> multiplier = x => x * 2;
            Func<int, int> subtracter = x => x - 1;
            Action<int> printer = x => Console.Write(x + " ");
            
            string command = string.Empty;
            while ((command = Console.ReadLine()) != "end")
            {
                switch (command)
                {
                    case "add":
                    numbers = numbers.Select(x => adder(x)).ToList();
                        break;
                    case "multiply":
                        numbers = numbers.Select(x => multiplier(x)).ToList();
                        break;
                    case "subtract":
                        numbers = numbers.Select(x => subtracter(x)).ToList();
                        break;
                    case "print":
                        numbers.ForEach(printer);
                        Console.WriteLine();
                        break;
                }
            }
        }
    }
}
