using SuperLogger.Targets;
using System;

namespace SuperLogger
{
    public interface ILogger
    {
        void LogInfo(string message);

        void LogError(string message, Exception ex);

        void AddLogTarget(ILogTarget target);
    }
}