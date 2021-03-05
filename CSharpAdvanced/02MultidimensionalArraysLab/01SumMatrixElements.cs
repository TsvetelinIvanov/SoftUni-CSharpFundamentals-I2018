using System;
using System.Linq;

namespace _01SumMatrixElements
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] rowsAndColumns = Console.ReadLine().Split(new[] { ", " }, StringSplitOptions.None)
                .Select(int.Parse).ToArray();
            int rowsCount = rowsAndColumns[0];
            int columnsCount = rowsAndColumns[1];
            int[,] matrix = new int[rowsCount, columnsCount];
            for (int rows = 0; rows < rowsCount; rows++)
            {
                int[] rowValues = Console.ReadLine().Split(new[] { ", " }, StringSplitOptions.None)
                .Select(int.Parse).ToArray();
                for (int columns = 0; columns < columnsCount; columns++)
                {
                    matrix[rows, columns] = rowValues[columns];
                }
            }

            int sum = 0;
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    sum += matrix[row, col];
                }
            }

            Console.WriteLine(matrix.GetLength(0));
            Console.WriteLine(matrix.GetLength(1));
            Console.WriteLine(sum);
        }
    }
}
