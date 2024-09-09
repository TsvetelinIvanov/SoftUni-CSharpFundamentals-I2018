using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace _03BasicMarkUpLanguage
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> tagContents = new List<string>();
            string pattern = @"\s*<\s*([a-z]+)\s+(?:value\s*=\s*""\s*(\d+)\s*""\s+)?[a-z]+\s*=\s*""([^""]*)""\s*\/>\s*";
            Regex regex = new Regex(pattern);
            string input;
            while ((input = Console.ReadLine()) != "<stop/>")
            {
                Match match = regex.Match(input);
                string command = match.Groups[1].Value;
                if (command == "inverse")
                {
                    string tagContent = match.Groups[3].Value;
                    if (tagContent == "")
                    {
                        continue;
                    }

                    tagContent = InverseContent(tagContent);
                    tagContents.Add(tagContent);
                }
                else if (command == "reverse")
                {
                    string tagContent = match.Groups[3].Value;
                    if (tagContent == "")
                    {
                        continue;
                    }

                    tagContent = ReverseContent(tagContent);
                    tagContents.Add(tagContent);
                }                
                else if (command == "repeat")
                {
                    int numberOfRepeats = int.Parse(match.Groups[2].Value);
                    string tagContent = match.Groups[3].Value;
                    if (tagContent == "")
                    {
                        continue;
                    }

                    for (int i = 0; i < numberOfRepeats; i++)
                    {
                        tagContents.Add(tagContent);
                    }
                }
            }

            int counter = 0;
            foreach (string tagContent in tagContents)
            {
                counter++;
                Console.WriteLine($"{counter}. {tagContent}");
            }
        }

        private static string InverseContent(string word)
        {
            string inversedWord = string.Empty;
            for (int i = 0; i < word.Length; i++)
            {
                if (Regex.IsMatch(word[i].ToString(), "[A-Z]"))
                {
                    inversedWord += (char)(word[i] + 32);
                }
                else if (Regex.IsMatch(word[i].ToString(), "[a-z]"))
                {
                    inversedWord += (char)(word[i] - 32);
                }
                else
                {
                    inversedWord += word[i];
                }
            }

            return inversedWord;
        }

        private static string ReverseContent(string tagContent)
        {
            string reversedTagContent = string.Empty;
            for (int i = tagContent.Length - 1; i >= 0; i--)
            {
                reversedTagContent += tagContent[i];
            }

            return reversedTagContent;
        }        
    }
}
