using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperLogger.Targets
{
    public interface ILogTarget 
    {
        void WriteLog(LogEntry info);
    }
}
