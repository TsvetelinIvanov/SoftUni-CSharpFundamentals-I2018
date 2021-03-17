using System;

public class Sneaking
{
    static char[][] room;
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        room = new char[n][];
        int[] samPosition = new int[2];
        for (int row = 0; row < n; row++)
        {            
            room[row] = Console.ReadLine().ToCharArray();
            for (int col = 0; col < room[row].Length; col++)
            {
                if (room[row][col] == 'S')
                {
                    samPosition[0] = row;
                    samPosition[1] = col;
                }
            }
        }

        char[] moves = Console.ReadLine().ToCharArray();       
        for (int i = 0; i < moves.Length; i++)
        {
            for (int row = 0; row < room.Length; row++)
            {
                for (int col = 0; col < room[row].Length; col++)
                {
                    if (room[row][col] == 'b')
                    {
                        if (IsInRoom(room, row, col + 1))
                        {
                            room[row][col] = '.';
                            room[row][col + 1] = 'b';
                            col++;
                        }
                        else
                        {
                            room[row][col] = 'd';
                        }
                    }
                    else if (room[row][col] == 'd')
                    {
                        if (IsInRoom(room, row, col - 1))
                        {
                            room[row][col] = '.';
                            room[row][col - 1] = 'd';
                        }
                        else
                        {
                            room[row][col] = 'b';
                        }
                    }
                }
            }

            int[] getEnemy = new int[2];
            for (int j = 0; j < room[samPosition[0]].Length; j++)
            {
                if (room[samPosition[0]][j] != '.' && room[samPosition[0]][j] != 'S')
                {
                    getEnemy[0] = samPosition[0];
                    getEnemy[1] = j;
                }
            }

            if (samPosition[1] < getEnemy[1] && room[getEnemy[0]][getEnemy[1]] == 'd' && 
                getEnemy[0] == samPosition[0])
            {
                room[samPosition[0]][samPosition[1]] = 'X';
                Console.WriteLine($"Sam died at {samPosition[0]}, {samPosition[1]}");
                PrintRoom(room);
                return;
            }
            else if (getEnemy[1] < samPosition[1] && room[getEnemy[0]][getEnemy[1]] == 'b' 
                && getEnemy[0] == samPosition[0])
            {
                room[samPosition[0]][samPosition[1]] = 'X';
                Console.WriteLine($"Sam died at {samPosition[0]}, {samPosition[1]}");
                PrintRoom(room);
                return;
            }

            room[samPosition[0]][samPosition[1]] = '.';
            MoveSam(samPosition, moves[i]);            
            room[samPosition[0]][samPosition[1]] = 'S';

            for (int j = 0; j < room[samPosition[0]].Length; j++)
            {
                if (room[samPosition[0]][j] != '.' && room[samPosition[0]][j] != 'S')
                {
                    getEnemy[0] = samPosition[0];
                    getEnemy[1] = j;
                }
            }

            if (room[getEnemy[0]][getEnemy[1]] == 'N' && samPosition[0] == getEnemy[0])
            {
                room[getEnemy[0]][getEnemy[1]] = 'X';
                Console.WriteLine("Nikoladze killed!");
                PrintRoom(room);
                return;
            }
        }
    }

    private static bool IsInRoom(char[][] room, int row, int col)
    {
        return row >= 0 && row < room.Length && col >= 0 && col < room[row].Length;
    }

    private static void PrintRoom(char[][] room)
    {
        for (int row = 0; row < room.Length; row++)
        {
            for (int col = 0; col < room[row].Length; col++)
            {
                Console.Write(room[row][col]);
            }

            Console.WriteLine();
        }
    }

    private static void MoveSam(int[] samPosition, char move)
    {
        switch (move)
        {
            case 'U':
                samPosition[0]--;
                break;
            case 'D':
                samPosition[0]++;
                break;
            case 'L':
                samPosition[1]--;
                break;
            case 'R':
                samPosition[1]++;
                break;
            default:
                break;
        }
    }        
}