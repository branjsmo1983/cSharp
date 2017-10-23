using System;

namespace SuperLogger.Targets
{
    public class ConsoleLogTarget : ILogTarget
    {
        public void WriteLog(LogEntry info)
        {
            Console.WriteLine($"{ info.Date } - { info.Level } - { info.Message }");
            if (info.Exception != null)
            {
                Console.WriteLine($"Exception: { info.Exception.GetType().ToString() }");
                Console.WriteLine($"\t { info.Exception.Message }");
                Console.WriteLine($"\t { info.Exception.StackTrace }");
            }
        }
    }
}
