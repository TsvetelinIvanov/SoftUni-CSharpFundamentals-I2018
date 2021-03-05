using System;
using System.Collections.Generic;
using System.Linq;

namespace _02KnightsOfHonor
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> names = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .ToList();
            Action<string> honorPrinter = name => Console.WriteLine($"Sir {name}");
            names.ForEach(n => honorPrinter(n));
        }
    }
}
