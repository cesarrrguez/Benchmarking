using BenchmarkDotNet.Attributes;

namespace Benchmarking.Benchmarks.ConcatStrings
{
    [MemoryDiagnoser]
    public class ConcatStringsBenchmarks
    {
        [Params(100, 1000, 10000, 100000)]
        public int NumberOfItems;

        [Benchmark]
        public string ConcatStringsUsingGenericList() => ConcatStringsService.ConcatStringsUsingGenericList(NumberOfItems);

        [Benchmark]
        public string ConcatStringsUsingStringBuilder() => ConcatStringsService.ConcatStringsUsingStringBuilder(NumberOfItems);
    }
}
