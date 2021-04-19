namespace _01Logger
{
    public class SimpleLayout : ILayout
    {
        public string FormatReport(string dateTime, string reportLevel, string message)
        {
            return $"{dateTime} - {reportLevel} - {message}";
        }
    }
}