using System;

namespace Benchmarking.Benchmarks.Enumeration;

public class EnumerationService
{
    public string EnumToString(Color color) => color.ToString();

    public string EnumToStringFast(Color color) => color.ToStringFast();

    public bool EnumIsDefined(int number) => Enum.IsDefined(typeof(Color), (Color)number);

    public bool EnumIsDefinedFast(int number) => ColorExtensions.IsDefined((Color)number);

    public (bool, Color) EnumTryParse(string colorString)
    {
        var couldParse = Enum.TryParse(colorString, false, out Color value);
        return (couldParse, value);
    }

    public (bool, Color) EnumTryParseFast(string colorString)
    {
        var couldParse = ColorExtensions.TryParse(colorString, false, out Color value);
        return (couldParse, value);
    }
}
