using System;
using System.Linq;

namespace _07LegoBlocks
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[][] block1 = new int[n][];
            for (int i = 0; i < n; i++)
            {
                block1[i] = Console.ReadLine().Trim()
                    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse).ToArray();
            }

            int[][] block2 = new int[n][];
            for (int i = 0; i < n; i++)
            {
                block2[i] = Console.ReadLine().Trim()
                    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse).ToArray();
                block2[i] = block2[i].Reverse().ToArray();
            }

            bool areEqual = true;
            int[][] matchedBlock = new int[n][];
            for (int i = 0; i < matchedBlock.Length; i++)
            {
                matchedBlock[i] = new int[block1[i].Length + block2[i].Length];
                for (int j = 0; j < block1[i].Length; j++)
                {
                    matchedBlock[i][j] = block1[i][j];
                }

                for (int j = 0; j < block2[i].Length; j++)
                {
                    matchedBlock[i][block1[i].Length + j] = block2[i][j];
                }               
            }

            for (int i = 0; i < matchedBlock.Length - 1; i++)
            {
                if (matchedBlock[i].Length != matchedBlock[i + 1].Length)
                {
                    areEqual = false;
                }
            }

            if (areEqual)
            {
                for (int i = 0; i < matchedBlock.Length; i++)
                {
                    Console.WriteLine($"[{string.Join(", ", matchedBlock[i])}]");
                }
            }
            else
            {
                int cellsCount = 0;
                for (int i = 0; i < matchedBlock.Length; i++)
                {
                    cellsCount += matchedBlock[i].Length;
                }

                Console.WriteLine("The total number of cells is: " + cellsCount);
            }
        }
    }
}
