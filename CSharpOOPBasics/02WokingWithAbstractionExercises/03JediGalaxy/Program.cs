using System;
using System.Linq;

public class Program
{
    static void Main()
    {
        int[] dimestions = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse).ToArray();
        int rowsCount = dimestions[0];
        int colsCount = dimestions[1];
        int[,] matrix = new int[rowsCount, colsCount];

        int starValue = 0;
        for (int row = 0; row < rowsCount; row++)
        {
            for (int col = 0; col < colsCount; col++)
            {
                matrix[row, col] = starValue++;
            }
        }

        string command = Console.ReadLine();
        long sum = 0;
        while (command != "Let the Force be with you")
        {
            int[] ivoStartPoint = command.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();
            int[] evilStartPoint = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();
            int evilRow = evilStartPoint[0];
            int evilCol = evilStartPoint[1];
            while (evilRow >= 0 && evilCol >= 0)
            {
                if (IsInMatrix(matrix, evilRow, evilCol))
                {
                    matrix[evilRow, evilCol] = 0;
                }

                evilRow--;
                evilCol--;
            }

            int ivoRow = ivoStartPoint[0];
            int ivoCol = ivoStartPoint[1];
            while (ivoRow >= 0 && ivoCol < matrix.GetLength(1))
            {
                if (IsInMatrix(matrix, ivoRow, ivoCol))
                {
                    sum += matrix[ivoRow, ivoCol];
                }

                ivoRow--;
                ivoCol++;
            }

            command = Console.ReadLine();
        }

        Console.WriteLine(sum);
    }

    private static bool IsInMatrix(int[,] matrix, int row, int col)
    {
        return row >= 0 && row < matrix.GetLength(0) && col >= 0 && col < matrix.GetLength(1);
    }
}
