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
            if (_logger.IsDebugEnabled) _logger.Debug(message, formatting);
        }

        public void Debug(Func<string> message)
        {
            if (_logger.IsDebugEnabled) _logger.Debug(message());
        }

        public void Info(string message, params object[] formatting)
        {
           if (_logger.IsInfoEnabled) _logger.Info(message, formatting);
        }

        public void Info(Func<string> message)
        {
            if (_logger.IsInfoEnabled) _logger.Info(message());
        }

        public void Warn(string message, params object[] formatting)
        {
           if (_logger.IsWarnEnabled) _logger.Warn(message, formatting);
        }

        public void Warn(Func<string> message)
        {
            if (_logger.IsWarnEnabled) _logger.Warn(message());
        }

        public void Error(string message, params object[] formatting)
        {
            // don't check for enabled at this level
            _logger.Error(message, formatting);
        }

        public void Error(Func<string> message)
        {
            // don't check for enabled at this level
             _logger.Error(message());
        }

        public void Fatal(string message, params object[] formatting)
        {
            // don't check for enabled at this level
            _logger.Fatal(message, formatting);
        }

        public void Fatal(Func<string> message)
        {
            // don't check for enabled at this level
            _logger.Fatal(message());
        }
    }
}