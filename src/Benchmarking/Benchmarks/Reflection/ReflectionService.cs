using System;
using System.Reflection;

namespace Benchmarking.Benchmarks.Reflection;

public class ReflectionService
{
    private static readonly PropertyInfo _fullNamePropertyInfo = typeof(Person).GetProperty("FullName");

    private readonly FieldInfo _cachedField =
        typeof(Person).GetField("<FullName>k__BackingField",
            BindingFlags.Instance | BindingFlags.NonPublic);

    private readonly Action<Person, string> SetFullNameDelegate =
            (Action<Person, string>)Delegate.CreateDelegate(
                typeof(Action<Person, string>),
                _fullNamePropertyInfo.GetSetMethod(nonPublic: true)!);

    public string NonReflection(Person person)
    {
        person.SetFullName("César Rodríguez");
        return person.FullName;
    }

    public string Reflection(Person person)
    {
        typeof(Person).GetProperty("FullName")!.SetValue(person, "César Rodríguez");
        return person.FullName;
    }

    public string ReflectionCached(Person person)
    {
        _fullNamePropertyInfo.SetValue(person, "César Rodríguez");
        return person.FullName;
    }

    public string ReflectionSetFieldValueCached(Person person)
    {
        _cachedField.SetValue(person, "César Rodríguez");
        return person.FullName;
    }

    public string ReflectionDelegate(Person person)
    {
        SetFullNameDelegate(person, "César Rodríguez");
        return person.FullName;
    }
}
