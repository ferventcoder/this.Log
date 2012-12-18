this.Log-log4net
================

In your application startup, please include this line:

For C#: LoggingExtensions.Logging.Log.InitializeWith<LoggingExtensions.log4net.Log4NetLog>();

For VB: LoggingExtensions.Logging.Log.InitializeWith(Of LoggingExtensions.log4net.Log4NetLog)()