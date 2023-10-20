using BenchmarkDotNet.Attributes;

namespace Benchmarking.Benchmarks.CompareStrings;

[MemoryDiagnoser(false)]
public class Benchmarks
{
    private readonly CompareStringsService _compareStringsService = new();

    public string Str1 = "Hello";

    public string Str2 = "HELLO_NO";

    [Benchmark]
    public void CompareStringsWithToLower() => _compareStringsService.CompareStringsWithToLower(Str1, Str2);

    [Benchmark]
    public void CompareStringsWithStringEquals() => _compareStringsService.CompareStringsWithStringEquals(Str1, Str2);
}
