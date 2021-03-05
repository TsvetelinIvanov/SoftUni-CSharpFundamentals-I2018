using System;
using System.Linq;

namespace _01MatrixOfPalindromes
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] alphabet = "abcdefghijklmnopqrstuvwxyz".ToCharArray();
            int[] rowsAndColumns = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int rowsCount = rowsAndColumns[0];
            int columnsCount = rowsAndColumns[1];
            string[,] aphabeticalPalindromes = new string[rowsCount, columnsCount];
            for (int row = 0; row < rowsCount; row++)
            {
                for (int col = 0; col < columnsCount; col++)
                {
                    aphabeticalPalindromes[row, col] = "" + alphabet[row] + alphabet[row + col] + alphabet[row] + " ";
                }
            }

            for (int row = 0; row < aphabeticalPalindromes.GetLength(0); row++)
            {
                for (int col = 0; col < aphabeticalPalindromes.GetLength(1); col++)
                {
                    Console.Write(aphabeticalPalindromes[row, col]);
                }

                Console.WriteLine();
            }
        }
    }
}
