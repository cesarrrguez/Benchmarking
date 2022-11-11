using BenchmarkDotNet.Attributes;

namespace Benchmarking.Benchmarks.Boxing;

[MemoryDiagnoser(false)]
public class Benchmarks
{
    private readonly BoxingService _boxingService = new();
    private readonly int _number = 120;
    private readonly object _value = 120;

    [Benchmark]
    public object BoxValue() => _boxingService.BoxValue(_number);

    [Benchmark]
    public int UnboxValue() => _boxingService.UnboxValue(_value);

    [Benchmark]
    public int SimpleReturnInt() => _boxingService.SimpleReturnInt(_number);

    [Benchmark]
    public object SimpleReturnObject() => _boxingService.SimpleReturnObject(_value);
}
