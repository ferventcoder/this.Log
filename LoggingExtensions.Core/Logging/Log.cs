namespace LoggingExtensions.Logging
{
    using System;
    using System.Collections.Concurrent;
    using System.ComponentModel;

    /// <summary>
    /// Logger type initialization
    /// </summary>
    public static class Log
    {
        private static Type _logType = typeof(NullLog);
        private static ILog _testLogger;

        /// <summary>
        /// Sets up logging to be with a certain type
        /// </summary>
        /// <typeparam name="T">The type of ILog for the application to use</typeparam>
        public static void InitializeWith<T>() where T : ILog, new()
        {
            _logType = typeof(T);
        }

        /// <summary>
        /// Sets up logging to be with a certain instance. The other method is preferred.
        /// </summary>
        /// <param name="testLoggerType">Type of the logger.</param>
        /// <remarks>This is mostly geared towards testing</remarks>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static void InitializeWith(ILog testLoggerType)
        {
            _logType = testLoggerType.GetType();
            _testLogger = testLoggerType;
        }

        /// <summary>
        /// Initializes a new instance of a logger for an object.
        /// This should be done only once per object name.
        /// </summary>
        /// <param name="objectName">Name of the object.</param>
        /// <returns>ILog instance for an object if log type has been intialized; otherwise null</returns>
        public static ILog GetLoggerFor(string objectName)
        {
            if (_testLogger != null) return _testLogger;

            var logger = Activator.CreateInstance(_logType) as ILog;
            if (logger != null)
            {
                logger.InitializeFor(objectName);
            }

            return logger;
        }
    }
}