using System;
using System.Linq;

namespace _04MaximalSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] matrixDimensions = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();
            int rowsCount = matrixDimensions[0];
            int colsCount = matrixDimensions[1];
            int[,] matrix = new int[rowsCount, colsCount];
            for (int row = 0; row < rowsCount; row++)
            {
                int[] rowValues = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse).ToArray();
                for (int col = 0; col < colsCount; col++)
                {
                    matrix[row, col] = rowValues[col];
                }
            }

            long maxSum = 0;
            int maxSumRow = 0;
            int maxSumCol = 0;
            for (int row = 0; row < matrix.GetLength(0) - 2; row++)
            {
                for (int col = 0; col < matrix.GetLength(1) - 2; col++)
                {
                    long sum = (long)matrix[row, col] + matrix[row, col + 1] + matrix[row, col + 2] +
                        matrix[row + 1, col] + matrix[row + 1, col + 1] + matrix[row + 1, col + 2] +
                        matrix[row + 2, col] + matrix[row + 2, col + 1] + matrix[row + 2, col + 2];
                    if (sum > maxSum)
                    {
                        maxSum = sum;
                        maxSumRow = row;
                        maxSumCol = col;
                    }
                }
            }

            Console.WriteLine("Sum = " + maxSum);
            for (int row = maxSumRow; row < maxSumRow + 3; row++)
            {
                for (int col = maxSumCol; col < maxSumCol + 3; col++)
                {
                    Console.Write(matrix[row, col] + " ");
                }

                Console.WriteLine();
            }
        }
    }
}
