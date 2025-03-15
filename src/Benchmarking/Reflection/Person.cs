namespace Benchmarking.Reflection;

public class Person
{
    public string FullName { get; private set; }

    public void SetFullName(string name)
    {
        FullName = name;
    }
}
