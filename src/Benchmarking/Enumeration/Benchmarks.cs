using BenchmarkDotNet.Attributes;
using System;

namespace Benchmarking.Benchmarks.Enumeration;

[MemoryDiagnoser(false)]
public class Benchmarks
{
    private readonly Color _color = Color.LightGreen;
    private readonly int _number = 21;
    private readonly string _colorString = "LightGreen";

    [Benchmark]
    public string EnumToString() => _color.ToString();

    [Benchmark]
    public string EnumToStringFast() => _color.ToStringFast();

    [Benchmark]
    public bool EnumIsDefined() => Enum.IsDefined(typeof(Color), (Color)_number);

    [Benchmark]
    public bool EnumIsDefinedFast() => ColorExtensions.IsDefined((Color)_number);

    [Benchmark]
    public (bool, Color) EnumTryParse()
    {
        var couldParse = Enum.TryParse(_colorString, false, out Color value);
        return (couldParse, value);
    }

    [Benchmark]
    public (bool, Color) EnumTryParseFast()
    {
        var couldParse = ColorExtensions.TryParse(_colorString, false, out Color value);
        return (couldParse, value);
    }
}
