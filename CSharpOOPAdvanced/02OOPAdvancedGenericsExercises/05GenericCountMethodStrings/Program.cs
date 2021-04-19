using System;

public class Program
{
    static void Main(string[] args)
    {
        Box<string> box = new Box<string>();
        int n = int.Parse(Console.ReadLine());
        for (int i = 0; i < n; i++)
        {
            box.Add(Console.ReadLine());
        }

        string itemForComparing = Console.ReadLine();
        int greaterItemsCount = box.GiveCountOfGreathers(itemForComparing);
        Console.WriteLine(greaterItemsCount);
    }
}