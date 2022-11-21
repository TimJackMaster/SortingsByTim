using TJMSorts.EventArguments;

namespace TJMSorts.Components;

/// <summary>
/// Interface encapsulating the process of comparing two elements.
/// </summary>
internal interface IComparisonEncapsulation
{
    public bool Compare<T>(List<T> list, Func<T, T, bool> action, ComparingArgs args);
}