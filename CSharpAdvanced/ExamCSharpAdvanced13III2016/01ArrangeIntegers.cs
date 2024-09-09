using System;
using System.Linq;

namespace _01ArrangeIntegers
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] numbersAsStrings = Console.ReadLine().Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);
            string[] numbersAsNames = new string[numbersAsStrings.Length];
            for (int i = 0; i < numbersAsStrings.Length; i++)
            {
                if (numbersAsStrings[i].Length > 1)
                {
                    string numberName = string.Empty;
                    string numberString = string.Empty;
                    for (int j = 0; j < numbersAsStrings[i].Length; j++)
                    {
                        string numberNameAndString = GiveNameOfNumber(numbersAsStrings[i][j].ToString());
                        numberName += numberNameAndString.Substring(0, numberNameAndString.IndexOf(" "));
                        numberString += numberNameAndString.Substring(numberNameAndString.IndexOf(" ") + 1);
                    }

                    numbersAsNames[i] = numberName + " " + numberString;
                }
                else
                {
                    numbersAsNames[i] = GiveNameOfNumber(numbersAsStrings[i]);
                }
            }

            string[] orderedNumbersAsNames = numbersAsNames.OrderBy(n => n.Substring(0, n.IndexOf(" ")))
                .ThenBy(n => n.Substring(n.IndexOf(" ") + 1).Length).ToArray();
            string[] orderedNumbersAsStrings = orderedNumbersAsNames.Select(n => n.Substring(n.IndexOf(" ") + 1)).ToArray();
            Console.WriteLine(string.Join(", ", orderedNumbersAsStrings));
        }

        private static string GiveNameOfNumber(string numrerAsString)
        {
            switch (numrerAsString)
            {
                case "1":
                    return "one 1";
                case "2":
                    return "two 2";
                case "3":
                    return "three 3";
                case "4":
                    return "four 4";
                case "5":
                    return "five 5";
                case "6":
                    return "six 6";
                case "7":
                    return "seven 7";
                case "8":
                    return "eight 8";
                case "9":
                    return "nine 9";
                case "0":
                    return "zero 0";
                default:
                    return "Invalid input!";
            }
        }
    }
}
