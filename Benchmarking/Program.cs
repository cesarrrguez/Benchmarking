using System;
using BenchmarkDotNet.Running;

using Benchmarking.Benchmarks.ConcatStrings;

namespace Benchmarking
{
    class Program
    {
        static void Main(string[] args)
        {
            BenchmarkRunner.Run<ConcatStringsBenchmarks>();
        }
    }
}
