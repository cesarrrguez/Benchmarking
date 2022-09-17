using BenchmarkDotNet.Attributes;

namespace Benchmarking.Benchmarks.ArgumentIncrement;

[MemoryDiagnoser(false)]
public class Benchmarks
{
    private readonly ArgumentIncrementService _argumentIncrementService = new();
    private readonly int _numberOfItems = 100;

    [Benchmark]
    public int A() => _argumentIncrementService.A(_numberOfItems);

    [Benchmark]
    public int B() => _argumentIncrementService.B(_numberOfItems);
}
