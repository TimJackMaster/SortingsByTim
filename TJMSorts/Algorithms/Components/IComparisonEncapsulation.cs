namespace TJMSorts.Algorithms.Components;

/// <summary>
/// Interface encapsulating the process of comparing two elements.
/// </summary>
internal interface IComparisonEncapsulation
{
    public bool Compare<T>(T current, T other, Func<T, T, bool> action);
}