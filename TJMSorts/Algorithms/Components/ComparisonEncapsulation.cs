namespace TJMSorts.Algorithms.Components;

/// <summary>
/// <inheritdoc cref="IComparisonEncapsulation"/>
/// </summary>
internal class ComparisonEncapsulation : IComparisonEncapsulation
{
    public bool Compare<T>(T current, T other, Func<T, T, bool> action)
    {
        return action(current, other);
    }
}