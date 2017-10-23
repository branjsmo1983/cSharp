using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperLogger.Targets
{
    public class DebugLogTarget : ILogTarget
    {
        public void WriteLog(LogEntry info)
        {
            Debug.WriteLine($"{ info.Date } - { info.Level } - { info.Message }");
            if (info.Exception != null)
            {
                Debug.WriteLine($"Exception: { info.Exception.GetType().ToString() }");
                Debug.WriteLine($"\t { info.Exception.Message }");
                Debug.WriteLine($"\t { info.Exception.StackTrace }");
            }
        }
    }
}
