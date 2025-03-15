using System;
using BenchmarkDotNet.Attributes;

namespace Benchmarking.EnumToString;

[MemoryDiagnoser(false)]
public class Benchmarks
{
    private readonly HumanState _state = HumanState.Sleeping;

    [Benchmark]
    public string NativeToString() => _state.ToString();

    [Benchmark]
    public string FastToString() => _state switch
    {
        HumanState.Idle => nameof(HumanState.Idle),
        HumanState.Working => nameof(HumanState.Working),
        HumanState.Sleeping => nameof(HumanState.Sleeping),
        HumanState.Eating => nameof(HumanState.Eating),
        HumanState.Dead => nameof(HumanState.Dead),
        _ => throw new ArgumentOutOfRangeException(nameof(_state), _state, null),
    };
}
