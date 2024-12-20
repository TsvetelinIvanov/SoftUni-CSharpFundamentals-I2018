using System;

namespace _08RecursiveFibonacci
{
    class Program
    {
        static long[] numbers;
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());            
            numbers = new long[n + 2];
            numbers[1] = 1;
            numbers[2] = 1;
            long fibonacciNumber = Fibonacci(n);            
            Console.WriteLine(fibonacciNumber);
        }

        static long Fibonacci(int n)
        {
            if (numbers[n] == 0)
            {
                numbers[n] = Fibonacci(n - 1) + Fibonacci(n - 2);
            }

            return numbers[n];
        }
    }
}
