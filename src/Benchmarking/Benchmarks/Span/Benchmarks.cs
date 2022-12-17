using BenchmarkDotNet.Attributes;

namespace Benchmarking.Benchmarks.Span;

[MemoryDiagnoser(false)]
public class Benchmarks
{
    private readonly SpanService _spanService = new();
    private readonly string _dateAsText = "12 12 2021";

    [Benchmark]
    public (int day, int month, int year) DateWithStringAndSubstring() => _spanService.DateWithStringAndSubstring(_dateAsText);

    [Benchmark]
    public (int day, int month, int year) DateWithStringAndSpan() => _spanService.DateWithStringAndSpan(_dateAsText);
}
