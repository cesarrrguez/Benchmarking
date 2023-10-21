using BenchmarkDotNet.Attributes;
using System.Linq;
using System;

namespace Benchmarking.IntParser;

[MemoryDiagnoser(false)]
public class Benchmarks
{
    private readonly string _numberAsString = "210";

    [Benchmark]
    public int GetIntFromString()
    {
        _ = int.TryParse(_numberAsString, out var number);
        return number;
    }

    [Benchmark]
    public int GetIntFromStringByAscii()
    {
        var array = _numberAsString.ToCharArray();
        var total = 0;

        for (var i = 0; i < array.Length; i++)
        {
            var placeValue = array.Length - i - 1;
            var multiplier = (int)Math.Pow(10, placeValue);

            total += (array[i] - '0') * multiplier;
        }

        return total;
    }

    [Benchmark]
    public int GetIntFromStringByAsciiWithoutMath()
    {
        var array = _numberAsString.ToCharArray();
        var total = 0;

        for (var i = 0; i < array.Length; i++)
        {
            var placeValue = array.Length - i - 1;
            var multiplier = 10 ^ placeValue;

            total += (array[i] - '0') * multiplier;
        }

        return total;
    }

    [Benchmark]
    public int GetIntFromStringByAsciiWithoutVariables()
    {
        var array = _numberAsString.ToCharArray();
        var total = 0;

        for (var i = 0; i < array.Length; i++)
        {
            total += (array[i] - '0') * (10 ^ array.Length - i - 1);
        }

        return total;
    }

    [Benchmark]
    public int GetIntFromStringByAsciiWithLinq()
    {
        var array = _numberAsString.ToCharArray();

        return array.Select((t, i) => (t - '0') * (10 ^ array.Length - i - 1)).Sum();
    }
}
