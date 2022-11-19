namespace TJMSorts.Algorithms;

/// <summary>
/// Interface for a sorting algorithm.
/// </summary>
internal interface ISortingAlgorithm
{
    public List<T> Sort<T>(List<T> list) where T : IComparable<T>;

    public List<T> Sort<T>(List<T> list, IComparer<T> comparer);
    
    public List<T> Sort<T>(List<T> list, Comparison<T> comparison);

    public List<T> Sort<T>(List<T> list, int startIndex, int count, IComparer<T> comparer);
}