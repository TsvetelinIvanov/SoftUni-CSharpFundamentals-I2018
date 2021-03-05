using System;
using System.Linq;

namespace _06ReverseAndExclude
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();
            int n = int.Parse(Console.ReadLine());
            Array.Reverse(numbers);
            Func<int, bool> filter = x => x % n != 0;
            numbers = numbers.Where(filter).ToArray();
            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}
