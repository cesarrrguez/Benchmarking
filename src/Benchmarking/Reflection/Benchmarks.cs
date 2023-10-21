using BenchmarkDotNet.Attributes;
using System.Reflection;
using System;

namespace Benchmarking.Benchmarks.Reflection;

[MemoryDiagnoser(false)]
public class Benchmarks
{
    private readonly Person _person = new();

    private static readonly PropertyInfo _fullNamePropertyInfo = typeof(Person).GetProperty("FullName");

    private readonly FieldInfo _cachedField =
        typeof(Person).GetField("<FullName>k__BackingField",
            BindingFlags.Instance | BindingFlags.NonPublic);

    private readonly Action<Person, string> SetFullNameDelegate =
            (Action<Person, string>)Delegate.CreateDelegate(
                typeof(Action<Person, string>),
                _fullNamePropertyInfo.GetSetMethod(nonPublic: true)!);

    [Benchmark]
    public string NonReflection()
    {
        _person.SetFullName("César Rodríguez");
        return _person.FullName;
    }

    [Benchmark]
    public string Reflection()
    {
        typeof(Person).GetProperty("FullName")!.SetValue(_person, "César Rodríguez");
        return _person.FullName;
    }

    [Benchmark]
    public string ReflectionCached()
    {
        _fullNamePropertyInfo.SetValue(_person, "César Rodríguez");
        return _person.FullName;
    }

    [Benchmark]
    public string ReflectionSetFieldValueCached()
    {
        _cachedField.SetValue(_person, "César Rodríguez");
        return _person.FullName;
    }

    [Benchmark]
    public string ReflectionDelegate()
    {
        SetFullNameDelegate(_person, "César Rodríguez");
        return _person.FullName;
    }
}
