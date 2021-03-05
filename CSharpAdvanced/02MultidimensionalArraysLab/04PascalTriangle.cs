using System;

namespace _04PascalTriangle
{
    class Program
    {
        static void Main(string[] args)
        {
            int height = int.Parse(Console.ReadLine());
            long[][] pascalTriangle = new long[height][];
            int currentWidth = 1;
            for (int row = 0; row < height; row++)
            {
                pascalTriangle[row] = new long[currentWidth];
                long[] currentRow = pascalTriangle[row];
                currentRow[0] = 1;
                currentRow[currentRow.Length - 1] = 1;
                currentWidth++;

                if (currentRow.Length > 2)
                {
                    for (int col = 1; col < currentRow.Length - 1; col++)
                    {
                        long[] previousRow = pascalTriangle[row - 1];
                        long prevoiusRowSum = previousRow[col] + previousRow[col - 1];
                        currentRow[col] = prevoiusRowSum;
                    }
                }
            }

            for (int row = 0; row < pascalTriangle.Length; row++)
            {
                for (int col = 0; col < pascalTriangle[row].Length; col++)
                {
                    Console.Write(pascalTriangle[row][col] + " ");
                }

                Console.WriteLine();
            }
        }
    }
}
