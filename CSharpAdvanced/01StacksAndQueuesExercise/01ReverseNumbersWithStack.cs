using System;
using System.Collections.Generic;

namespace _01ReverseNumbersWithStack
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] numbers = Console.ReadLine().Split();
            Stack<string> stackNumbers = new Stack<string>();
            for (int i = 0; i < numbers.Length; i++)
            {
                stackNumbers.Push(numbers[i]);
            }

            while (stackNumbers.Count > 0)
            {
                Console.Write(stackNumbers.Pop() + " ");
            }

            Console.WriteLine();
        }
    }
}
