using System;
using System.Collections.Generic;

namespace _09StackFibonacci
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Stack<long> stack = new Stack<long>();
            stack.Push(0);
            stack.Push(1);
            for (int i = 1; i < n; i++)
            {
                long fibonacciNext = stack.Peek();
                long fibonacciSum = stack.Pop() + stack.Pop();
                stack.Push(fibonacciNext);
                stack.Push(fibonacciSum);
            }
            
            Console.WriteLine(stack.Peek());
        }
    }
}
