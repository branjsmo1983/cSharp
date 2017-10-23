using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperLogger.Targets
{
    public class FileLogTarget : ILogTarget
    {
        readonly string _filePath;

        public FileLogTarget(string filePath)
        {
            _filePath = filePath;
        }

        public void WriteLog(LogEntry info)
        {
            
        }
    }
}
