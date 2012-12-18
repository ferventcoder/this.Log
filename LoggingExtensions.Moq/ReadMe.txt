this.Log-Moq
============

In your application startup, please include these lines:

Logger = new LoggingExtensions.Moq.MockLogger();
LoggingExtensions.Logging.Log.InitializeWith(Logger);