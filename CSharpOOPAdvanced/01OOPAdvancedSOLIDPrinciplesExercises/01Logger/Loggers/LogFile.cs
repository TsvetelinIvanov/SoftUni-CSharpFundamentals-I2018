using System.Linq;
using System.Text;

namespace _01Logger
{
    public class LogFile : ILogFile
    {
        StringBuilder logFileBuilder;

        public LogFile()
        {
            this.logFileBuilder = new StringBuilder();
        }

        public int Size { get; private set; }

        public void Write(string message)
        {
            this.logFileBuilder.AppendLine(message);

            this.Size += message.Where(ch => char.IsLetter(ch)).Sum(ch => ch);
        }

        public override string ToString()
        {
            return this.logFileBuilder.ToString().Trim();
        }
    }
}