using System.IO;

namespace _02LineNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            using (StreamReader reader = new StreamReader("../Resources/text.txt"))
            {
                using (StreamWriter writer = new StreamWriter("numberedText.txt"))
                {
                    int lineNumber = 0;
                    string line = reader.ReadLine();
                    while (line != null)
                    {
                        lineNumber++;
                        writer.WriteLine($"Line {lineNumber}: {line}");
                        line = reader.ReadLine();
                    }
                }
            }
        }
    }
}
