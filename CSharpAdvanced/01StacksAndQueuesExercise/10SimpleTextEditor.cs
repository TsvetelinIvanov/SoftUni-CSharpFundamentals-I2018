using System;
using System.Collections.Generic;
using System.Text;

namespace _10SimpleTextEditor
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Stack<string> oldVersions = new Stack<string>();
            oldVersions.Push("");
            StringBuilder text = new StringBuilder();
            for (int i = 0; i < n; i++)
            {
                string[] commands = Console.ReadLine().Split();
                int command = int.Parse(commands[0]);
                switch (command)
                {
                    case 1:
                        oldVersions.Push(text.ToString());
                        string newString = commands[1];
                        text.Append(newString);
                        break;
                    case 2:
                        oldVersions.Push(text.ToString());
                        int erasedLength = int.Parse(commands[1]);
                        text.Remove(text.Length - erasedLength, erasedLength);
                        break;
                    case 3:
                        int index = int.Parse(commands[1]);
                        Console.WriteLine(text[index - 1]);
                        break;
                    case 4:
                        text = new StringBuilder(oldVersions.Pop());
                        break;
                }
            }
        }
    }
}
