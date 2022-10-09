using BenchmarkDotNet.Attributes;

namespace Benchmarking.Benchmarks.Enumeration;

[MemoryDiagnoser(false)]
public class Benchmarks
{
    private readonly EnumerationService _enumerationService = new();
    private readonly Color _color = Color.LightGreen;
    private readonly int _number = 21;
    private readonly string _colorString = "LightGreen";

    [Benchmark]
    public string EnumToString() => _enumerationService.EnumToString(_color);

    [Benchmark]
    public string EnumToStringFast() => _enumerationService.EnumToStringFast(_color);

    [Benchmark]
    public bool EnumIsDefined() => _enumerationService.EnumIsDefined(_number);

    [Benchmark]
    public bool EnumIsDefinedFast() => _enumerationService.EnumIsDefinedFast(_number);

    [Benchmark]
    public (bool, Color) EnumTryParse() => _enumerationService.EnumTryParse(_colorString);

    [Benchmark]
    public (bool, Color) EnumTryParseFast() => _enumerationService.EnumTryParseFast(_colorString);
}
