using System;
using System.Collections.Generic;
using System.Linq;

namespace _03CustomMinFunction
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();
            Func<int[], int[]> orderer = nums => nums.OrderBy(n => n).ToArray();
            int minNumber = orderer(numbers).First();
            Console.WriteLine(minNumber);
        }
    }
}
