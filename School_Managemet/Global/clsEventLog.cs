using Microsoft.Extensions.Logging;

public class clsEventLog : ILogger
{
    private class NoOpDisposable : IDisposable
    {
        public void Dispose() { }
    }

    public void LogEvent(string message, LogLevel logLevel = LogLevel.Error)
    {
        Log(logLevel, new EventId(), message, null, (msg, ex) => msg);
    }

    // Explicit interface implementation for ILogger.BeginScope<TState>
    IDisposable ILogger.BeginScope<TState>(TState state)
    {
        return new NoOpDisposable();
    }

    public bool IsEnabled(LogLevel logLevel)
    {
        return true; // Assuming all log levels are enabled for demonstration
    }

    public void Log<TState>(
        LogLevel logLevel,
        EventId eventId,
        TState state,
        Exception? exception,
        Func<TState, Exception?, string> formatter)
    {
        if (!IsEnabled(logLevel))
            return;

        string message = formatter(state, exception ?? new Exception("No exception provided"));

        System.Console.WriteLine($"[{logLevel}]: {message}");
        if (exception != null)
        {
            System.Console.WriteLine(exception);
        }
    }
}
