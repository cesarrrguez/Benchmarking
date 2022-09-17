namespace Benchmarking.Benchmarks.ArgumentIncrement;

public class ArgumentIncrementService
{
    public int A(int numberOfItems)
    {
        var result = 0;

        for (var i = 0; i < numberOfItems; i++)
        {
            result = IncrementA(result);
        }

        return result;
    }

    public int B(int numberOfItems)
    {
        var result = 0;

        for (var i = 0; i < numberOfItems; i++)
        {
            result = IncrementB(result);
        }

        return result;
    }

    private int IncrementA(int x)
    {
        x++;
        x++;
        x++;
        x++;

        return x;
    }

    private int IncrementB(int x)
    {
        var y = x;

        y++;
        y++;
        y++;
        y++;

        return y;
    }
}
