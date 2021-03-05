using System;
using System.Linq;

namespace _09Crossfire
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] jaggedDimsions = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();
            int[][] jaggedTarget = new int[jaggedDimsions[0]][];
            int cellNumber = 0;
            for (int i = 0; i < jaggedTarget.Length; i++)
            {                
                jaggedTarget[i] = new int[jaggedDimsions[1]];
                for (int j = 0; j < jaggedTarget[i].Length; j++)
                {
                    cellNumber++;
                    jaggedTarget[i][j] = cellNumber;
                }
            }

            string shotDataString = string.Empty;
            while ((shotDataString = Console.ReadLine()) != "Nuke it from orbit")
            {
                int[] shotData = shotDataString.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse).ToArray();
                jaggedTarget = Shot(jaggedTarget, shotData);
                jaggedTarget = RemoveAffected(jaggedTarget);                
            }

            for (int row = 0; row < jaggedTarget.Length; row++)
            {
                for (int col = 0; col < jaggedTarget[row].Length; col++)
                {
                    Console.Write(jaggedTarget[row][col] + " ");
                }

                Console.WriteLine();
            }
        }

        private static int[][] Shot(int[][] jaggedTarget, int[] shotData)
        {
            int shotRow = shotData[0];
            int shotCol = shotData[1];
            int radius = shotData[2];

            for (int row = 0; row < jaggedTarget.Length; row++)
            {
                for (int col = 0; col < jaggedTarget[row].Length; col++)
                {
                    int distanceRow = Math.Abs(shotRow - row);
                    int distanceCol = Math.Abs(shotCol - col);
                    if (row == shotRow || col == shotCol)
                    {
                        if (IsInjaggedTarget(jaggedTarget, row, col) && distanceRow <= radius && distanceCol <= radius)
                        {
                            jaggedTarget[row][col] = -1;
                        }
                    }
                }
            }

            return jaggedTarget;
        }

        private static bool IsInjaggedTarget(int[][] matrix, int row, int col)
        {
            return row >= 0 && row < matrix.Length && col >= 0 && col < matrix[row].Length;
        }

        private static int[][] RemoveAffected(int[][] jaggedMatrix)
        {
            for (int i = 0; i < jaggedMatrix.Length; i++)
            {
                for (int j = 0; j < jaggedMatrix[i].Length; j++)
                {
                    if (jaggedMatrix[i][j] == -1)
                    {
                        jaggedMatrix[i] = jaggedMatrix[i].Where(x => x != -1).ToArray();
                        break;
                    }
                }

                if (jaggedMatrix[i].Length == 0)
                {
                    jaggedMatrix = jaggedMatrix.Take(i).Concat(jaggedMatrix.Skip(i + 1)).ToArray();
                    i--;
                }
            }

            return jaggedMatrix;
        }        
    }
}
