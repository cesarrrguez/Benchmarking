using BenchmarkDotNet.Attributes;

namespace Benchmarking.Benchmarks.ConcatStrings;

[MemoryDiagnoser(false)]
public class Benchmarks
{
    private readonly ConcatStringsService _concatStringsService = new();

    [Params(100, 1000, 10000, 100000)]
    public int NumberOfItems;

    [Benchmark]
    public string ConcatStringsWithGenericList() => _concatStringsService.ConcatStringsWithGenericList(NumberOfItems);

    [Benchmark]
    public string ConcatStringsWithStringBuilder() => _concatStringsService.ConcatStringsWithStringBuilder(NumberOfItems);
}
