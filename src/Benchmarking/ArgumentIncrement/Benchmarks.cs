using BenchmarkDotNet.Attributes;

namespace Benchmarking.ArgumentIncrement;

[MemoryDiagnoser(false)]
public class Benchmarks
{
    [Params(100, 100_000, 1_000_000)]
    public int NumberOfItems { get; set; }


    [Benchmark]
    public int A()
    {
        var result = 0;

        for (var i = 0; i < NumberOfItems; i++)
        {
            result = IncrementA(result);
        }

        return result;
    }

    [Benchmark]
    public int B()
    {
        var result = 0;

        for (var i = 0; i < NumberOfItems; i++)
        {
            result = IncrementB(result);
        }

        return result;
    }

    private int IncrementA(int x)
    {
        x++;
        x++;
        x++;
        x++;

        return x;
    }

    private int IncrementB(int x)
    {
        var y = x;

        y++;
        y++;
        y++;
        y++;

        return y;
    }
}
