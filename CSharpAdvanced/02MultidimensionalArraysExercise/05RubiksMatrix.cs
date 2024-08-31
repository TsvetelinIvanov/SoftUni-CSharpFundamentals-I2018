using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _05RubiksMatrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] dimensions = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[][] rubiksMatrix = new int[dimensions[0]][].Select(r => r = new int[dimensions[1]]).ToArray();
            int cellValue = 1;
            for (int i = 0; i < rubiksMatrix.Length; i++)
            {
                for (int j = 0; j < rubiksMatrix[i].Length; j++)
                {
                    rubiksMatrix[i][j] = cellValue;
                    cellValue++;
                }
            }

            int commandsCount = int.Parse(Console.ReadLine());
            for (int i = 0; i < commandsCount; i++)
            {
                string[] command = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                int index = int.Parse(command[0]);
                string direction = command[1];
                int moviengsCount = int.Parse(command[2]);
                switch (direction.ToLower())
                {
                    case "up":
                        int row = moviengsCount % rubiksMatrix.Length;
                        if (row != 0)
                        {
                            MoveRow(rubiksMatrix, index, row);
                        }

                        break;
                    case "down":
                        row = (moviengsCount % rubiksMatrix.Length == 0) ? 0 : rubiksMatrix.Length - (moviengsCount % rubiksMatrix.Length);
                        if (row != 0)
                        {
                            MoveRow(rubiksMatrix, index, row);
                        }

                        break;
                    case "left":
                        int column = moviengsCount % rubiksMatrix[index].Length;
                        if (column != 0)
                        {
                            MoveColumn(rubiksMatrix, index, column);
                        }

                        break;
                    case "right":
                        column = (moviengsCount % rubiksMatrix[index].Length == 0) ? 0 : rubiksMatrix[index].Length - (moviengsCount % rubiksMatrix[index].Length);
                        if (column != 0)
                        {
                            MoveColumn(rubiksMatrix, index, column);
                        }

                        break;
                    default:
                        break;
                }
            }

            StringBuilder rearangedReport = new StringBuilder();
            int expectedValue = 1;
            for (int row = 0; row < rubiksMatrix.Length; row++)
            {
                for (int col = 0; col < rubiksMatrix[row].Length; col++)
                {
                    if (rubiksMatrix[row][col] != expectedValue)
                    {
                        string swaping = Swap(rubiksMatrix, row, col, expectedValue);
                        rearangedReport.Append(swaping);
                    }
                    else
                    {
                        rearangedReport.Append("No swap required" + Environment.NewLine);
                    }

                    expectedValue++;
                }
            }

            Console.Write(rearangedReport);            
        }

        private static void MoveRow(int[][] rubiksMatrix, int index, int row)
        {
            Queue<int> newValues = new Queue<int>(rubiksMatrix.Length);
            while (newValues.Count < rubiksMatrix.Length)
            {
                if (row == rubiksMatrix.Length)
                {
                    row = 0;
                }

                newValues.Enqueue(rubiksMatrix[row][index]);
                row++;
            }

            for (int i = 0; i < rubiksMatrix.Length; i++)
            {
                rubiksMatrix[i][index] = newValues.Dequeue();
            }
        }

        private static void MoveColumn(int[][] rubiksMatrix, int index, int column)
        {
            Queue<int> newValues = new Queue<int>(rubiksMatrix[index].Length);
            for (int i = 0; i < rubiksMatrix.Length; i++)
            {
                if (column == rubiksMatrix[i].Length)
                {
                    column = 0;
                }

                newValues.Enqueue(rubiksMatrix[index][column]);
                column++;
            }

            rubiksMatrix[index] = newValues.ToArray();
        }

        private static string Swap(int[][] rubicMatrix, int row, int col, int expectedValue)
        {
            for (int expectedRow = row; expectedRow < rubicMatrix.Length; expectedRow++)
            {
                for (int expectedCol = 0; expectedCol < rubicMatrix[expectedRow].Length; expectedCol++)
                {
                    if (rubicMatrix[expectedRow][expectedCol] == expectedValue)
                    {
                        int temporalValue = rubicMatrix[expectedRow][expectedCol];
                        rubicMatrix[expectedRow][expectedCol] = rubicMatrix[row][col];
                        rubicMatrix[row][col] = temporalValue;

                        return $"Swap ({row}, {col}) with ({expectedRow}, {expectedCol}){Environment.NewLine}";
                    }
                }
            }

            return string.Empty;
        }                
    }
}
