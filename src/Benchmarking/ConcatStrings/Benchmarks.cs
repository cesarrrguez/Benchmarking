using BenchmarkDotNet.Attributes;
using System.Collections.Generic;
using System.Text;

namespace Benchmarking.ConcatStrings;

[MemoryDiagnoser(false)]
public class Benchmarks
{
    [Params(100, 100_000, 1_000_000)]
    public int NumberOfItems { get; set; }

    [Benchmark]
    public string ConcatStringsWithGenericList()
    {
        var list = new List<string>(NumberOfItems);

        for (var i = 0; i < NumberOfItems; i++)
        {
            list.Add("Hello World!");
        }

        return list.ToString();
    }

    [Benchmark]
    public string ConcatStringsWithStringBuilder()
    {
        var sb = new StringBuilder();

        for (var i = 0; i < NumberOfItems; i++)
        {
            sb.Append("Hello World!");
        }

        return sb.ToString();
    }
}
