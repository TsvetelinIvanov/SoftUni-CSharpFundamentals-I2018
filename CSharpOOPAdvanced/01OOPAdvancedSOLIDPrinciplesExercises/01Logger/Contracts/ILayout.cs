namespace _01Logger
{
    public interface ILayout
    {
        string FormatReport(string dateTime, string reportLevel, string message);
    }
}