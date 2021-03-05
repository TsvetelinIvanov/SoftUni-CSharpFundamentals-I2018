using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace _03CryptoBlockchain
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"(\[[^\[\{]*?(?<digits>\d{3,})[^\}\]]*?\])|(\{[^\[\{]*?(?<digits>\d{3,})[^\}\]]*?\})";
            List<int> indexes = new List<int>();
            int n = int.Parse(Console.ReadLine());
            string input = string.Empty;
            for (int i = 0; i < n; i++)
            {
                input += Console.ReadLine();
            }

            MatchCollection matches = Regex.Matches(input, pattern);
            foreach (Match match in matches)
            {
                int matchLength = match.Length;
                string digitString = match.Groups["digits"].Value;
                if (digitString.Length % 3 != 0)
                {
                    continue;
                }
                
                int indexDigitStringsCount = digitString.Length / 3;               
                for (int i = 0; i < indexDigitStringsCount; i++)
                {
                    string indexDigitString = digitString.Substring(0, 3);
                    int indexDigit = int.Parse(indexDigitString);
                    indexDigit -= matchLength;                    
                    indexes.Add(indexDigit);
                    digitString = digitString.Substring(3);
                }      
            }

            foreach (int index in indexes)
            {
                Console.Write((char)index);
            }

            Console.WriteLine();
        }
    }
}
