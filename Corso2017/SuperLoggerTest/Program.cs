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
            //do something
            //try/catch
            //logger.LogError("", ex) or
            //logger.Log(Error, "", ex) or
            //Logger.Log(...)
            throw new Exception("This is a test exception");
        }
    }
}
