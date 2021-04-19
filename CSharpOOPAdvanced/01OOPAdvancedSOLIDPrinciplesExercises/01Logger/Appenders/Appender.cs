using System;
using System.Globalization;

namespace _01Logger
{
    public abstract class Appender : IAppender
    {
        protected Appender(ILayout layout)
        {
            this.Layout = layout;
            this.ReportLevel = 0;
        }

        public ILayout Layout { get; private set; }

        public ReportLevel ReportLevel { get; set; }

        protected int MessagesCount { get; set; }

        public abstract void Apend(string dateTime, string reportLevel, string message);        

        public bool IsMessageValidLevel(string messageLevel)
        {
            if (messageLevel == "WARNING")
            {
                messageLevel = "Warn";
            }

            string capitalizedLevel = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(messageLevel.ToLower());

            return (ReportLevel)Enum.Parse(typeof(ReportLevel), capitalizedLevel) >= this.ReportLevel;
        }

        public override string ToString()
        {
            return $"Appender type: {this.GetType().Name}, Layout type: {this.Layout.GetType().Name}, " +
                $"Report level: {this.ReportLevel.ToString().ToUpper()}, Messages appended: {this.MessagesCount}";
        }
    }
}