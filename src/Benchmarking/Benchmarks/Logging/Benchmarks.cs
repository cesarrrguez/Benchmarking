using BenchmarkDotNet.Attributes;

namespace Benchmarking.Benchmarks.Logging;

[MemoryDiagnoser(false)]
public class Benchmarks
{
    private readonly LoggingService _loggingService = new();
    private readonly string _logMessage = "This is a log message";
    private readonly string _logMessageWithParameters = "This is a log message with parameters {0}, {1} and {2}";
    private readonly int[] _parameters = { 69, 420 };

    [Benchmark]
    public void Log_WithoutIf() => _loggingService.Log_WithoutIf(_logMessage);

    [Benchmark]
    public void Log_WithIf() => _loggingService.Log_WithIf(_logMessage);

    [Benchmark]
    public void Log_WithoutIf_WithParameters() => _loggingService.Log_WithoutIf_WithParameters(_logMessageWithParameters, _parameters);

    [Benchmark]
    public void Log_WithIf_WithParameters() => _loggingService.Log_WithIf_WithParameters(_logMessageWithParameters, _parameters);

    [Benchmark]
    public void LogAdapter_WithIf_WithParameters() => _loggingService.LogAdapter_WithIf_WithParameters(_logMessageWithParameters, _parameters);
}
