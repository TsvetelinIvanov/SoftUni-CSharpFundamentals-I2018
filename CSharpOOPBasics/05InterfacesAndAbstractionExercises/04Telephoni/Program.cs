using System;

public class Program
{
    static void Main(string[] args)
    {
        Smartphone smartphone = new Smartphone();
        string[] phones = Console.ReadLine().Split();
        string[]browsers = Console.ReadLine().Split();

        foreach (string phone in phones)
        {
            smartphone.Call(phone);
        }

        foreach (string browser in browsers)
        {
            smartphone.Browse(browser);
        }
    }
}