using System;
using System.Linq;

public class Program
{
    static void Main(string[] args)
    {
        string[] elements = Console.ReadLine().Split().Skip(1).ToArray();
        ListyIterator<string> listyIterator = new ListyIterator<string>(elements);
        string command;
        while ((command = Console.ReadLine()) != "END")
        {
            try
            {
                switch (command)
                {
                    case "Move":
                        Console.WriteLine(listyIterator.Move());
                        break;
                    case "HasNext":
                        Console.WriteLine(listyIterator.HasNext());
                        break;
                    case "Print":
                        listyIterator.Print();
                        break;
                }
            }
            catch(InvalidOperationException ioe)
            {
                Console.WriteLine(ioe.Message); 
            }
        }
    }
}