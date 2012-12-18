this.Log-RhinoMocks
===================

In your application startup, please include these lines:

Logger = new LoggingExtensions.RhinoMocks.MockLogger();
LoggingExtensions.Logging.Log.InitializeWith(Logger);