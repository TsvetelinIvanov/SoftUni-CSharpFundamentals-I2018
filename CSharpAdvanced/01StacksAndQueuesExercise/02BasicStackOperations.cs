using System;
using System.Collections.Generic;
using System.Linq;

namespace _02BasicStackOperations
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] commands = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int pushN = commands[0];
            int popS = commands[1];
            int containsX = commands[2];
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Stack<int> stack = new Stack<int>();
            for (int i = 0; i < Math.Min(pushN, numbers.Length); i++)
            {
                stack.Push(numbers[i]);
            }

            for (int i = 0; i < popS; i++)
            {
                if (stack.Count == 0)
                {
                    break;
                }

                stack.Pop();
            }

            if (stack.Contains(containsX))
            {
                Console.WriteLine("true");
            }
            else if (stack.Count == 0)
            {
                Console.WriteLine(0);
            }
            else
            {
                Console.WriteLine(stack.Min()); 
            }
        }
    }
}
