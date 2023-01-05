using TJMSorts.Algorithms;

namespace TJMSorts;

/// <summary>
/// <inheritdoc cref="ISorter"/>
/// </summary>
internal sealed class Sorter<T> : ISorter<T>
{
    private readonly SortingOptions<T> _options;
    private readonly IAlgorithmProvider _algorithmProvider;

    /// <summary>
    /// ctor
    /// </summary>
    /// <param name="options">Sorting Options used.</param>
    /// <param name="algorithmProvider">Provides the Algorithm.</param>
    public Sorter(SortingOptions<T> options, IAlgorithmProvider algorithmProvider)
    {
        _options = options;
        _algorithmProvider = algorithmProvider;
    }
    
    public List<T> Sort(List<T> list, Comparison<T> comparison, int startIndex, int count)
    {
        if (startIndex < 0)
            throw new ArgumentOutOfRangeException(nameof(startIndex), "startIndex must be greater than or equal to zero.");
        if (startIndex > list.Count)
            throw new ArgumentOutOfRangeException(nameof(startIndex), "startIndex must be less than or equal to the length of the list.");
        if (count < 0)
            throw new ArgumentOutOfRangeException(nameof(count), "count must be greater than or equal to zero.");
        if (startIndex + count > list.Count)
            throw new ArgumentException("startIndex + count must be less than or equal to the length of the list.");

        var algorithm = _algorithmProvider.CreateAlgorithm(0, _options);
        return algorithm.Sort(new List<T>(list), comparison, startIndex, count);
    }
}