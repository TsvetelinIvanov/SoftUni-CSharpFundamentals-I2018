using System;
using System.Linq;

namespace _02DiagonalDifference
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            int[,] squareMatrix = new int[size, size];
            for (int row = 0; row < size; row++)
            {
                int[] rowValues = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse).ToArray();
                for (int col = 0; col < size; col++)
                {
                    squareMatrix[row, col] = rowValues[col];
                }
            }

            int firstDiagonalSum = 0;
            int secondDiagonalSum = 0;
            for (int row = 0; row < squareMatrix.GetLength(0); row++)
            {
                for (int col = 0; col < squareMatrix.GetLength(1); col++)
                {
                    if (row == col)
                    {
                        firstDiagonalSum += squareMatrix[row, col];
                        secondDiagonalSum += squareMatrix[row, squareMatrix.GetLength(1) - col - 1];
                    }
                }
            }

            int diagonalDifference = Math.Abs(firstDiagonalSum - secondDiagonalSum);
            Console.WriteLine(diagonalDifference);
        }
    }
}
