using log4net.Config;

[assembly: XmlConfigurator(Watch = true)]

namespace LoggingExtensions.log4net
{
    using System;
    using System.Runtime;
    using global::log4net;
    using LoggingExtensions;

    /// <summary>
    /// Log4net logger implementing special ILog class
    /// </summary>
    public sealed class Log4NetLog : global::LoggingExtensions.Logging.ILog, global::LoggingExtensions.Logging.ILog<Log4NetLog>
    {
        private global::log4net.ILog _logger;

        [TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")]
        public void InitializeFor(string loggerName)
        {
            _logger = LogManager.GetLogger(loggerName);
        }

        [TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")]
        public void Debug(string message, Exception exception)
        {
            if (_logger.IsDebugEnabled) _logger.Debug(message, exception);
        }

        [TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")]
        public void Debug(string message, params object[] formatting)
        {
            if (_logger.IsDebugEnabled) _logger.DebugFormat(message, formatting);
        }

        [TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")]
        public void Debug(Func<string> message)
        {
            if (_logger.IsDebugEnabled) _logger.Debug(message());
        }

        [TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")]
        public void Info(string message, Exception exception)
        {
            if (_logger.IsInfoEnabled) _logger.Info(message, exception);
        }

        [TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")]
        public void Info(string message, params object[] formatting)
        {
           if (_logger.IsInfoEnabled) _logger.InfoFormat(message, formatting);
        }

        [TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")]
        public void Info(Func<string> message)
        {
            if (_logger.IsInfoEnabled) _logger.Info(message());
        }

        [TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")]
        public void Warn(string message, Exception exception)
        {
            if (_logger.IsWarnEnabled) _logger.Warn(message, exception);
        }

        [TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")]
        public void Warn(string message, params object[] formatting)
        {
           if (_logger.IsWarnEnabled) _logger.WarnFormat(message, formatting);
        }

        [TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")]
        public void Warn(Func<string> message)
        {
            if (_logger.IsWarnEnabled) _logger.Warn(message());
        }

        [TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")]
        public void Error(string message, Exception exception)
        {
            // don't check for enabled at this level
            _logger.Error(message, exception);
        }

        [TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")]
        public void Error(string message, params object[] formatting)
        {
            // don't check for enabled at this level
            _logger.ErrorFormat(message, formatting);
        }

        [TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")]
        public void Error(Func<string> message)
        {
            // don't check for enabled at this level
             _logger.Error(message());
        }

        [TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")]
        public void Fatal(string message, Exception exception)
        {
            // don't check for enabled at this level
            _logger.Fatal(message, exception);
        }

        [TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")]
        public void Fatal(string message, params object[] formatting)
        {
            // don't check for enabled at this level
            _logger.FatalFormat(message, formatting);
        }

        [TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")]
        public void Fatal(Func<string> message)
        {
            // don't check for enabled at this level
            _logger.Fatal(message());
        }

        //public string DecorateMessageWithAuditInformation(string message)
        //{
        //    string currentUserName = ApplicationParameters.GetCurrentUserName();
        //    if (!string.IsNullOrWhiteSpace(currentUserName))
        //    {
        //        return "{0} - {1}".FormatWith(message, currentUserName);
        //    }

        //    return message;
        //}
    }
}