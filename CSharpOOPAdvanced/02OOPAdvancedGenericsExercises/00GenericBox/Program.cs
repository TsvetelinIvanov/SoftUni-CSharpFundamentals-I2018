using System;

public class Program
{
    static void Main(string[] args)
    {
        string item = Console.ReadLine();

        if (char.IsDigit(item[0]))
        {
            int itemInt = int.Parse(item);
            Box<int> box = new Box<int>(itemInt);
            Console.WriteLine(box);
        }
        else
        {
            Box<string> box = new Box<string>(item);
            Console.WriteLine(box);
        }        
    }
}