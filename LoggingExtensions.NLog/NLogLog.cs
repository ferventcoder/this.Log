namespace LoggingExtensions.NLog
{
    using System;
    using Logging;
    using LoggingExtensions;
    using global::NLog;

    /// <summary>
    /// Log4net logger implementing special ILog class
    /// </summary>
    public class NLogLog : ILog, ILog<NLogLog>
    {
        private Logger _logger;
        
        public void InitializeFor(string loggerName)
        {
            _logger = LogManager.GetLogger(loggerName);
        }

        public void Debug(string message, params object[] formatting)
        {
            if (_logger.IsDebugEnabled) _logger.Log(typeof(NLogLog), new LogEventInfo(LogLevel.Debug, _logger.Name, string.Format(message, formatting)));
        }

        public void Debug(Func<string> message)
        {
            if (_logger.IsDebugEnabled) _logger.Log(typeof(NLogLog), new LogEventInfo(LogLevel.Debug, _logger.Name, message()));
        }

        public void Info(string message, params object[] formatting)
        {
            if (_logger.IsInfoEnabled) _logger.Log(typeof(NLogLog), new LogEventInfo(LogLevel.Info, _logger.Name, string.Format(message, formatting)));
        }

        public void Info(Func<string> message)
        {
            if (_logger.IsInfoEnabled) _logger.Log(typeof(NLogLog), new LogEventInfo(LogLevel.Info, _logger.Name, message()));
        }

        public void Warn(string message, params object[] formatting)
        {
            if (_logger.IsWarnEnabled) _logger.Log(typeof(NLogLog), new LogEventInfo(LogLevel.Warn, _logger.Name, string.Format(message, formatting)));
        }

        public void Warn(Func<string> message)
        {
            if (_logger.IsWarnEnabled) _logger.Log(typeof(NLogLog), new LogEventInfo(LogLevel.Warn, _logger.Name, message()));
        }

        public void Error(string message, params object[] formatting)
        {
            // don't check for enabled at this level
            _logger.Log(typeof(NLogLog), new LogEventInfo(LogLevel.Error, _logger.Name, string.Format(message, formatting)));
        }

        public void Error(Func<string> message)
        {
            // don't check for enabled at this level
            _logger.Log(typeof(NLogLog), new LogEventInfo(LogLevel.Error, _logger.Name, message()));
        }

        public void Error(Func<string> message, Exception exception)
        {
            _logger.Log(typeof(NLogLog), new LogEventInfo(LogLevel.Error, _logger.Name, message()) { Exception = exception });
        }

        public void Fatal(string message, params object[] formatting)
        {
            // don't check for enabled at this level
            _logger.Log(typeof(NLogLog), new LogEventInfo(LogLevel.Fatal, _logger.Name, string.Format(message, formatting)));
        }

        public void Fatal(Func<string> message)
        {
            // don't check for enabled at this level
            _logger.Log(typeof(NLogLog), new LogEventInfo(LogLevel.Fatal, _logger.Name, message()));
        }

        public void Fatal(Func<string> message, Exception exception)
        {
            _logger.Log(typeof(NLogLog), new LogEventInfo(LogLevel.Fatal, _logger.Name, message()) { Exception = exception });
        }
    }
}