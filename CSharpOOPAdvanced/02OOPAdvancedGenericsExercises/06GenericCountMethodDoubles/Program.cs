using System;

public class Program
{
    static void Main(string[] args)
    {
        Box<double> box = new Box<double>();
        int n = int.Parse(Console.ReadLine());
        for (int i = 0; i < n; i++)
        {
            box.Add(double.Parse(Console.ReadLine()));
        }

        double itemForComparing = double.Parse(Console.ReadLine());
        int greaterItemsCount = box.GiveCountOfGreathers(itemForComparing);
        Console.WriteLine(greaterItemsCount);
    }
}