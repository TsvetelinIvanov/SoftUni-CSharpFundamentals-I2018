using System;
using System.Collections.Generic;
using System.Globalization;

namespace _01Logger
{
    public class Controller
    {
        private IList<IAppender> appenders;
        private AppenderFactory appenderFactory;

        public Controller()
        {
            this.appenders = new List<IAppender>();
            this.appenderFactory = new AppenderFactory();
        }

        internal void GetAppendersFromConsole()
        {
            int numberOfAppenders = int.Parse(Console.ReadLine());
            for (int i = 0; i < numberOfAppenders; i++)
            {
                string[] inputData = Console.ReadLine().Split();
                string appenderName = inputData[0];
                string layoutName = inputData[1];
                IAppender appender = this.appenderFactory.CreateAppender(appenderName, layoutName);
                if (inputData.Length > 2)
                {
                    this.SetLevelThreshold(appender, inputData[2]);
                }

                this.appenders.Add(appender);
            }
        }

        private void SetLevelThreshold(IAppender appender, string tresholdName)
        {
            bool isValidLevel = Enum.TryParse(CultureInfo.CurrentCulture.TextInfo.ToTitleCase(tresholdName.ToLower()),
                out ReportLevel levelThreshold);
            if (isValidLevel)
            {
                appender.ReportLevel = levelThreshold;
            }
        }

        internal void ExecuteCommands()
        {
            string commadInput;
            while ((commadInput = Console.ReadLine()) != "END")
            {
                string[] commandArgs = commadInput.Split('|');
                string reportLevel = commandArgs[0];
                string time = commandArgs[1];
                string message = commandArgs[2];

                foreach (IAppender appender in this.appenders)
                {
                    appender.Apend(time, reportLevel, message);
                }
            }
        }

        internal void PrintAppenders()
        {
            foreach (IAppender appender in this.appenders)
            {
                Console.WriteLine(appender.ToString().Trim());
            }
        }
    }
}