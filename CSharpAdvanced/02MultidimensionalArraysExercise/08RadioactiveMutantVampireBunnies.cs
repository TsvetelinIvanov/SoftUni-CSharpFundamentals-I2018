using System;
using System.Collections.Generic;
using System.Linq;

namespace _08RadioactiveMutantVampireBunnies
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] lairDimensions = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();
            int rowsCount = lairDimensions[0];
            int colsCount = lairDimensions[1];
            char[,] lair = new char[rowsCount, colsCount];
            char[,] bunnyLair = new char[rowsCount, colsCount];
            int[] playerPosition = new int[2];
            for (int row = 0; row < rowsCount; row++)
            {
                char[] rowValues = Console.ReadLine().ToCharArray();
                for (int col = 0; col < colsCount; col++)
                {
                    lair[row, col] = rowValues[col];
                    bunnyLair[row, col] = rowValues[col];
                    if (lair[row, col] == 'P')
                    {
                        playerPosition[0] = row;
                        playerPosition[1] = col;
                    }
                }
            }

            Queue<char> directions = new Queue<char>(Console.ReadLine().ToCharArray());
            bool isDead = false;
            bool isWon = false;
            int lastCellRow = 0;
            int lastCellCol = 0;           

            while (true)
            {
                char moving = directions.Dequeue();                
                switch (moving)
                {                    
                    case 'U':
                        int row = playerPosition[0];
                        int col = playerPosition[1];
                        if (row == 0)
                        {
                            isWon = true;
                            lastCellRow = row;
                            lastCellCol = col;
                            lair[row, col] = '.';
                            bunnyLair[row, col] = '.';
                        }
                        else if (lair[row - 1, col] == 'B')
                        {
                            isDead = true;
                            lastCellRow = row - 1;
                            lastCellCol = col;
                            lair[row, col] = '.';
                            bunnyLair[row, col] = '.';
                        }
                        else if (lair[row - 1, col] == '.')
                        {                           
                            lair[row - 1, col] = 'P';
                            bunnyLair[row - 1, col] = 'P';
                            lair[row, col] = '.';
                            bunnyLair[row, col] = '.';
                            playerPosition[0] = row - 1;
                        }

                        break;
                    case 'D':
                        row = playerPosition[0];
                        col = playerPosition[1];
                        if (row == lair.GetLength(0) - 1)
                        {
                            isWon = true;
                            lastCellRow = row;
                            lastCellCol = col;
                            lair[row, col] = '.';
                            bunnyLair[row, col] = '.';
                        }
                        else if (lair[row + 1, col] == 'B')
                        {
                            isDead = true;
                            lastCellRow = row + 1;
                            lastCellCol = col;
                            lair[row, col] = '.';
                            bunnyLair[row, col] = '.';
                        }
                        else if (lair[row + 1, col] == '.')
                        {                            
                            lair[row + 1, col] = 'P';
                            bunnyLair[row + 1, col] = 'P';
                            lair[row, col] = '.';
                            bunnyLair[row, col] = '.';
                            playerPosition[0] = row + 1;                            
                        }

                        break;
                    case 'L':
                        row = playerPosition[0];
                        col = playerPosition[1];
                        if (col == 0)
                        {
                            isWon = true;
                            lastCellRow = row;
                            lastCellCol = col;
                            lair[row, col] = '.';
                            bunnyLair[row, col] = '.';
                        }
                        else if (lair[row, col - 1] == 'B')
                        {
                            isDead = true;
                            lastCellRow = row;
                            lastCellCol = col - 1;
                            lair[row, col] = '.';
                            bunnyLair[row, col] = '.';
                        }
                        else if (lair[row, col - 1] == '.')
                        {                            
                            lair[row, col - 1] = 'P';
                            bunnyLair[row, col - 1] = 'P';
                            lair[row, col] = '.';
                            bunnyLair[row, col] = '.';
                            playerPosition[1] = col - 1;
                        }

                        break;
                    case 'R':
                        row = playerPosition[0];
                        col = playerPosition[1];
                        if (col == lair.GetLongLength(1) - 1)
                        {
                            isWon = true;
                            lastCellRow = row;
                            lastCellCol = col;
                            lair[row, col] = '.';
                            bunnyLair[row, col] = '.';
                        }
                        else if (lair[row, col + 1] == 'B')
                        {
                            isDead = true;
                            lastCellRow = row;
                            lastCellCol = col + 1;
                            lair[row, col] = '.';
                            bunnyLair[row, col] = '.';
                        }
                        else if (lair[row, col + 1] == '.')
                        {                            
                            lair[row, col + 1] = 'P';
                            bunnyLair[row, col + 1] = 'P';
                            lair[row, col] = '.';
                            bunnyLair[row, col] = '.';
                            playerPosition[1] = col + 1;
                        }

                        break;
                }                

                for (int row = 0; row < lair.GetLength(0); row++)
                {
                    for (int col = 0; col < lair.GetLength(1); col++)
                    {
                        if (lair[row, col] == 'B')
                        {
                            if (IsInLair(lair, row - 1, col))
                            {
                                if (lair[row - 1, col] == 'P')
                                {
                                    isDead = true;
                                    lastCellRow = row - 1;
                                    lastCellCol = col;
                                }

                                bunnyLair[row - 1, col] = 'B';
                            }

                            if (IsInLair(lair, row + 1, col))
                            {
                                if (lair[row + 1, col] == 'P')
                                {
                                    isDead = true;
                                    lastCellRow = row + 1;
                                    lastCellCol = col;
                                }

                                bunnyLair[row + 1, col] = 'B';
                            }

                            if (IsInLair(lair, row, col + 1))
                            {
                                if (lair[row, col + 1] == 'P')
                                {
                                    isDead = true;
                                    lastCellRow = row;
                                    lastCellCol = col + 1;
                                }

                                bunnyLair[row, col + 1] = 'B';
                            }

                            if(IsInLair(lair, row, col - 1))
                            {
                                if (lair[row, col - 1] == 'P')
                                {
                                    isDead = true;
                                    lastCellRow = row;
                                    lastCellCol = col - 1;
                                }

                                bunnyLair[row, col - 1] = 'B';
                            }                           
                        }
                    }
                }               

                for (int row = 0; row < lair.GetLength(0); row++)
                {
                    for (int col = 0; col < lair.GetLength(1); col++)
                    {
                        lair[row, col] = bunnyLair[row, col];
                    }
                }

                if (isDead || isWon)
                {
                    break;
                }                   
            }

            for (int row = 0; row < lair.GetLength(0); row++)
            {
                for (int col = 0; col < lair.GetLength(1); col++)
                {
                    Console.Write(lair[row, col]);
                }

                Console.WriteLine();
            }

            if (isWon)
            {
                Console.WriteLine("won: " + lastCellRow + " " + lastCellCol);
            }
            else if (isDead)
            {
                Console.WriteLine("dead: " + lastCellRow + " " + lastCellCol);
            }
        }

        private static bool IsInLair(char[,] matrix, int row, int col)
        {
            return row >= 0 && row < matrix.GetLength(0) && col >= 0 && col < matrix.GetLength(1);
        }
    }
}
