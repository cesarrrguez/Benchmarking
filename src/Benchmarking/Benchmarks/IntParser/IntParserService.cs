using System;
using System.Linq;

namespace Benchmarking.Benchmarks.IntParser;

public class IntParserService
{
    public int GetIntFromString(string numberAsString)
    {
        _ = int.TryParse(numberAsString, out var number);
        return number;
    }

    public int GetIntFromStringByAscii(string numberAsString)
    {
        var array = numberAsString.ToCharArray();
        var total = 0;

        for (var i = 0; i < array.Length; i++)
        {
            var placeValue = array.Length - i - 1;
            var multiplier = (int)Math.Pow(10, placeValue);

            total += (array[i] - '0') * multiplier;
        }

        return total;
    }

    public int GetIntFromStringByAsciiWithoutMath(string numberAsString)
    {
        var array = numberAsString.ToCharArray();
        var total = 0;

        for (var i = 0; i < array.Length; i++)
        {
            var placeValue = array.Length - i - 1;
            var multiplier = 10 ^ placeValue;

            total += (array[i] - '0') * multiplier;
        }

        return total;
    }

    public int GetIntFromStringByAsciiWithoutVariables(string numberAsString)
    {
        var array = numberAsString.ToCharArray();
        var total = 0;

        for (var i = 0; i < array.Length; i++)
        {
            total += (array[i] - '0') * (10 ^ array.Length - i - 1);
        }

        return total;
    }

    public int GetIntFromStringByAsciiWithLinq(string numberAsString)
    {
        var array = numberAsString.ToCharArray();

        return array.Select((t, i) => (t - '0') * (10 ^ array.Length - i - 1)).Sum();
    }
}
