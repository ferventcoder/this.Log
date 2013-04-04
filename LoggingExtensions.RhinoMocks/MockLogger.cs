﻿namespace LoggingExtensions.RhinoMocks
{
    using System;
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using Logging;
    using Rhino.Mocks;

    public enum LogLevel
    {
        Debug,
        Info,
        Warn,
        Error,
        Fatal
    }

    public class MockLogger : ILog, ILog<MockLogger>
    {
        private readonly Lazy<ConcurrentDictionary<string,IList<string>>> _messages = new Lazy<ConcurrentDictionary<string, IList<string>>>();
        private ILog _logger = MockRepository.GenerateMock<ILog>();

        public ConcurrentDictionary<string, IList<string>> Messages
        {
            get { return _messages.Value; }
        }

        public MockLogger() : base()
        {
        }

        public IList<string> MessagesFor(LogLevel logLevel)
        {
            return _messages.Value.GetOrAdd(logLevel.ToString(), new List<string>());
        }

        public void InitializeFor(string loggerName)
        {
        }

        public void Debug(string message, Exception exception)
        {
            LogMessage(LogLevel.Debug, string.Concat(message, Environment.NewLine, exception.Message, Environment.NewLine, exception.StackTrace));
            _logger.Debug(message, exception);
        }

        public void LogMessage(LogLevel logLevel, string message)
        {
            var list = _messages.Value.GetOrAdd(logLevel.ToString(), new List<string>());
            list.Add(message);
        }

        public void Debug(string message, params object[] formatting)
        {
            LogMessage(LogLevel.Debug, string.Format(message, formatting));
            _logger.Debug(message, formatting);
        }

        public void Debug(Func<string> message)
        {
            LogMessage(LogLevel.Debug, message());
            _logger.Debug(message);
        }

        public void Info(string message, Exception exception)
        {
            LogMessage(LogLevel.Info, string.Concat(message, Environment.NewLine, exception.Message, Environment.NewLine, exception.StackTrace));
            _logger.Info(message, exception);
        }

        public void Info(string message, params object[] formatting)
        {
            LogMessage(LogLevel.Info, string.Format(message, formatting));
            _logger.Info(message, formatting);
        }

        public void Info(Func<string> message)
        {
            LogMessage(LogLevel.Info, message());
            _logger.Info(message);
        }

        public void Warn(string message, Exception exception)
        {
            LogMessage(LogLevel.Warn, string.Concat(message, Environment.NewLine, exception.Message, Environment.NewLine, exception.StackTrace));
            _logger.Warn(message, exception);
        }

        public void Warn(string message, params object[] formatting)
        {
            LogMessage(LogLevel.Warn, string.Format(message, formatting));
            _logger.Warn(message, formatting);
        }

        public void Warn(Func<string> message)
        {
            LogMessage(LogLevel.Warn, message());
            _logger.Warn(message);
        }

        public void Error(string message, Exception exception)
        {
            LogMessage(LogLevel.Error, string.Concat(message, Environment.NewLine, exception.Message, Environment.NewLine, exception.StackTrace));
            _logger.Error(message, exception);
        }

        public void Error(string message, params object[] formatting)
        {
            LogMessage(LogLevel.Error, string.Format(message, formatting));
            _logger.Error(message, formatting);
        }

        public void Error(Func<string> message)
        {
            LogMessage(LogLevel.Error, message());
            _logger.Error(message);
        }

        public void Fatal(string message, Exception exception)
        {
            LogMessage(LogLevel.Fatal, string.Concat(message, Environment.NewLine, exception.Message, Environment.NewLine, exception.StackTrace));
            _logger.Fatal(message, exception);
        }

        public void Fatal(string message, params object[] formatting)
        {
            LogMessage(LogLevel.Fatal, string.Format(message, formatting));
            _logger.Fatal(message, formatting);
        }

        public void Fatal(Func<string> message)
        {
            LogMessage(LogLevel.Fatal, message());
            _logger.Fatal(message);
        }
    }
}