using BenchmarkDotNet.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Benchmarking.CastingObjects;

[MemoryDiagnoser(false)]
public class Benchmarks
{
    private readonly object _person = new Person
    {
        Id = Guid.NewGuid(),
        FullName = "César Rodríguez"
    };

    private readonly List<object> _people = Enumerable
        .Range(0, 10000)
        .Select(x => (object)new Person
        {
            Id = Guid.NewGuid(),
            FullName = Guid.NewGuid().ToString()
        }).ToList();

    [Benchmark]
    public Person HardCast()
    {
        Person person = (Person)_person;
        return person;
    }

    [Benchmark]
    public Person SafeCast()
    {
        Person? person = _person as Person;
        return person!;
    }

    [Benchmark]
    public Person MatchCast()
    {
        if (_person is Person person)
        {
            return person;
        }

        return null!;
    }

    [Benchmark]
    public List<Person> OfType()
    {
        return _people
            .OfType<Person>()
            .ToList();
    }

    [Benchmark]
    public List<Person> Cast_As()
    {
        return _people
            .Where(x => x as Person is not null)
            .Cast<Person>()
            .ToList();
    }

    [Benchmark]
    public List<Person> Cast_Is()
    {
        return _people
            .Where(x => x is Person)
            .Cast<Person>()
            .ToList();
    }

    [Benchmark]
    public List<Person> HardCast_As()
    {
        return _people
            .Where(x => x as Person is not null)
            .Select(x => (Person)x)
            .ToList();
    }

    [Benchmark]
    public List<Person> HardCast_Is()
    {
        return _people
            .Where(x => x is Person)
            .Select(x => (Person)x)
            .ToList();
    }

    [Benchmark]
    public List<Person> HardCast_TypeOf()
    {
        return _people
            .Where(x => x.GetType() == typeof(Person))
            .Select(x => (Person)x)
            .ToList();
    }
}
