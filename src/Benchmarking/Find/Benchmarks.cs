using System.Collections.Generic;
using System.Linq;
using BenchmarkDotNet.Attributes;

namespace Benchmarking.Find;

public record IntWrapper(int Number);

[MemoryDiagnoser(false)]
public class Benchmarks
{
    private readonly List<int> _rawNumbers;
    private readonly List<IntWrapper> _wrappedNumbers;

    public Benchmarks()
    {
        _rawNumbers = Enumerable.Range(1, 1000).ToList();
        _wrappedNumbers = Enumerable.Range(1, 1000).Select(x => new IntWrapper(x)).ToList();
    }

    [Benchmark]
    public int FindRaw()
    {
        return _rawNumbers.Find(x => x == 500);
    }

    [Benchmark]
    public int FirstOrDefaultRaw()
    {
        return _rawNumbers.FirstOrDefault(x => x == 500);
    }

    [Benchmark]
    public int SingleOrDefaultRaw()
    {
        return _rawNumbers.SingleOrDefault(x => x == 500);
    }

    [Benchmark]
    public IntWrapper FindWrapped()
    {
        return _wrappedNumbers.Find(x => x.Number == 500)!;
    }

    [Benchmark]
    public IntWrapper FirstOrDefaultWrapped()
    {
        return _wrappedNumbers.FirstOrDefault(x => x.Number == 500)!;
    }

    [Benchmark]
    public IntWrapper SingleOrDefaultWrapped()
    {
        return _wrappedNumbers.SingleOrDefault(x => x.Number == 500)!;
    }
}
