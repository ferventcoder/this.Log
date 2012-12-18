namespace LoggingExtensions.Tests.Performance
{
    using System;
    using System.Diagnostics;
    using global::log4net;
    using log4net;

    public class Log4NetPerformanceSpecs
    {
        public abstract class Log4NetPerformanceSpecsBase : TinySpec
        {
            protected int NumberOfIterations = 100000;
            protected Stopwatch stopwatch;

            public override void Context()
            {
                stopwatch = new Stopwatch();
            }
            public override void Because()
            {
                stopwatch.Reset();
            }
        }

        public class when_using_log4net_to_baseline_performance : Log4NetPerformanceSpecsBase
        {
            [Fact]
            public void with_many_iterations_of_getting_a_logger()
            {
                stopwatch.Reset();
                stopwatch.Start();
                for (int i = 0; i < NumberOfIterations; i++)
                {
                    LogManager.GetLogger(typeof(Log4NetPerformanceSpecsBase).FullName);
                }
                stopwatch.Stop();
                Console.WriteLine("Native LogManager calls over '{0}' iterations took approximately '{1}' milliseconds. This is on average '{2}' ticks per call.", NumberOfIterations, stopwatch.ElapsedMilliseconds, (stopwatch.ElapsedTicks / NumberOfIterations));
            }

            [Fact]
            public void with_many_iterations_of_logging()
            {
                var logger = LogManager.GetLogger(typeof(Log4NetPerformanceSpecsBase).FullName);
                stopwatch.Reset();
                stopwatch.Start();
                for (int i = 0; i < NumberOfIterations; i++)
                {
                    logger.Debug("Here's a message");
                }
                stopwatch.Stop();
                Console.WriteLine("Native Logging calls over '{0}' iterations took approximately '{1}' milliseconds. This is on average '{2}' ticks per call.", NumberOfIterations, stopwatch.ElapsedMilliseconds, (stopwatch.ElapsedTicks / NumberOfIterations));
            }
        }

        public class when_using_static_log_gateway_to_compare_performance : Log4NetPerformanceSpecsBase
        {
            public override void Context()
            {
                base.Context();
                LoggingExtensions.Logging.Log.InitializeWith<Log4NetLog>();
            }

            [Fact]
            public void with_many_iterations_of_getting_a_logger()
            {
                stopwatch.Reset();
                stopwatch.Start();
                for (int i = 0; i < NumberOfIterations; i++)
                {
                    Logging.Log.GetLoggerFor(typeof(Log4NetPerformanceSpecsBase).FullName);
                }
                stopwatch.Stop();
                Console.WriteLine("Static Log Gateway LogManager calls over '{0}' iterations took approximately '{1}' milliseconds. This is on average '{2}' ticks per call.", NumberOfIterations, stopwatch.ElapsedMilliseconds, (stopwatch.ElapsedTicks / NumberOfIterations));
            }

            [Fact]
            public void with_many_iterations_of_logging()
            {
                var logger = Logging.Log.GetLoggerFor(typeof(Log4NetPerformanceSpecsBase).FullName);
                stopwatch.Reset();
                stopwatch.Start();
                for (int i = 0; i < NumberOfIterations; i++)
                {
                    logger.Debug("Here's a message");
                }
                stopwatch.Stop();
                Console.WriteLine("Static Log Gateway Logging calls over '{0}' iterations took approximately '{1}' milliseconds. This is on average '{2}' ticks per call.", NumberOfIterations, stopwatch.ElapsedMilliseconds, (stopwatch.ElapsedTicks / NumberOfIterations));
            }
 
            [Fact]
            public void with_many_iterations_of_logging_with_func()
            {
                var logger = Logging.Log.GetLoggerFor(typeof(Log4NetPerformanceSpecsBase).FullName);
                stopwatch.Reset();
                stopwatch.Start();
                for (int i = 0; i < NumberOfIterations; i++)
                {
                    logger.Debug(()=>"Here's a message");
                }
                stopwatch.Stop();
                Console.WriteLine("Static Log Gateway Logging calls with deferred execution over '{0}' iterations took approximately '{1}' milliseconds. This is on average '{2}' ticks per call.", NumberOfIterations, stopwatch.ElapsedMilliseconds, (stopwatch.ElapsedTicks / NumberOfIterations));
            }
       } 
        
        public class when_using_logging_extension_to_compare_performance : Log4NetPerformanceSpecsBase
        {
            public override void Context()
            {
                base.Context();
                LoggingExtensions.Logging.Log.InitializeWith<Log4NetLog>();
            }

            [Fact]
            public void with_many_iterations_of_logging()
            {
                stopwatch.Reset();
                stopwatch.Start();
                for (int i = 0; i < NumberOfIterations; i++)
                {
                    this.Log().Debug("Here's a message");
                }
                stopwatch.Stop();
                Console.WriteLine("this.Log Logging calls over '{0}' iterations took approximately '{1}' milliseconds. This is on average '{2}' ticks per call.", NumberOfIterations, stopwatch.ElapsedMilliseconds, (stopwatch.ElapsedTicks / NumberOfIterations));
            }
 
            [Fact]
            public void with_many_iterations_of_logging_with_func()
            {
                stopwatch.Reset();
                stopwatch.Start();
                for (int i = 0; i < NumberOfIterations; i++)
                {
                    this.Log().Debug(()=>"Here's a message");
                }
                stopwatch.Stop();
                Console.WriteLine("this.Log Logging calls with deferred execution over '{0}' iterations took approximately '{1}' milliseconds. This is on average '{2}' ticks per call.", NumberOfIterations, stopwatch.ElapsedMilliseconds,(stopwatch.ElapsedTicks / NumberOfIterations));
            }
       }
    }
}