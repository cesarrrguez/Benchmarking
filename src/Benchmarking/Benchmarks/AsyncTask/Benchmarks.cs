using BenchmarkDotNet.Attributes;
using System.Threading.Tasks;

namespace Benchmarking.Benchmarks.AsyncTask;

[MemoryDiagnoser(false)]
public class Benchmarks
{
    private readonly AsyncTaskService _asyncTaskService = new();
    private readonly Task<string> _task = Task.FromResult("César Rodríguez");

    [Benchmark]
    public async Task<string> GetStringWithAsync() => await _asyncTaskService.GetStringWithAsync(_task);

    [Benchmark]
    public async Task<string> GetStringWithoutAsync() => await _asyncTaskService.GetStringWithoutAsync(_task);
}
