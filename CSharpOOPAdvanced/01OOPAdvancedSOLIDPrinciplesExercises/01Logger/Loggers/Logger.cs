using System.Collections.Generic;
using System.Text;

namespace _01Logger
{
    public class Logger : ILogger
    {
        private List<IAppender> appenders;

        public Logger(params IAppender[] appenders)
        {
            this.appenders = new List<IAppender>();
            this.AddAppender(appenders);
        }

        public void AddAppender(IEnumerable<IAppender> appenders)
        {
            foreach (IAppender appender in appenders)
            {
                this.appenders.Add(appender);
            }
        }

        public void Info(string dateTime, string message)
        {
            this.Log(dateTime, nameof(this.Info) ,message);
        }

        public void Warn(string dateTime, string message)
        {
            this.Log(dateTime, nameof(this.Warn), message);
        }

        public void Error(string dateTime, string message)
        {
            this.Log(dateTime, nameof(this.Error), message);
        }

        public void Critical(string dateTime, string message)
        {
            this.Log(dateTime, nameof(this.Critical), message);
        }        

        public void Fatal(string dateTime, string message)
        {
            this.Log(dateTime, nameof(this.Fatal),message);
        }

        private void Log(string dateTime, string reportLevel, string message)
        {
            foreach (IAppender appender in this.appenders)
            {
                appender.Apend(dateTime, reportLevel, message);
            }
        }

        public override string ToString()
        {
            StringBuilder loggerBuilder = new StringBuilder();
            loggerBuilder.AppendLine("Logger info");
            foreach (IAppender appender in this.appenders)
            {
                loggerBuilder.AppendLine(appender.ToString().Trim());
            }

            return loggerBuilder.ToString();
        }
    }
}