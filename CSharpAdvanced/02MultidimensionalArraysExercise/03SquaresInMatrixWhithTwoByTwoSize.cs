using System;
using System.Linq;

namespace _03SquaresInMatrixWhithTwoByTwoSize
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] matrixDimensions = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();
            int rowsCount = matrixDimensions[0];
            int colsCount = matrixDimensions[1];
            char[,] matrix = new char[rowsCount, colsCount];
            for (int row = 0; row < rowsCount; row++)
            {
                char[] rowValues = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(char.Parse).ToArray();
                for (int col = 0; col < colsCount; col++)
                {
                    matrix[row, col] = rowValues[col];
                }
            }

            int counter = 0;
            for (int row = 0; row < matrix.GetLength(0) - 1; row++)
            {
                for (int col = 0; col < matrix.GetLength(1) - 1; col++)
                {
                    if (matrix[row, col] == matrix[row, col + 1] && matrix[row, col + 1] == matrix[row + 1, col] && 
                        matrix[row + 1, col] == matrix[row + 1, col + 1])
                    {
                        counter++;
                    }
                }
            }

            Console.WriteLine(counter);
        }
    }
}
