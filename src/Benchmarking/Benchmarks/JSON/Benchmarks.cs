using AutoFixture;
using BenchmarkDotNet.Attributes;

namespace Benchmarking.Benchmarks.JSON;

[MemoryDiagnoser(false)]
public class Benchmarks
{
    private readonly GitHubService _gitHubService = new();
    private readonly JsonService _jsonService = new();
    private static readonly IFixture _fixture = new Fixture();
    private static readonly User _user = _fixture.Create<User>();

    private readonly string _userName = "cesarrrguez";
    private readonly string _userAsText;

    public Benchmarks()
    {
        _userAsText = _gitHubService.GetGitHubJsonAsync(_userName).Result;
    }

    [Benchmark]
    public string Serialization_Text_Newtonsoft() => _jsonService.Serialization_Text_Newtonsoft(_user);

    [Benchmark]
    public string Serialization_Text_SystemTextJson() => _jsonService.Serialization_Text_SystemTextJson(_user);

    [Benchmark]
    public string Serialization_Text_Jil() => _jsonService.Serialization_Text_Jil(_user);

    [Benchmark]
    public string Serialization_Text_Utf8Json() => _jsonService.Serialization_Text_Utf8Json(_user);

    [Benchmark]
    public User Deserialization_Text_Newtonsoft() => _jsonService.Deserialization_Text_Newtonsoft(_userAsText);

    [Benchmark]
    public User Deserialization_Text_SystemTextJson() => _jsonService.Deserialization_Text_SystemTextJson(_userAsText);

    [Benchmark]
    public User Deserialization_Text_Jil() => _jsonService.Deserialization_Text_Jil(_userAsText);

    [Benchmark]
    public User Deserialization_Text_Utf8Json() => _jsonService.Deserialization_Text_Utf8Json(_userAsText);
}
