using System;
using System.Collections.Generic;
using System.Linq;

namespace _11ParkingSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] parkingSize = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();
            int rowsCount = parkingSize[0];
            int colsCount = parkingSize[1];
            Dictionary<int, HashSet<int>> parking = new Dictionary<int, HashSet<int>>();

            string input = string.Empty;
            while ((input = Console.ReadLine()) != "stop")
            {
                int[] carData = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                int entryRow = carData[0];
                int desiredRow = carData[1];
                int desiredCol = carData[2];

                int parkingColumn = 0;
                if (!IsOccupied(parking, desiredRow, desiredCol))
                {
                    parkingColumn = desiredCol;
                }
                else
                {
                    for (int i = 1; i < colsCount - 1; i++)
                    {
                        if (((desiredCol - i) > 0) && !IsOccupied(parking, desiredRow, (desiredCol - i)))
                        {
                            parkingColumn = (desiredCol - i);
                            break;
                        }
                        else if (((desiredCol + i) < colsCount) && !IsOccupied(parking, desiredRow, (desiredCol + i)))
                        {
                            parkingColumn = (desiredCol + i);
                            break;
                        }
                    }
                }

                if (parkingColumn == 0)
                {
                    Console.WriteLine($"Row {desiredRow} full");
                }
                else
                {
                    parking[desiredRow].Add(parkingColumn);
                    int travelledSpotsAmount = Math.Abs(entryRow - desiredRow) + 1 + parkingColumn;
                    Console.WriteLine(travelledSpotsAmount);
                }
            }
        }

        private static bool IsOccupied(Dictionary<int, HashSet<int>> parking, int row, int col)
        {
            if (parking.ContainsKey(row))
            {
                if (parking[row].Contains(col))
                {
                    return true;
                }
            }
            else
            {
                parking.Add(row, new HashSet<int>());
            }

            return false;
        }
    }
}
