using BenchmarkDotNet.Attributes;
using System.Threading.Tasks;

namespace Benchmarking.ParallelLoop;

[MemoryDiagnoser(false)]
public class Benchmarks
{
    [Params(100, 100_000, 1_000_000)]
    public int NumberOfItems { get; set; }

    [Benchmark]
    public int[] NormalForEach()
    {
        var array = new int[NumberOfItems];

        for (var i = 0; i < array.Length; i++)
        {
            array[i] = i;
        }

        return array;
    }

    [Benchmark]
    public int[] ParallelForEach()
    {
        var array = new int[NumberOfItems];

        Parallel.For(0, array.Length, i => array[i] = i);

        return array;
    }
}
