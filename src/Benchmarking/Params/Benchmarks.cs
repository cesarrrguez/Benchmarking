using BenchmarkDotNet.Attributes;

namespace Benchmarking.Params;

[MemoryDiagnoser(false)]
public class Benchmarks
{
    private readonly int[] _numbers = { 4, 2, 0, 6, 9 };

    [Benchmark]
    public int Add_WithoutParams_Single() => 4;

    [Benchmark]
    public int Add_WithoutParams()
    {
        var sum = 0;

        for (var i = 0; i < _numbers.Length; i++)
        {
            sum += _numbers[i];
        }

        return sum;
    }

    [Benchmark]
    public int Add_WithParams_Inline() => Add_WithParams(4, 2, 0, 6, 9);

    [Benchmark]
    public int Add_WithParams_Single() => Add_WithParams(4);

    [Benchmark]
    public int Add_WithParams_Array() => Add_WithParams(_numbers);

    [Benchmark]
    public int Add_WithParams_Empty() => Add_WithParams();

    private int Add_WithParams(params int[] numbers)
    {
        var sum = 0;

        for (var i = 0; i < numbers.Length; i++)
        {
            sum += numbers[i];
        }

        return sum;
    }
}
