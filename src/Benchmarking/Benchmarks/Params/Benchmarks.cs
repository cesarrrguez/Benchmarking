using BenchmarkDotNet.Attributes;

namespace Benchmarking.Benchmarks.Params;

[MemoryDiagnoser(false)]
public class Benchmarks
{
    private readonly ParamsService _paramsService = new();
    private readonly int[] _array = { 4, 2, 0, 6, 9};

    [Benchmark]
    public int Add_WithParams_Inline() => _paramsService.Add_WithParams(4, 2, 0, 6, 9);

    [Benchmark]
    public int Add_WithParams_Single() => _paramsService.Add_WithParams(4);

    [Benchmark]
    public int Add_WithParams_Array() => _paramsService.Add_WithParams(_array);

    [Benchmark]
    public int Add_WithParams_Empty() => _paramsService.Add_WithParams();

    [Benchmark]
    public int Add_WithoutParams_Array() => _paramsService.Add_WithoutParams(_array);

    [Benchmark]
    public int Add_WithoutParams_Single() => _paramsService.Add_WithoutParams_Single(4);
}
