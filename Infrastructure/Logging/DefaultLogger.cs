using System;
using log4net;

namespace Infrastructure.Logging
{
    public class DefaultLogger : ILogger
    {
        private readonly ILog _logger;
        
        public DefaultLogger()
        {
            _logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        }
        #region ILogger Members

        public void Info(object infoObject)
        {
            if(IsEnabled(LogLevel.Info))
            {
                _logger.Info(infoObject.ToString());
            }
        }

        public void Debug(object debugObject)
        {
            if (IsEnabled(LogLevel.Debug))
            {
                _logger.Debug(debugObject.ToString());
            }
        }

        public void Warn(object errorObject)
        {
            if (IsEnabled(LogLevel.Warn))
            {
                _logger.Warn(errorObject.ToString());
            }
        }

        public void Fatal(object errorObject)
        {
            if (IsEnabled(LogLevel.Fatal))
            {
                _logger.Fatal(errorObject.ToString());
            }
        }

        public void Error(object errorObject)
        {
            if (IsEnabled(LogLevel.Error))
            {
                _logger.Error(errorObject.ToString());
            }
        }

        public void Error(Exception e, object errorObject)
        {
            if (IsEnabled(LogLevel.Info))
            {
                _logger.Error(errorObject + e.ToString());
            }
        }

        #endregion


        public bool IsEnabled(LogLevel level)
        {
            switch (level)
            {
                case LogLevel.Debug:
                    return _logger.IsDebugEnabled;
                case LogLevel.Error:
                    return _logger.IsErrorEnabled;
                case LogLevel.Fatal:
                    return _logger.IsFatalEnabled;
                case LogLevel.Info:
                    return _logger.IsInfoEnabled;
                case LogLevel.Warn:
                    return _logger.IsWarnEnabled;
            }
            return false;
        }
    }
}