using Benchmarking.Benchmarks.Logging;
using Microsoft.Extensions.Logging;

namespace Benchmarking.Benchmarks;

public class LoggingService
{
    private static readonly ILoggerFactory _loggerFactory = LoggerFactory.Create(builder =>
    {
        builder.AddConsole().SetMinimumLevel(LogLevel.Warning);
    });

    private static readonly ILogger<LoggingService> _logger = new Logger<LoggingService>(_loggerFactory);
    private readonly ILoggerAdapter<LoggingService> _loggerAdapter = new LoggerAdapter<LoggingService>(_logger);

    public void Log_WithoutIf(string message)
    {
        _logger.LogInformation(message);
    }

    public void Log_WithIf(string message)
    {
        if (_logger.IsEnabled(LogLevel.Information))
        {
            _logger.LogInformation(message);
        }
    }

    public void Log_WithoutIf_WithParameters(string message, int[] parameters)
    {
        _logger.LogInformation(message, parameters);
    }

    public void Log_WithIf_WithParameters(string message, int[] parameters)
    {
        if (_logger.IsEnabled(LogLevel.Information))
        {
            _logger.LogInformation(message, parameters);
        }
    }

    public void LogAdapter_WithIf_WithParameters(string message, int[] parameters)
    {
        _loggerAdapter.LogInformation(message, parameters);
    }
}
