﻿using TJMSorts.Algorithms;

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
        if (startIndex < 0)
            throw new ArgumentOutOfRangeException(nameof(startIndex), "startIndex must be greater than or equal to zero.");
        if (count < 0)
            throw new ArgumentOutOfRangeException(nameof(count), "count must be greater than or equal to zero.");
        if (startIndex + count > list.Count)
            throw new ArgumentException("startIndex + count must be less than or equal to the length of the list.");
        if (startIndex > list.Count)
            throw new ArgumentException("startIndex must be less than or equal to the length of the list.");

        return _algorithm.Sort(new List<T>(list), comparer, startIndex, count);
    }
}