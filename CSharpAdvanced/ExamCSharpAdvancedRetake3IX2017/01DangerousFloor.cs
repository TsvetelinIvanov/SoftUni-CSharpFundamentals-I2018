using System;
using System.Linq;

namespace _01DangerousFloor
{
    class Program
    {
        private const int BoardSize = 8;
        private static char[,] board;

        static void Main(string[] args)
        {
            board = new char[BoardSize, BoardSize];
            for (int row = 0; row < BoardSize; row++)
            {
                char[] rowValues = Console.ReadLine().Split(',').Select(char.Parse).ToArray();
                for (int col = 0; col < BoardSize; col++)
                {
                    board[row, col] = rowValues[col];
                }
            }

            string command;
            while ((command = Console.ReadLine()) != "END")
            {
                char figureType = command[0];
                int startingRow = int.Parse(command[1].ToString());
                int startingCol = int.Parse(command[2].ToString());
                int targetRow = int.Parse(command[4].ToString());
                int targetCol = int.Parse(command[5].ToString());

                if (!IsFigure(figureType, startingRow, startingCol))
                {
                    Console.WriteLine("There is no such a piece!");
                }
                else if (!IsMoveValid(figureType, startingRow, startingCol, targetRow, targetCol))
                {
                    Console.WriteLine("Invalid move!");
                }
                else if (!IsInBoard(targetRow, targetCol))
                {
                    Console.WriteLine("Move go out of board!");
                }
                else
                {
                    board[targetRow, targetCol] = figureType;
                    board[startingRow, startingCol] = 'x';
                }
            }
        }

        private static bool IsFigure(char figureType, int startingRow, int startingCol)
        {            
            return board[startingRow, startingCol] == figureType;
        }

        private static bool IsMoveValid(char figureType, int startingRow, int startingCol, int targetRow, int targetCol)
        {
            switch (figureType)
            {
                case 'P':
                    return startingRow - 1 == targetRow && startingCol == targetCol;
                case 'B':
                    return Math.Abs(startingRow - targetRow) == Math.Abs(startingCol - targetCol);
                case 'R':
                    return (startingRow == targetRow && startingCol != targetCol) ||
                        (startingRow != targetRow && startingCol == targetCol);
                case 'Q':
                    bool horizontalMove = startingRow == targetRow && startingCol != targetCol;
                    bool verticalMove = startingRow != targetRow && startingCol == targetCol;
                    bool diagonalMove = Math.Abs(startingRow - targetRow) == Math.Abs(startingCol - targetCol);
                    return horizontalMove || verticalMove || diagonalMove;
                case 'K':
                    bool rowMove = Math.Abs(startingRow - targetRow) == 1 && Math.Abs(startingCol - targetCol) == 0;
                    bool colMove = Math.Abs(startingRow - targetRow) == 0 && Math.Abs(startingCol - targetCol) == 1;
                    bool diagonalOneMove = Math.Abs(startingRow - targetRow) == 1 && Math.Abs(startingCol - targetCol) == 1;
                    return rowMove || colMove || diagonalOneMove;
                default:
                    return false;
            }
        }

        private static bool IsInBoard(int row, int col)
        {
            return (row >= 0 && row < board.GetLength(0)) && (col >= 0 && col < board.GetLength(1));
        }
    }
}
