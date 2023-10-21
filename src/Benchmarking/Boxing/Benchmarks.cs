using BenchmarkDotNet.Attributes;

namespace Benchmarking.Boxing;

[MemoryDiagnoser(false)]
public class Benchmarks
{
    private readonly int _number = 120;
    private readonly object _value = 120;

    [Benchmark]
    public object BoxValue() => _number;

    [Benchmark]
    public int UnboxValue() => (int)_value;

    [Benchmark]
    public int SimpleReturnInt() => _number;

    [Benchmark]
    public object SimpleReturnObject() => _value;
}
