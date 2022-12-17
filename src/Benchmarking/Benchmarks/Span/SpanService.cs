using System;

namespace Benchmarking.Benchmarks.Span;

public class SpanService
{
    public (int day, int month, int year) DateWithStringAndSubstring(string dateAsText)
    {
        var dayAsText = dateAsText.Substring(0, 2);
        var monthAsText = dateAsText.Substring(3, 2);
        var yearAsText = dateAsText.Substring(6);

        var day = int.Parse(dayAsText);
        var month = int.Parse(monthAsText);
        var year = int.Parse(yearAsText);

        return (day, month, year);
    }

    public (int day, int month, int year) DateWithStringAndSpan(string dateAsText)
    {
        ReadOnlySpan<char> dateAsSpan = dateAsText;

        var dayAsText = dateAsSpan.Slice(0, 2);
        var monthAsText = dateAsSpan.Slice(3, 2);
        var yearAsText = dateAsSpan.Slice(6);

        var day = int.Parse(dayAsText);
        var month = int.Parse(monthAsText);
        var year = int.Parse(yearAsText);

        return (day, month, year);
    }
}
