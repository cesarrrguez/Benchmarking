namespace Benchmarking.Benchmarks.Params;

public class ParamsService
{
    public int Add_WithParams(params int[] numbers)
    {
        var sum = 0;

        for (var i = 0; i < numbers.Length; i++)
        {
            sum += numbers[i];
        }

        return sum;
    }

    public int Add_WithoutParams(int[] numbers)
    {
        var sum = 0;

        for (var i = 0; i < numbers.Length; i++)
        {
            sum += numbers[i];
        }

        return sum;
    }

    public int Add_WithoutParams_Single(int numbers) => numbers;
}
