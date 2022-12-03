using BenchmarkDotNet.Attributes;

namespace Benchmarking.Benchmarks.ParallelLoop;

[MemoryDiagnoser(false)]
public class Benchmarks
{
    private readonly ParallelLoopService _parallelLoopService = new();
    private readonly int _numberOfElements = 1_000_000;

    [Benchmark]
    public int[] NormalForEach() => _parallelLoopService.NormalForEach(_numberOfElements);

    [Benchmark]
    public int[] ParallelForEach() => _parallelLoopService.ParallelForEach(_numberOfElements);
}
