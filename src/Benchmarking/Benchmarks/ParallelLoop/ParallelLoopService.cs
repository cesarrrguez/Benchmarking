using System.Threading.Tasks;

namespace Benchmarking.Benchmarks.ParallelLoop;

public class ParallelLoopService
{
    public int[] NormalForEach(int numberOfElements)
    {
        var array = new int[numberOfElements];

        for (var i = 0; i < array.Length; i++)
        {
            array[i] = i;
        }

        return array;
    }

    public int[] ParallelForEach(int numberOfElements)
    {
        var array = new int[numberOfElements];

        Parallel.For(0, array.Length, i => array[i] = i);

        return array;
    }
}
