using System;
using System.Collections.Generic;
using System.Linq;

namespace _09ListOfPredicates
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] divisors = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();
            List<int> numbers = new List<int>();
            for (int i = 1; i <= n; i++)
            {
                numbers.Add(i);
            }

            Func<int, bool> predicate = CreatePredicate(divisors);
            numbers = numbers.Where(predicate).ToList();
            Console.WriteLine(string.Join(" ", numbers));
        }

        private static Func<int, bool> CreatePredicate(int[] divisors)
        {
            return n =>
            {
                foreach (int divisor in divisors)
                {
                    if (n % divisor != 0)
                    {
                        return false;
                    }
                }

                return true;
            };
        }
    }
}
