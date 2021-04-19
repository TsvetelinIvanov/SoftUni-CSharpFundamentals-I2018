using System;
using System.Linq;

public class Program
{
    static void Main(string[] args)
    {
        Box<int> box = new Box<int>();
        int n = int.Parse(Console.ReadLine());
        for (int i = 0; i < n; i++)
        {
            box.Add(int.Parse(Console.ReadLine()));
        }

        int[] indexesForSwapping = Console.ReadLine().Split().Select(int.Parse).ToArray();
        box.Swap(indexesForSwapping);
        Console.WriteLine(box);
    }
}