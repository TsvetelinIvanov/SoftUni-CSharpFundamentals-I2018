using System;
using System.Linq;

namespace _03GroupNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();
            int[] sizes = new int[3];
            foreach (int number in numbers)
            {
                int remainder = Math.Abs(number % 3);
                sizes[remainder]++;
            }

            int[][] jaggedArray =
            {
                new int[sizes[0]],
                new int[sizes[1]],
                new int[sizes[2]]
            };

            int[] currentSizes = new int[3];
            foreach (int number in numbers)
            {
                int remainder = Math.Abs(number % 3);
                int index = currentSizes[remainder];
                jaggedArray[remainder][index] = number;
                currentSizes[remainder]++;
            }

            for (int row = 0; row < jaggedArray.Length; row++)
            {
                for (int col = 0; col < jaggedArray[row].Length; col++)
                {
                    Console.Write(jaggedArray[row][col] + " ");
                }

                Console.WriteLine();
            }
        }
    }
}
