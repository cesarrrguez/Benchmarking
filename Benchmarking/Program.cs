using System;
using BenchmarkDotNet.Running;

using Benchmarking.Benchmarks.ConcatStrings;
using Benchmarking.Benchmarks.ArgumentIncrement;

namespace Benchmarking
{
    class Program
    {
        static void Main(string[] args)
        {
            //BenchmarkRunner.Run<ConcatStringsBenchmarks>();
            BenchmarkRunner.Run<ArgumentIncrementBenchmarks>();
        }
    }
}
