using SuperLogger.Targets;
using System;
using System.Collections.Generic;
using static SuperLogger.LogEntry;

namespace SuperLogger
{
    public class Logger : ILogger
    {
        readonly List<ILogTarget> _logTargets = new List<ILogTarget>();
        
        public void AddLogTarget(ILogTarget target)
        {
            _logTargets.Add(target);
        }

        public void LogInfo(string message)
        {
            Log(LogLevel.Info, message);
        }

        public void LogError(string message, Exception ex)
        {
            Log(LogLevel.Error, message, ex);
        }

        private void Log(LogLevel level, string message, Exception ex = null)
        {
            var info = new LogEntry
            {
                Date = DateTime.Now,
                Message = message,
                Exception = ex,
                Level = level
            };

            foreach (var target in _logTargets)
            {
                try
                {
                    target.WriteLog(info);
                }
                catch (Exception)
                { 
                    //log on error,
                    //nothing to do
                }
            }
        }
    }
}
