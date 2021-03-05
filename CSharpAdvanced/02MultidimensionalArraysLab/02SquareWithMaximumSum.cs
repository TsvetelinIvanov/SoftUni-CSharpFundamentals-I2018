using System;
using System.Linq;

namespace _02SquareWithMaximumSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] rowsAndColumns = Console.ReadLine()
                .Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();
            int[,] matrix = new int[rowsAndColumns[0], rowsAndColumns[1]];
            for (int rows = 0; rows < rowsAndColumns[0]; rows++)
            {
                int[] rowValues = Console.ReadLine()
                    .Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse).ToArray();
                for (int columns = 0; columns < rowsAndColumns[1]; columns++)
                {
                    matrix[rows, columns] = rowValues[columns];
                }
            }

            int maxSquareSum = int.MinValue;
            int rowIndex = 0;
            int columnIndex = 0;
            for (int row = 0; row < matrix.GetLength(0) - 1; row++)
            {
                for (int col = 0; col < matrix.GetLength(1) - 1; col++)
                {
                    int currentSquareSum = matrix[row, col] + matrix[row + 1, col] +
                        matrix[row, col + 1] + matrix[row + 1, col + 1];
                    if (currentSquareSum > maxSquareSum)
                    {
                        maxSquareSum = currentSquareSum;
                        rowIndex = row;
                        columnIndex = col;
                    }
                }
            }

            Console.WriteLine(matrix[rowIndex, columnIndex] + " " + matrix[rowIndex, columnIndex + 1]);
            Console.WriteLine(matrix[rowIndex + 1, columnIndex] + " " + matrix[rowIndex + 1, columnIndex + 1]);
            Console.WriteLine(maxSquareSum);
        }
    }
}
