using System;

namespace Benchmarking.Benchmarks.EnumToString;

public class EnumToStringService
{
    public string NativeToString(HumanStates states) => states.ToString();

    public string FastToString(HumanStates states) => states switch
    {
        HumanStates.Idle => nameof(HumanStates.Idle),
        HumanStates.Working => nameof(HumanStates.Working),
        HumanStates.Sleeping => nameof(HumanStates.Sleeping),
        HumanStates.Eating => nameof(HumanStates.Eating),
        HumanStates.Dead => nameof(HumanStates.Dead),
        _ => throw new ArgumentOutOfRangeException(nameof(states), states, null),
    };
}
