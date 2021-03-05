using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _03ShmoogleCounter
{
    class Program
    {
        static void Main(string[] args)
        {
            string patternDouble = @"\bdouble *([a-z][a-zA-Z]*)\b";
            string patternInt = @"\bint *([a-z][a-zA-Z]*)\b";
            List<string> doubles = new List<string>();
            List<string> ints = new List<string>();

            string input = string.Empty;
            while ((input = Console.ReadLine()) != "//END_OF_CODE")
            {
                MatchCollection doubleMatches = Regex.Matches(input, patternDouble);
                foreach (Match double1 in doubleMatches)
                {
                    doubles.Add(double1.Groups[1].Value);
                }

                MatchCollection intMatches = Regex.Matches(input, patternInt);
                foreach (Match int1 in intMatches)
                {
                    ints.Add(int1.Groups[1].Value);
                }
            }

            if (doubles.Count > 0)
            {
                Console.WriteLine("Doubles: " + string.Join(", ", doubles.OrderBy(d => d)));
            }
            else
            {
                Console.WriteLine("Doubles: None");
            }

            if (ints.Count > 0)
            {
                Console.WriteLine("Ints: " + string.Join(", ", ints.OrderBy(i => i)));
            }
            else
            {
                Console.WriteLine("Ints: None");
            }
        }
    }
}
