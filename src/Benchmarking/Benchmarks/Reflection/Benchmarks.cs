using BenchmarkDotNet.Attributes;

namespace Benchmarking.Benchmarks.Reflection;

[MemoryDiagnoser(false)]
public class Benchmarks
{
    private readonly ReflectionService _reflectionService = new();
    private readonly Person _person = new();

    [Benchmark]
    public string NonReflection() => _reflectionService.NonReflection(_person);

    [Benchmark]
    public string Reflection() => _reflectionService.Reflection(_person);

    [Benchmark]
    public string ReflectionCached() => _reflectionService.ReflectionCached(_person);

    [Benchmark]
    public string ReflectionSetFieldValueCached() => _reflectionService.ReflectionSetFieldValueCached(_person);

    [Benchmark]
    public string ReflectionDelegate() => _reflectionService.ReflectionDelegate(_person);
}
