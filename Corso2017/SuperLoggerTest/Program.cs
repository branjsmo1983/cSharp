using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperLoggerTest
{
    class Program
    {
        static void Main(string[] args)
        {
            ConfigureLog();

            TestLogInfo();
            TestLogError();

            Console.ReadKey(true);
        }

        private static void ConfigureLog()
        {
            //configure logger for any writing method
            //logger.AddLoggingTarget(file);
            //logger.AddLoggingTarget(console);
            //logger.AddLoggingTarget(database);
        }

        private static void TestLogInfo()
        {
            //do something
            //logger.LogInfo("") or
            //logger.Log(Info, "") or
            //Logger.Log(...)
        }

        private static void TestLogError()
        {
            try
            {
                throw new Exception("This is a test exception");
            }
            catch (Exception ex)
            {
                //do something
                //logger.LogError("", ex) or
                //logger.Log(Error, "", ex) or
                //Logger.Log(...)
            }
        }
    }
}
