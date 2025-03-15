using AutoFixture;
using BenchmarkDotNet.Attributes;

namespace Benchmarking.JSON;

[MemoryDiagnoser(false)]
public class Benchmarks
{
    private readonly GitHubService _gitHubService = new();
    private readonly string _userName = "cesarrrguez";

    private static readonly IFixture _fixture = new Fixture();
    private static readonly User _user = _fixture.Create<User>();

    private string _userAsText;

    [GlobalSetup]
    public void Setup()
    {
        _userAsText = _gitHubService.GetGitHubJsonAsync(_userName).Result;
    }

    [Benchmark]
    public string Serialization_Text_Newtonsoft() => Newtonsoft.Json.JsonConvert.SerializeObject(_user);

    [Benchmark]
    public string Serialization_Text_SystemTextJson() => System.Text.Json.JsonSerializer.Serialize(_user);

    [Benchmark]
    public string Serialization_Text_Jil() => Jil.JSON.Serialize(_user);

    [Benchmark]
    public string Serialization_Text_Utf8Json() => Utf8Json.JsonSerializer.ToJsonString(_user);

    [Benchmark]
    public User Deserialization_Text_Newtonsoft() => Newtonsoft.Json.JsonConvert.DeserializeObject<User>(_userAsText);

    [Benchmark]
    public User Deserialization_Text_SystemTextJson() => System.Text.Json.JsonSerializer.Deserialize<User>(_userAsText);

    [Benchmark]
    public User Deserialization_Text_Jil() => Jil.JSON.Deserialize<User>(_userAsText);

    [Benchmark]
    public User Deserialization_Text_Utf8Json() => Utf8Json.JsonSerializer.Deserialize<User>(_userAsText);
}
