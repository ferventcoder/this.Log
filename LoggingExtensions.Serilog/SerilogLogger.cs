using System;
using Serilog;

namespace LoggingExtensions.Serilog
{
	public sealed class SeriLogLogger : Logging.ILog, Logging.ILog<SeriLogLogger>
	{
		private ILogger _logger;
		public void InitializeFor(string loggerName)
		{

		}

		public void Debug(string message, params object[] formatting)
		{
			throw new NotImplementedException();
		}

		public void Debug(Func<string> message)
		{
			throw new NotImplementedException();
		}

		public void Info(string message, params object[] formatting)
		{
			throw new NotImplementedException();
		}

		public void Info(Func<string> message)
		{
			throw new NotImplementedException();
		}

		public void Warn(string message, params object[] formatting)
		{
			throw new NotImplementedException();
		}

		public void Warn(Func<string> message)
		{
			throw new NotImplementedException();
		}

		public void Error(string message, params object[] formatting)
		{
			throw new NotImplementedException();
		}

		public void Error(Func<string> message)
		{
			throw new NotImplementedException();
		}

		public void Error(Func<string> message, Exception exception)
		{
			throw new NotImplementedException();
		}

		public void Fatal(string message, params object[] formatting)
		{
			throw new NotImplementedException();
		}

		public void Fatal(Func<string> message)
		{
			throw new NotImplementedException();
		}

		public void Fatal(Func<string> message, Exception exception)
		{
			throw new NotImplementedException();
		}
	}
}