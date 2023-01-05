namespace TJMSorts.Algorithms;

/// <summary>
/// Interface for a sorting algorithm.
/// </summary>
internal interface ISortingAlgorithm
{
    public List<T> Sort<T>(List<T> list, Comparison<T> comparison, int startIndex, int count);
}