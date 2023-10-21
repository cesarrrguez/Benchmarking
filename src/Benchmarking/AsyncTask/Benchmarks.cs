using BenchmarkDotNet.Attributes;
using System.Threading.Tasks;

namespace Benchmarking.AsyncTask;

[MemoryDiagnoser(false)]
public class Benchmarks
{
    private readonly Task<string> _task = Task.FromResult("César Rodríguez");

    [Benchmark]
    public async Task<string> GetStringWithAsync() => await _task;

    [Benchmark]
    public Task<string> GetStringWithoutAsync() => _task;
}
