using System;
using System.Collections.Generic;
using System.Linq;

namespace _02SimpleCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split();
            Stack<string> stack = new Stack<string>(input.Reverse());
            while (stack.Count > 1)
            {
                int first = int.Parse(stack.Pop());
                string operatotion = stack.Pop();
                int second = int.Parse(stack.Pop());
                switch (operatotion)
                {
                    case "+":
                        int sumResult = first + second;
                        stack.Push(sumResult.ToString());
                        break;
                    case "-":
                        int subtractionResult = first - second;
                        stack.Push(subtractionResult.ToString());
                        break;
                }
            }

            Console.WriteLine(stack.Pop());
        }
    }
}
