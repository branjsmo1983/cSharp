using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperLogger
{
    public class LogEntry
    {
        public enum LogLevel { Info, Error }

        public DateTime Date { get; set; }
        public LogLevel Level { get; set; }
        public string Message { get; set; }
        public Exception Exception { get; set; }
    }
}
