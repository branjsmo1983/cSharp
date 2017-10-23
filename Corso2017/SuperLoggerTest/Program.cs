using SuperLogger;
using SuperLogger.Targets;
using System;

namespace SuperLoggerTest
{
    class Program
    {
        static ILogger _logger;

        static void Main(string[] args)
        {
            ConfigureLog();

            TestLogInfo();
            TestLogError();

            Console.ReadKey(true);
        }

        private static void ConfigureLog()
        {
            _logger = new Logger();
            _logger.AddLogTarget(new ConsoleLogTarget());
            _logger.AddLogTarget(new DebugLogTarget());
        }

        private static void TestLogInfo()
        {
            _logger.LogInfo("This is a test info message");
        }

        private static void TestLogError()
        {
            try
            {
                throw new Exception("This is a test exception");
            }
            catch (Exception ex)
            {
                _logger.LogError("This is a test error message", ex);
            }
        }
    }
}
