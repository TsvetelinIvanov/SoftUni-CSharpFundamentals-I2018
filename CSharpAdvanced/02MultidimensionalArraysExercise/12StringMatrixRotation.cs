using System;
using System.Collections.Generic;

namespace _12StringMatrixRotation
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] rotationString = Console.ReadLine().Split(new char[] { ' ', '(', ')' }, StringSplitOptions.RemoveEmptyEntries);
            int rotation = int.Parse(rotationString[1]);
            rotation %= 360;
            List<string> inputStrings = new List<string>();
            int maxLength = 0;
            string input = string.Empty;
            while ((input = Console.ReadLine()) != "END")
            {
                int length = input.Length;
                if (length > maxLength)
                {
                    maxLength = length;
                }

                inputStrings.Add(input);
            }

            char[,] matrix = new char[inputStrings.Count, maxLength];
            for (int row = 0; row < inputStrings.Count; row++)
            {
                inputStrings[row] = inputStrings[row] + $"{new string(' ', maxLength - inputStrings[row].Length)}";
                char[] rowValues = inputStrings[row].ToCharArray();
                for (int col = 0; col < maxLength; col++)
                {
                    matrix[row, col] = rowValues[col];
                }
            }

            switch (rotation)
            {
                case 0:
                    for (int row = 0; row < matrix.GetLength(0); row++)
                    {
                        for (int col = 0; col < matrix.GetLength(1); col++)
                        {
                            Console.Write(matrix[row, col]);
                        }

                        Console.WriteLine();
                    }

                    break;
                case 90:
                    for (int col = 0; col < matrix.GetLength(1); col++)
                    {
                        for (int row = matrix.GetLength(0) - 1; row >= 0; row--)
                        {
                            Console.Write(matrix[row, col]);
                        }

                        Console.WriteLine();
                    }

                    break;
                case 180:
                    for (int row = matrix.GetLength(0) - 1; row >= 0; row--)
                    {
                        for (int col = matrix.GetLength(1) - 1; col >= 0; col--)
                        {
                            Console.Write(matrix[row, col]);
                        }

                        Console.WriteLine();
                    }

                    break;
                case 270:
                    for (int col = matrix.GetLength(1) - 1; col >= 0; col--)
                    {
                        for (int row = 0; row < matrix.GetLength(0); row++)
                        {
                            Console.Write(matrix[row, col]);
                        }

                        Console.WriteLine();
                    }

                    break;
            }
        }
    }
}
