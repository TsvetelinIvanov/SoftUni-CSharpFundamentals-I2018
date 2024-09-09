using System;
using System.Linq;

namespace _02Monopoly
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] monopolyBoardDimensions = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();
            int rowsCount = monopolyBoardDimensions[0];
            int colsCount = monopolyBoardDimensions[1];
            char[][] monopolyBoard = new char[rowsCount][];
            for (int row = 0; row < monopolyBoard.Length; row++)
            {
                monopolyBoard[row] = Console.ReadLine().ToCharArray();
            }

            int turnsCount = 0;
            int money = 50;
            int hotelsCount = 0;

            for (int row = 0; row < monopolyBoard.Length; row++)
            {
                for (int col = 0; col < monopolyBoard[row].Length; col++)
                {
                    if (monopolyBoard[row][col] == 'H')
                    {
                        hotelsCount++;
                        Console.WriteLine($"Bought a hotel for {money}. Total hotels: {hotelsCount}.");
                        money = 0;
                    }
                    else if (monopolyBoard[row][col] == 'J')
                    {
                        Console.WriteLine($"Gone to jail at turn {turnsCount}.");
                        turnsCount += 2;
                        money += hotelsCount * 10 * 2;
                    }
                    else if (monopolyBoard[row][col] == 'S')
                    {
                        if ((row + 1) * (col + 1) >= money)
                        {
                            Console.WriteLine($"Spent {money} money at the shop.");
                            money = 0;
                        }
                        else
                        {
                            Console.WriteLine($"Spent {(row + 1) * (col + 1)} money at the shop.");
                            money -= ((row + 1) * (col + 1));
                        }
                    }

                    turnsCount++;
                    money += hotelsCount * 10;
                }

                row++;
                if (row >= monopolyBoard.Length)
                {
                    break;
                }

                for (int col = monopolyBoard[row].Length - 1; col >= 0; col--)
                {
                    if (monopolyBoard[row][col] == 'H')
                    {
                        hotelsCount++;
                        Console.WriteLine($"Bought a hotel for {money}. Total hotels: {hotelsCount}.");
                        money = 0;
                    }
                    else if (monopolyBoard[row][col] == 'J')
                    {
                        Console.WriteLine($"Gone to jail at turn {turnsCount}.");
                        turnsCount += 2;
                        money += hotelsCount * 10 * 2;
                    }
                    else if (monopolyBoard[row][col] == 'S')
                    {
                        if ((row + 1) * (col + 1) >= money)
                        {
                            Console.WriteLine($"Spent {money} money at the shop.");
                            money = 0;
                        }
                        else
                        {
                            Console.WriteLine($"Spent {(row + 1) * (col + 1)} money at the shop.");
                            money -= ((row + 1) * (col + 1));
                        }
                    }

                    turnsCount++;
                    money += hotelsCount * 10;
                }
            }

            Console.WriteLine("Turns " + turnsCount);
            Console.WriteLine("Money " + money);
        }
    }
}
