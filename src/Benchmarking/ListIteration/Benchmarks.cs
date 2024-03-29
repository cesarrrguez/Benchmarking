﻿using System;
using System.Linq;
using System.Collections.Generic;
using BenchmarkDotNet.Attributes;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace Benchmarking.ListIteration;

[MemoryDiagnoser(false)]
public class Benchmarks
{

    private List<int> _items;

    [Params(100, 100_000, 1_000_000)]
    public int NumberOfItems { get; set; }


    [GlobalSetup]
    public void Setup()
    {
        var random = new Random(80085);
        _items = Enumerable.Range(1, NumberOfItems).Select(x => random.Next()).ToList();
    }

    [Benchmark]
    public void For()
    {
        for (var i = 0; i < _items.Count; i++)
        {
            var item = _items[i];
        }
    }

    [Benchmark]
    public void ForEach()
    {
        foreach (var item in _items)
        {
        }
    }

    [Benchmark]
    public void ForEach_Linq()
    {
        _items.ForEach(items => { });
    }

    [Benchmark]
    public void Parallel_ForEach()
    {
        Parallel.ForEach(_items, i => { });
    }

    [Benchmark]
    public void Parallel_Linq()
    {
        _items.AsParallel().ForAll(i => { });
    }

    [Benchmark]
    public void ForEach_Span()
    {
        foreach (var item in CollectionsMarshal.AsSpan(_items))
        {
        }
    }

    [Benchmark]
    public void For_Span()
    {
        var asSpan = CollectionsMarshal.AsSpan(_items);
        for (var i = 0; i < asSpan.Length; i++)
        {
            var item = asSpan[i];
        }
    }
}
