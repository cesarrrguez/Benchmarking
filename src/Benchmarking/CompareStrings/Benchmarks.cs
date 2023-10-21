using BenchmarkDotNet.Attributes;
using System;

namespace Benchmarking.CompareStrings;

[MemoryDiagnoser(false)]
public class Benchmarks
{
    private readonly string _str1 = "Hello";
    private readonly string _str2 = "HELLO_NO";

    [Benchmark]
    public bool CompareStringsWithToLower()
    {
        return _str1.ToLower() == _str2.ToLower();
    }

    [Benchmark]
    public bool CompareStringsWithStringEquals()
    {
        return string.Equals(_str1, _str2, StringComparison.OrdinalIgnoreCase);
    }
}
