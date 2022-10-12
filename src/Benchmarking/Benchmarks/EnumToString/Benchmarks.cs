using BenchmarkDotNet.Attributes;

namespace Benchmarking.Benchmarks.EnumToString;

[MemoryDiagnoser(false)]
public class Benchmarks
{
    private readonly EnumToStringService _enumToStringService = new();
    private readonly HumanStates _state = HumanStates.Sleeping;

    [Benchmark]
    public string NativeToString() => _enumToStringService.NativeToString(_state);

    [Benchmark]
    public string FastToString() => _enumToStringService.FastToString(_state);
}
