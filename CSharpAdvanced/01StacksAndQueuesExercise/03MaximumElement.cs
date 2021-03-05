using System;
using System.Collections.Generic;
using System.Linq;

namespace _03MaximumElement
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Stack<int> stackNumbers = new Stack<int>();
            Stack<int> stackMax = new Stack<int>();
            stackMax.Push(0);
            for (int i = 0; i < n; i++)
            {
                int[] command = Console.ReadLine().Split().Select(int.Parse).ToArray();
                int commandNumber = command[0];
                switch (commandNumber)
                {
                    case 1:
                        int number = command[1];
                        stackNumbers.Push(number);
                        if (number >= stackMax.Peek())
                        {
                            stackMax.Push(number);
                        }

                        break;
                    case 2:
                        if (stackNumbers.Peek() == stackMax.Peek())
                        {
                            stackMax.Pop();
                        }

                        stackNumbers.Pop();
                        break;
                    case 3:
                        Console.WriteLine(stackMax.Peek());
                        break;
                }
            }
        }
    }
}
