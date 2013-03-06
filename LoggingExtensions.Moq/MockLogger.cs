namespace LoggingExtensions.Moq
{
    using System;
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using Logging;
    using global::Moq;

    public enum LogLevel
    {
        Debug,
        Info,
        Warn,
        Error,
        Fatal
    }

    public class MockLogger : Mock<ILog>, ILog, ILog<MockLogger>
    {
        private readonly Lazy<ConcurrentDictionary<string, IList<string>>> _messages = new Lazy<ConcurrentDictionary<string, IList<string>>>();

        public ConcurrentDictionary<string, IList<string>> Messages
        {
            get { return _messages.Value; }
        }

        public IList<string> MessagesFor(LogLevel logLevel)
        {
            return _messages.Value.GetOrAdd(logLevel.ToString(), new List<string>());
        }

        public void InitializeFor(string loggerName) {}
        public void Debug(string message, Exception exception)
        {
            LogMessage(LogLevel.Debug, string.Concat(message, Environment.NewLine, exception.Message, Environment.NewLine, exception.StackTrace));
            Object.Debug(message, exception);
        }

        public void LogMessage(LogLevel logLevel, string message)
        {
            var list = _messages.Value.GetOrAdd(logLevel.ToString(), new List<string>());
            list.Add(message);
        }

        public void Debug(string message, params object[] formatting)
        {
            LogMessage(LogLevel.Debug, string.Format(message,formatting));
            Object.Debug(message, formatting);
        }

        public void Debug(Func<string> message)
        {
            LogMessage(LogLevel.Debug, message());
            Object.Debug(message);
        }

        public void Info(string message, Exception exception)
        {
            LogMessage(LogLevel.Info, string.Concat(message, Environment.NewLine, exception.Message, Environment.NewLine, exception.StackTrace));
            Object.Info(message, exception);

        }

        public void Info(string message, params object[] formatting)
        {
            LogMessage(LogLevel.Info, string.Format(message, formatting));
            Object.Info(message, formatting);
        }

        public void Info(Func<string> message)
        {
            LogMessage(LogLevel.Info, message());
            Object.Info(message);
        }

        public void Warn(string message, Exception exception)
        {
            LogMessage(LogLevel.Warn, string.Concat(message, Environment.NewLine, exception.Message, Environment.NewLine, exception.StackTrace));
            Object.Warn(message, exception);
        }

        public void Warn(string message, params object[] formatting)
        {
            LogMessage(LogLevel.Warn, string.Format(message, formatting));
            Object.Warn(message, formatting);
        }

        public void Warn(Func<string> message)
        {
            LogMessage(LogLevel.Warn, message());
            Object.Warn(message);
        }

        public void Error(string message, Exception exception)
        {
            LogMessage(LogLevel.Error, string.Concat(message, Environment.NewLine, exception.Message, Environment.NewLine, exception.StackTrace));
            Object.Error(message, exception);
        }

        public void Error(string message, params object[] formatting)
        {
            LogMessage(LogLevel.Error, string.Format(message, formatting));
            Object.Error(message, formatting);
        }

        public void Error(Func<string> message)
        {
            LogMessage(LogLevel.Error, message());
            Object.Error(message);
        }

        public void Fatal(string message, Exception exception)
        {
            LogMessage(LogLevel.Fatal, string.Concat(message, Environment.NewLine, exception.Message, Environment.NewLine, exception.StackTrace));
            Object.Fatal(message, exception);
        }

        public void Fatal(string message, params object[] formatting)
        {
            LogMessage(LogLevel.Fatal, string.Format(message, formatting));
            Object.Fatal(message, formatting);
        }

        public void Fatal(Func<string> message)
        {
            LogMessage(LogLevel.Fatal, message());
            Object.Fatal(message);
        }
    }
}