namespace _01Logger
{
    public interface IAppender
    {
        ILayout Layout { get; }

        ReportLevel ReportLevel { get; set; }

        void Apend(string dateTime, string reportLevel, string message);

        bool IsMessageValidLevel(string messageLevel);
    }
}