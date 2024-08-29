using System;
using System.Collections.Generic;
using System.Linq;

namespace _07BalancedParentheses
{
    class Program
    {
        static void Main(string[] args)
        {
            string parentheses = Console.ReadLine();
            if (parentheses.Length % 2 != 0)
            {
                Console.WriteLine("NO");
                
                Environment.Exit(0);
            }

            Stack<char> stack = new Stack<char>();
            char[] opening = new char[] { '(', '[', '{' };
            char[] closing = new char[] { ')', ']', '}' };

            for (int i = 0; i < parentheses.Length; i++)
            {
                if (opening.Contains(parentheses[i]))
                {
                    stack.Push(parentheses[i]);
                }
                else if (closing.Contains(parentheses[i]))
                {                    
                    char openeningParenthese = stack.Pop();
                    int openingIndex = Array.IndexOf(opening, openeningParenthese);
                    char closingParenthese = parentheses[i];
                    int closingIndex = Array.IndexOf(closing, closingParenthese);
                    if (openingIndex != closingIndex)
                    {
                        Console.WriteLine("NO");
                        
                        Environment.Exit(0);
                    }
                }
            }

            if (stack.Any())
            {
                Console.WriteLine("NO");
            }
            else
            {
                Console.WriteLine("YES");
            }
        }
    }
}
