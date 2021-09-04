namespace Benchmarking.Benchmarks.ArgumentIncrement
{
    public static class ArgumentIncrementService
    {
        public static int A(int numberOfItems)
        {
            var result = 0;

            for (var i = 0; i < numberOfItems; i++)
            {
                result = IncrementA(result);
            }

            return result;
        }

        public static int IncrementA(int x)
        {
            x++;
            x++;
            x++;
            x++;

            return x;
        }

        public static int B(int numberOfItems)
        {
            var result = 0;

            for (var i = 0; i < numberOfItems; i++)
            {
                result = IncrementB(result);
            }

            return result;
        }

        public static int IncrementB(int x)
        {
            var y = x;

            y++;
            y++;
            y++;
            y++;

            return y;
        }
    }
}
