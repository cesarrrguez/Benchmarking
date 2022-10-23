using System.Collections.Generic;
using System.Linq;

namespace Benchmarking.Benchmarks.CastingObjects;

public class CastingObjectsService
{
    public Person HardCast(object obj)
    {
        Person person = (Person)obj;
        return person;
    }

    public Person SafeCast(object obj)
    {
        Person? person = obj as Person;
        return person!;
    }

    public Person MatchCast(object obj)
    {
        if (obj is Person person)
        {
            return person;
        }

        return null!;
    }

    public List<Person> OfType(List<object> objs)
    {
        return objs
            .OfType<Person>()
            .ToList();
    }

    public List<Person> Cast_As(List<object> objs)
    {
        return objs
            .Where(x => x as Person is not null)
            .Cast<Person>()
            .ToList();
    }

    public List<Person> Cast_Is(List<object> objs)
    {
        return objs
            .Where(x => x is Person)
            .Cast<Person>()
            .ToList();
    }

    public List<Person> HardCast_As(List<object> objs)
    {
        return objs
            .Where(x => x as Person is not null)
            .Select(x => (Person)x)
            .ToList();
    }

    public List<Person> HardCast_Is(List<object> objs)
    {
        return objs
            .Where(x => x is Person)
            .Select(x => (Person)x)
            .ToList();
    }

    public List<Person> HardCast_TypeOf(List<object> objs)
    {
        return objs
            .Where(x => x.GetType() == typeof(Person))
            .Select(x => (Person)x)
            .ToList();
    }
}
