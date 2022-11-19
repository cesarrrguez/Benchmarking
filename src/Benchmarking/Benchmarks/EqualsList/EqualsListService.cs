using System.Collections.Generic;

namespace Benchmarking.Benchmarks.EqualsList;

public class EqualsListService
{
    public bool EqualsGeneric<T>(IList<T> x, IList<T> y)
    {
        if (ReferenceEquals(x, y))
        {
            return true;
        }

        if (x is null || y is null)
        {
            return false;
        }

        if (x.Count != y.Count)
        {
            return false;
        }

        for (var i = 0; i < x.Count; i++)
        {
            if (x[i] == null)
            {
                if (y[i] != null)
                {
                    return false;
                }
            }

            else if (!x[i].Equals(y[i]))
            {
                return false;
            }
        }

        return true;
    }

    public bool EqualsLong(IList<long> x, IList<long> y)
    {
        if (ReferenceEquals(x, y))
        {
            return true;
        }

        if (x is null || y is null)
        {
            return false;
        }

        if (x.Count != y.Count)
        {
            return false;
        }

        for (var i = 0; i < x.Count; i++)
        {
            if (!x[i].Equals(y[i]))
            {
                return false;
            }
        }

        return true;
    }
}
