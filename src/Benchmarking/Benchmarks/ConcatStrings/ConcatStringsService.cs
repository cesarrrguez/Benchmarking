using System.Text;
using System.Collections.Generic;

namespace Benchmarking.Benchmarks.ConcatStrings;

public class ConcatStringsService
{
    public string ConcatStringsWithGenericList(int numberOfItems)
    {
        var list = new List<string>(numberOfItems);

        for (var i = 0; i < numberOfItems; i++)
        {
            list.Add("Hello World!");
        }

        return list.ToString();
    }

    public string ConcatStringsWithStringBuilder(int numberOfItems)
    {
        var sb = new StringBuilder();

        for (var i = 0; i < numberOfItems; i++)
        {
            sb.Append("Hello World!");
        }

        return sb.ToString();
    }
}
