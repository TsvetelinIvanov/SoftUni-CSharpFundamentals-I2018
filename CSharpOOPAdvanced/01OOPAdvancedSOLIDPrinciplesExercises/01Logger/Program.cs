namespace _01Logger
{
    class Program
    {
        static void Main(string[] args)
        {
            //SimpleCodeManualTester simpleCodeManualTester = new SimpleCodeManualTester();
            //simpleCodeManualTester.FirstSample();
            //simpleCodeManualTester.Implementations();
            //simpleCodeManualTester.Extensibility();
            //simpleCodeManualTester.ReportThreshold();

            Controller controller = new Controller();
            controller.GetAppendersFromConsole();
            controller.ExecuteCommands();
            controller.PrintAppenders();
        }
    }
}