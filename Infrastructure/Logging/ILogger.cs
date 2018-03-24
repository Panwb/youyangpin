using System;

namespace Infrastructure.Logging
{
    public enum LogLevel
    {
        None = 0,
        Debug = 1,
        Info = 2,
        Warn = 3,
        Error = 4,
        Fatal = 5
    }
    public interface ILogger
    {
        void Info(object infoObject);
        void Debug(object debugObject);
        void Warn(object errorObject);
        void Fatal(object errorObject);
        void Error(object errorObject);
        void Error(Exception e, object errorObject);
        bool IsEnabled(LogLevel level);
    }
}
