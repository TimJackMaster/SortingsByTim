using TJMSorts.Algorithms;

namespace TJMSorts;

/// <summary>
/// <inheritdoc cref="ISorter"/>
/// </summary>
internal sealed class Sorter : ISorter
{
    private readonly ISortingAlgorithm _algorithm;

    public Sorter(ISortingAlgorithm algorithm)
    {
        _algorithm = algorithm;
    }

    public List<T> Sort<T>(List<T> list) where T : IComparable<T>
    {
        return _algorithm.Sort(new List<T>(list));
    }

    public List<T> Sort<T>(List<T> list, IComparer<T> comparer)
    {
        return _algorithm.Sort(new List<T>(list), comparer);
    }

    public List<T> Sort<T>(List<T> list, Comparison<T> comparison)
    {
        return _algorithm.Sort(new List<T>(list), comparison);
    }

    public List<T> Sort<T>(List<T> list, IComparer<T> comparer, int startIndex, int count)
    {
        return _algorithm.Sort(new List<T>(list), comparer, startIndex, count);
    }
}