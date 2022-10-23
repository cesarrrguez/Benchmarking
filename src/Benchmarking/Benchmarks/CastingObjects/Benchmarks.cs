using BenchmarkDotNet.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Benchmarking.Benchmarks.CastingObjects;

[MemoryDiagnoser(false)]
public class Benchmarks
{
    private readonly CastingObjectsService _castingObjectsService = new();
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
    public Person HardCast() => _castingObjectsService.HardCast(_person);

    [Benchmark]
    public Person SafeCast() => _castingObjectsService.SafeCast(_person);

    [Benchmark]
    public Person MatchCast() => _castingObjectsService.MatchCast(_person);

    [Benchmark]
    public List<Person> OfType() => _castingObjectsService.OfType(_people);

    [Benchmark]
    public List<Person> Cast_As() => _castingObjectsService.Cast_As(_people);

    [Benchmark]
    public List<Person> Cast_Is() => _castingObjectsService.Cast_Is(_people);

    [Benchmark]
    public List<Person> HardCast_As() => _castingObjectsService.HardCast_As(_people);

    [Benchmark]
    public List<Person> HardCast_Is() => _castingObjectsService.HardCast_Is(_people);

    [Benchmark]
    public List<Person> HardCast_TypeOf() => _castingObjectsService.HardCast_TypeOf(_people);
}
