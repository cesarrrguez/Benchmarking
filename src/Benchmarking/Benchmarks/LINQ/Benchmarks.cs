using BenchmarkDotNet.Attributes;
using System.Collections.Generic;

namespace Benchmarking.Benchmarks.LINQ;

[MemoryDiagnoser(false)]
public class Benchmarks
{
    private readonly CustomerService _customerService = new();

    [Params(0, 5000, 9999)]
    public int Id { get; set; }

    [Benchmark]
    public Customer? GetById_FirstOrDefault() => _customerService.GetById_FirstOrDefault(Id);

    [Benchmark]
    public Customer? GetById_SingleOrDefault() => _customerService.GetById_SingleOrDefault(Id);

    [Benchmark]
    public bool Any_LinqAny() => _customerService.Any_LinqAny();

    [Benchmark]
    public bool Any_LinqCount() => _customerService.Any_LinqCount();

    [Benchmark]
    public bool Any_Count() => _customerService.Any_Count();

    [Benchmark]
    public Customer Enabled_LinqWhereAndFirst() => _customerService.Enabled_LinqWhereAndFirst();

    [Benchmark]
    public Customer Enabled_LinqFirst() => _customerService.Enabled_LinqFirst();

    [Benchmark]
    public int Enabled_LinqWhereAndCount() => _customerService.Enabled_LinqWhereAndCount();

    [Benchmark]
    public int Enabled_LinqCount() => _customerService.Enabled_LinqCount();

    [Benchmark]
    public int Enabled_ForLoopCount() => _customerService.Enabled_ForLoopCount();

    [Benchmark]
    public int Enabled_ForEachLoopCount() => _customerService.Enabled_ForEachLoopCount();

    [Benchmark]
    public IList<string> EnabledNames_ForLoop() => _customerService.EnabledNames_ForLoop();

    [Benchmark]
    public IList<string> EnabledNames_Linq() => _customerService.EnabledNames_Linq();
}
