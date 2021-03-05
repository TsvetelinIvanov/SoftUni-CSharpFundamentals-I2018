using System;
using System.Collections.Generic;
using System.Linq;

namespace _06TargetPractice
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] stairsDimensions = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();
            int rowsCount = stairsDimensions[0];
            int colsCount = stairsDimensions[1];
            char[,] stairs = new char[rowsCount, colsCount];
            string snakeString = Console.ReadLine();
            Queue<char> snake = new Queue<char>(snakeString);
            for (int row = stairs.GetLength(0) - 1; row >= 0; row--)
            {
                for (int col = stairs.GetLength(1) - 1; col >= 0; col--)
                {
                    stairs[row, col] = snake.Dequeue();
                    snake.Enqueue(stairs[row, col]);
                }

                row--;
                if (row < 0)
                {
                    break;
                }

                for (int col = 0; col < stairs.GetLength(1); col++)
                {
                    stairs[row, col] = snake.Dequeue();
                    snake.Enqueue(stairs[row, col]);
                }
            }

            int[] shotParameters = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();
            stairs = Shot(stairs, shotParameters);
            stairs = Gravity(stairs);

            for (int row = 0; row < stairs.GetLength(0); row++)
            {
                for (int col = 0; col < stairs.GetLength(1); col++)
                {
                    Console.Write(stairs[row, col]);
                }

                Console.WriteLine();
            }
        }

        private static char[,] Shot(char[,] stairs, int[] shotParameters)
        {
            int impactRow = shotParameters[0];
            int impactColumn = shotParameters[1];
            int radius = shotParameters[2];

            for (int row = 0; row < stairs.GetLength(0); row++)
            {
                for (int col = 0; col < stairs.GetLength(1); col++)
                {
                    int rowDistance = impactRow - row;
                    int colDistance = impactColumn - col;
                    double distance = Math.Sqrt(rowDistance * rowDistance + colDistance * colDistance);
                    if (distance <= radius)
                    {
                        stairs[row, col] = ' ';
                    }
                }
            }

            return stairs;
        }

        private static char[,] Gravity(char[,] stairs)
        {            
            while (true)
            {
                bool isFalling = false;
                for (int row = 0; row < stairs.GetLength(0) - 1; row++)
                {
                    for (int col = 0; col < stairs.GetLength(1); col++)
                    {
                        if (stairs[row, col] != ' ' && stairs[row + 1, col] == ' ')
                        {                            
                            stairs[row + 1, col] = stairs[row, col];
                            stairs[row, col] = ' ';
                            isFalling = true;
                        }
                    }
                }

                if (!isFalling)
                {
                    break;
                }                   
            }

            return stairs;
        }        
    }
}
