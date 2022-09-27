using Bogus;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Benchmarking.Benchmarks.LINQ;

public class CustomerService
{
    private readonly List<Customer> _customers = new();

    public CustomerService()
    {
        Randomizer.Seed = new Random(120);

        var customerFaker = new Faker<Customer>()
            .RuleFor(x => x.Id, faker => faker.IndexFaker)
            .RuleFor(x => x.FullName, faker => faker.Person.FullName)
            .RuleFor(x => x.IsEnabled, faker => faker.Random.Bool());

        _customers = customerFaker.Generate(10000);
    }

    public Customer? GetById_SingleOrDefault(int id) => _customers.SingleOrDefault(x => x.Id == id);
    public Customer? GetById_FirstOrDefault(int id) => _customers.FirstOrDefault(x => x.Id == id);

    public bool Any_LinqAny() => _customers.Any();
    public bool Any_LinqCount() => _customers.Count() > 0;
    public bool Any_Count() => _customers.Count > 0;

    public Customer Enabled_LinqWhereAndFirst() => _customers.Where(x => x.IsEnabled).First();
    public Customer Enabled_LinqFirst() => _customers.First(x => x.IsEnabled);

    public int Enabled_LinqWhereAndCount() => _customers.Where(x => x.IsEnabled).Count();
    public int Enabled_LinqCount() => _customers.Count(x => x.IsEnabled);

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

    public IList<string> EnabledNames_Linq() => _customers.Where(x => x.IsEnabled).Select(x => x.FullName).ToList();
}
