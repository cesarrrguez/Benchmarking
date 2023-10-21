using System;
using System.Linq;
using System.Collections.Generic;
using BenchmarkDotNet.Attributes;

namespace Benchmarking.EqualsList;

[MemoryDiagnoser(false)]
public class Benchmarks
{
    private IList<long> _items1;
    private IList<long> _items2;

    [GlobalSetup]
    public void Setup()
    {
        _items1 = Enumerable.Range(1, 1_000_000).Select(x => Convert.ToInt64(x)).ToList();
        _items2 = Enumerable.Range(1, 1_000_000 - 1).Select(x => Convert.ToInt64(x)).ToList();
        _items2.Add(1);
    }

    [Benchmark]
    public bool EqualsGeneric<T>()
    {
        if (ReferenceEquals(_items1, _items2))
        {
            return true;
        }

        if (_items1 is null || _items2 is null)
        {
            return false;
        }

        if (_items1.Count != _items2.Count)
        {
            return false;
        }

        for (var i = 0; i < _items1.Count; i++)
        {
            if (_items1[i] == null)
            {
                if (_items2[i] != null)
                {
                    return false;
                }
            }

            else if (!_items1[i].Equals(_items2[i]))
            {
                return false;
            }
        }

        return true;
    }

    [Benchmark]
    public bool EqualsLong()
    {
        if (ReferenceEquals(_items1, _items2))
        {
            return true;
        }

        if (_items1 is null || _items2 is null)
        {
            return false;
        }

        if (_items1.Count != _items2.Count)
        {
            return false;
        }

        for (var i = 0; i < _items1.Count; i++)
        {
            if (!_items1[i].Equals(_items2[i]))
            {
                return false;
            }
        }

        return true;
    }
}
