using System;

public class Program
{
    static void Main(string[] args)
    {
        string[] strings = ArrayCreator.Create(5, "Pesho");
        int[] integers = ArrayCreator.Create(10, 33);

        foreach (string item in strings)
        {
            Console.WriteLine(item);
        }

        foreach (int item in integers)
        {
            Console.WriteLine(item);
        }
    }
}