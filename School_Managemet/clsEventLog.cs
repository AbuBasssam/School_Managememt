using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace School_Managemet_Repository
{
    public class clsEventLog: ILogger
    {
        private readonly string _name;
        public clsEventLog(string name)
        {
            _name = name;
        }

        public void LogEvent(string message, LogLevel logLevel = LogLevel.Error)
        {
            Log(logLevel, new EventId(), message, null, (msg, ex) => msg);
        }

        public IDisposable BeginScope<TState>(TState state)
        {
            // Implement your scope management if needed
            return null; // or return a new Scope() if you have a custom implementation
        }

        public bool IsEnabled(LogLevel logLevel)
        {
            // Adjust this logic based on your logging configuration
            return true; // Assuming all log levels are enabled for demonstration
        }

        public void Log<TState>(
            LogLevel logLevel,
            EventId eventId,
            TState state,
            Exception exception,
            Func<TState, Exception, string> formatter)
        {
            if (!IsEnabled(logLevel))
                return;

            string message = formatter(state, exception);

            // Here you can implement how you want to log the message
            // For example, output to console or write to a file
            System.Console.WriteLine($"[{logLevel}] {_name}: {message}");
            if (exception != null)
            {
                System.Console.WriteLine(exception);
            }
        }
    }

}
