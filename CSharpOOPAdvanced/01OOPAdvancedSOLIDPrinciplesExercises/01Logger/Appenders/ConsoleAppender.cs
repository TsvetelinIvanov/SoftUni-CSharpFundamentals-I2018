using System;

namespace _01Logger
{
    public class ConsoleAppender : Appender
    {
        public ConsoleAppender(ILayout layout) : base(layout)
        {

        }

        public override void Apend(string dateTime, string reportLevel, string message)
        {
            if (this.IsMessageValidLevel(reportLevel))
            {
                Console.WriteLine(this.Layout.FormatReport(dateTime, reportLevel, message));
                this.MessagesCount++;
            }
        }
    }
}
