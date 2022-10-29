using System.Threading.Tasks;

namespace Benchmarking.Benchmarks.AsyncTask;

public class AsyncTaskService
{
    public async Task<string> GetStringWithAsync(Task<string> task) => await task;

    public Task<string> GetStringWithoutAsync(Task<string> task) => task;
}
