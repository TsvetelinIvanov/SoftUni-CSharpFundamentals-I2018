using System;

public class ConsoleWriter : IOutputWriter
{
    public void Write(string output)
    {
        Console.Write(output);
    }

    public void WriteLine(string output)
    {
        Console.WriteLine(output);
    }
}