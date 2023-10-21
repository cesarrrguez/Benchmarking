using BenchmarkDotNet.Attributes;
using Microsoft.Extensions.Logging;

namespace Benchmarking.Benchmarks.Logging;

[MemoryDiagnoser(false)]
public class Benchmarks
{
    private readonly string _logMessage = "This is a log message";
    private readonly string _logMessageWithParameters = "This is a log message with parameters {0}, {1} and {2}";
    private readonly int[] _parameters = { 69, 420 };

    private static readonly ILoggerFactory _loggerFactory = LoggerFactory.Create(builder =>
    {
        builder.AddConsole().SetMinimumLevel(LogLevel.Warning);
    });

    private static readonly ILogger<Benchmarks> _logger = new Logger<Benchmarks>(_loggerFactory);
    private readonly ILoggerAdapter<Benchmarks> _loggerAdapter = new LoggerAdapter<Benchmarks>(_logger);

    [Benchmark]
    public void Log_WithoutIf()
    {
        _logger.LogInformation(_logMessage);
    }

    [Benchmark]
    public void Log_WithIf()
    {
        if (_logger.IsEnabled(LogLevel.Information))
        {
            _logger.LogInformation(_logMessage);
        }
    }

    [Benchmark]
    public void Log_WithoutIf_WithParameters()
    {
        _logger.LogInformation(_logMessageWithParameters, _parameters);
    }

    [Benchmark]
    public void Log_WithIf_WithParameters()
    {
        if (_logger.IsEnabled(LogLevel.Information))
        {
            _logger.LogInformation(_logMessageWithParameters, _parameters);
        }
    }

    [Benchmark]
    public void LogAdapter_WithIf_WithParameters()
    {
        _loggerAdapter.LogInformation(_logMessageWithParameters, _parameters);
    }
}
