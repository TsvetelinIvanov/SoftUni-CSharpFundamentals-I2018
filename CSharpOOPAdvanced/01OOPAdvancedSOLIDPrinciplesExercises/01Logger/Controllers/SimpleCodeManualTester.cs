namespace _01Logger
{
    public class SimpleCodeManualTester
    {
        public void ReportThreshold()
        {
            SimpleLayout simpleLayout = new SimpleLayout();
            ConsoleAppender consoleAppender = new ConsoleAppender(simpleLayout);
            consoleAppender.ReportLevel = ReportLevel.Error;

            Logger logger = new Logger(consoleAppender);

            logger.Info("3/31/2015 5:33:07 PM", "Everything seems fine");
            logger.Warn("3/31/2015 5:33:07 PM", "Warning: ping is too high - disconnect imminent");
            logger.Error("3/31/2015 5:33:07 PM", "Error parsing request");
            logger.Critical("3/31/2015 5:33:07 PM", "No connection string found in App.config");
            logger.Fatal("3/31/2015 5:33:07 PM", "mscorlib.dll does not respond");
        }

        public void Extensibility()
        {
            XmlLayout xmlLayout = new XmlLayout();
            ConsoleAppender consoleAppender = new ConsoleAppender(xmlLayout);
            Logger logger = new Logger(consoleAppender);

            logger.Fatal("3/31/2015 5:23:54 PM", "mscorlib.dll does not respond");
            logger.Critical("3/31/2015 5:23:54 PM", "No connection string found in App.config");
        }

        public void Implementations()
        {
            SimpleLayout simpleLayout = new SimpleLayout();
            ConsoleAppender consoleAppender = new ConsoleAppender(simpleLayout);

            LogFile file = new LogFile();
            FileAppender fileAppender = new FileAppender(simpleLayout);
            fileAppender.File = file;

            Logger logger = new Logger(consoleAppender, fileAppender);
            logger.Error("3/26/2015 2:08:11 PM", "Error parsing JSON.");
            logger.Info("3/26/2015 2:08:11 PM", "User Pesho successfully registered.");
        }

        public void FirstSample()
        {
            ILayout simpleLayout = new SimpleLayout();
            IAppender consoleAppender = new ConsoleAppender(simpleLayout);
            ILogger logger = new Logger(consoleAppender);

            logger.Error("3/26/2015 2:08:11 PM", "Error parsing JSON.");
            logger.Info("3/26/2015 2:08:11 PM", "User Pesho successfully registered.");
        }
    }
}