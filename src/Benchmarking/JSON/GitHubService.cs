using System.Net.Http;
using System.Threading.Tasks;

namespace Benchmarking.Benchmarks.JSON;

public class GitHubService
{
    private readonly string _token = "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";

    public async Task<string> GetGitHubJsonAsync(string userName)
    {
        var url = $"https://api.github.com/users/{userName}";

        using var client = new HttpClient();
        client.DefaultRequestHeaders.UserAgent.Add(new System.Net.Http.Headers.ProductInfoHeaderValue("AppName", "1.0"));
        client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
        client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Token", _token);

        using var response = await client.GetAsync(url);

        return await response.Content.ReadAsStringAsync();
    }
}
