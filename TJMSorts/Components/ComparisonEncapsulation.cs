using TJMSorts.EventArguments;

namespace TJMSorts.Components;

/// <summary>
/// <inheritdoc cref="IComparisonEncapsulation"/>
/// </summary>
internal class ComparisonEncapsulation : IComparisonEncapsulation
{
    public bool Compare<T>(List<T> list, Func<T, T, bool> action, ComparedArgs args)
    {
        return action(list[args.Index1], list[args.Index2]);
    }
}