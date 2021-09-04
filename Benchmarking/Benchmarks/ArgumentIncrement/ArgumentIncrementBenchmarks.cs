using BenchmarkDotNet.Attributes;

namespace Benchmarking.Benchmarks.ArgumentIncrement
{
    public class ArgumentIncrementBenchmarks
    {
        private readonly int _numberOfItems = 100;

        [Benchmark]
        public int A() => ArgumentIncrementService.A(_numberOfItems);

        [Benchmark]
        public int B() => ArgumentIncrementService.B(_numberOfItems);
    }
}
