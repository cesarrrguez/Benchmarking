using System;
using System.Linq;
using System.Collections.Generic;
using BenchmarkDotNet.Attributes;

namespace Benchmarking.Benchmarks.EqualsList;

[MemoryDiagnoser(false)]
public class Benchmarks
{
    private readonly EqualsListService _equalsListService = new();
    private readonly IList<long> _items1;
    private readonly IList<long> _items2;

    public Benchmarks()
    {
        _items1 = Enumerable.Range(1, 1000000).Select(x => Convert.ToInt64(x)).ToList();
        _items2 = Enumerable.Range(1, 1000000 - 1).Select(x => Convert.ToInt64(x)).ToList();
        _items2.Add(1);
    }

    [Benchmark]
    public bool EqualsGeneric() => _equalsListService.EqualsGeneric(_items1, _items2);

    [Benchmark]
    public bool EqualsLong() => _equalsListService.EqualsLong(_items1, _items2);
}
