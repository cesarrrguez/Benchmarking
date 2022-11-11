namespace Benchmarking.Benchmarks.Boxing;

public class BoxingService
{
    public object BoxValue(int number) => number;

    public int UnboxValue(object value) => (int)value;

    public int SimpleReturnInt(int number) => number;

    public object SimpleReturnObject(object value) => value;
}
