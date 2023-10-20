using System;

namespace Benchmarking.Benchmarks.CompareStrings;

public class CompareStringsService
{
    public void CompareStringsWithToLower(string str1, string str2)
    {
        if (str1.ToLower() == str2.ToLower())
        {
            // Do something
        }
    }

    public void CompareStringsWithStringEquals(string str1, string str2)
    {
        if (string.Equals(str1, str2, StringComparison.OrdinalIgnoreCase))
        {
            // Do something
        }
    }
}
