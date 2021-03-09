using System;

namespace _02KnightGame
{
    class Program
    {
        static void Main(string[] args)
        {
            int boardSize = int.Parse(Console.ReadLine());
            char[,] board = new char[boardSize, boardSize];
            for (int row = 0; row < boardSize; row++)
            {
                char[] rowValues = Console.ReadLine().ToCharArray();
                for (int col = 0; col < boardSize; col++)
                {
                    board[row, col] = rowValues[col];
                }
            }

            int removedKnightCount = 0;
            int attacksMaxCount = 0;
            int maxAttackerRow = 0;
            int maxAttackerCol = 0;

            do
            {
                if (attacksMaxCount > 0)
                {
                    board[maxAttackerRow, maxAttackerCol] = '0';
                    removedKnightCount++;
                    attacksMaxCount = 0;
                }

                int attacksCount = 0;
                for (int row = 0; row < boardSize; row++)
                {
                    for (int col = 0; col < boardSize; col++)
                    {
                        if (board[row, col] == 'K')
                        {
                            attacksCount = CountAttacks(board, row, col);
                            if (attacksCount > attacksMaxCount)
                            {
                                attacksMaxCount = attacksCount;
                                maxAttackerRow = row;
                                maxAttackerCol = col;
                            }
                        }
                    }
                }

            } while (attacksMaxCount > 0);

            Console.WriteLine(removedKnightCount);
        }

        private static int CountAttacks(char[,] board, int row, int col)
        {
            int attacksCount = 0;
            if (IsAttacked(board, row - 2, col - 1))
            {
                attacksCount++;
            }

            if (IsAttacked(board, row - 2, col + 1))
            {
                attacksCount++;
            }

            if (IsAttacked(board, row - 1, col - 2))
            {
                attacksCount++;
            }

            if (IsAttacked(board, row - 1, col + 2))
            {
                attacksCount++;
            }

            if (IsAttacked(board, row + 1, col - 2))
            {
                attacksCount++;
            }

            if (IsAttacked(board, row + 1, col + 2))
            {
                attacksCount++;
            }

            if (IsAttacked(board, row + 2, col - 1))
            {
                attacksCount++;
            }

            if (IsAttacked(board, row + 2, col + 1))
            {
                attacksCount++;
            }

            return attacksCount;
        }

        private static bool IsAttacked(char[,] board, int row, int col)
        {
            return IsInBoard(board, row, col) && board[row, col] == 'K';
        }

        private static bool IsInBoard(char[,] board, int row, int col)
        {
            return (row >= 0 && row < board.GetLength(0)) && (col >= 0 && col < board.GetLength(1));
        }
    }
}
