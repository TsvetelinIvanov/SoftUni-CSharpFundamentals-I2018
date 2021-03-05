using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace _03WordCount
{
    class Program
    {
        static void Main(string[] args)
        {
            using (StreamReader wordReader = new StreamReader("../Resources/words.txt"))
            {
                using (StreamReader textReader = new StreamReader("../Resources/text.txt"))
                {
                    using (StreamWriter writer = new StreamWriter("numberedLineFile.txt"))
                    {
                        Dictionary<string, int> countedWords = new Dictionary<string, int>();                        
                        string word = wordReader.ReadLine();
                        while (word != null)
                        {
                            word = word.ToLower();
                            if (!countedWords.ContainsKey(word))
                            {
                                countedWords.Add(word, 0);
                            }

                            word = wordReader.ReadLine();
                        }
                        
                        string text = textReader.ReadLine();
                        while (text != null)
                        {
                            text = text.ToLower();
                            string[] textWords = Regex.Split(text, @"\W");
                            foreach (string textWord in textWords)
                            {
                                if (countedWords.ContainsKey(textWord))
                                {
                                    countedWords[textWord]++;
                                }
                            }

                            text = textReader.ReadLine();
                        }

                        foreach (KeyValuePair<string, int> countedWord in countedWords.OrderByDescending(w => w.Value))
                        {
                            writer.WriteLine("{0} - {1}", countedWord.Key, countedWord.Value);
                        }
                    }
                }
            }
        }
    }
}
