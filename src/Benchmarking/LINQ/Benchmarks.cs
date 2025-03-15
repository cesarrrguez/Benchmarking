using System;
using System.Collections.Generic;
using System.Linq;
using BenchmarkDotNet.Attributes;
using Bogus;

namespace Benchmarking.LINQ;

[MemoryDiagnoser(false)]
public class Benchmarks
{
    [Params(0, 5000, 9999)]
    public int Id { get; set; }

    private List<Customer> _customers = new();

    [GlobalSetup]
    public void Setup()
    {
        Randomizer.Seed = new Random(120);

        var customerFaker = new Faker<Customer>()
            .RuleFor(x => x.Id, faker => faker.IndexFaker)
            .RuleFor(x => x.FullName, faker => faker.Person.FullName)
            .RuleFor(x => x.IsEnabled, faker => faker.Random.Bool());

        _customers = customerFaker.Generate(10000);
    }

    [Benchmark]
    public Customer? GetById_SingleOrDefault() => _customers.SingleOrDefault(x => x.Id == Id);

    [Benchmark]
    public Customer? GetById_FirstOrDefault() => _customers.FirstOrDefault(x => x.Id == Id);

    [Benchmark]
    public bool Any_LinqAny() => _customers.Any();

    [Benchmark]
    public bool Any_LinqCount() => _customers.Count() > 0;

    [Benchmark]
    public bool Any_Count() => _customers.Count > 0;

    [Benchmark]
    public Customer Enabled_LinqWhereAndFirst() => _customers.Where(x => x.IsEnabled).First();

    [Benchmark]
    public Customer Enabled_LinqFirst() => _customers.First(x => x.IsEnabled);

    [Benchmark]
    public int Enabled_LinqWhereAndCount() => _customers.Where(x => x.IsEnabled).Count();

    [Benchmark]
    public int Enabled_LinqCount() => _customers.Count(x => x.IsEnabled);

    [Benchmark]
    public int Enabled_ForLoopCount()
    {
        var count = 0;

        for (var i = 0; i < _customers.Count; i++)
        {
            if (_customers[i].IsEnabled)
            {
                count++;
            }
        }

        return count;
    }

    [Benchmark]
    public int Enabled_ForEachLoopCount()
    {
        var count = 0;

        foreach (var customer in _customers)
        {
            if (customer.IsEnabled)
            {
                count++;
            }
        }

        return count;
    }

    [Benchmark]
    public IList<string> EnabledNames_ForLoop()
    {
        var names = new List<string>();

        for (var i = 0; i < _customers.Count; i++)
        {
            var customer = _customers[i];

            if (customer.IsEnabled)
            {
                names.Add(customer.FullName);
            }
        }

        return names;
    }

    [Benchmark]
    public IList<string> EnabledNames_Linq() => _customers.Where(x => x.IsEnabled).Select(x => x.FullName).ToList();
}
