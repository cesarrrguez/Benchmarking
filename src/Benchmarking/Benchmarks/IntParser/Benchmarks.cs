using BenchmarkDotNet.Attributes;

namespace Benchmarking.Benchmarks.IntParser;

[MemoryDiagnoser(false)]
public class Benchmarks
{
    private readonly IntParserService _intParserService = new();
    private readonly string _numerAsString = "210";

    [Benchmark]
    public int GetIntFromString() => _intParserService.GetIntFromString(_numerAsString);

    [Benchmark]
    public int GetIntFromStringByAscii() => _intParserService.GetIntFromStringByAscii(_numerAsString);

    [Benchmark]
    public int GetIntFromStringByAsciiWithoutMath() => _intParserService.GetIntFromStringByAsciiWithoutMath(_numerAsString);

    [Benchmark]
    public int GetIntFromStringByAsciiWithoutVariables() => _intParserService.GetIntFromStringByAsciiWithoutVariables(_numerAsString);

    [Benchmark]
    public int GetIntFromStringByAsciiWithLinq() => _intParserService.GetIntFromStringByAsciiWithLinq(_numerAsString);
}
