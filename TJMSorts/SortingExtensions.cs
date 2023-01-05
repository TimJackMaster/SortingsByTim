using TJMSorts.Algorithms;

namespace TJMSorts;

/// <summary>
/// Extensions on IList that offers access to the sorting algorithms.
/// </summary>
public static class SortingExtensions
{
    public static List<T> Sort<T>(this List<T> list, SortingOptions<T> options) where T : IComparable<T>
    {
        return Sort(list, Comparer<T>.Default, options);
    }

    public static List<T> Sort<T>(this List<T> list, IComparer<T> comparer, SortingOptions<T> options)
    {
        var comparison = new Comparison<T>(comparer.Compare);
        return Sort(list, comparison, options);
    }

    public static List<T> Sort<T>(this List<T> list, Comparison<T> comparison, SortingOptions<T> options)
    {
        return Sort(list, comparison, 0, list.Count, options);
    }

    public static List<T> Sort<T>(this List<T> list, int startIndex, int count, IComparer<T> comparer, SortingOptions<T> options)
    {
        var comparison = new Comparison<T>(comparer.Compare);
        return Sort(list, comparison, startIndex, count, options);
    }
    
    private static List<T> Sort<T>(List<T> list, Comparison<T> comparison, int startIndex, int count, SortingOptions<T> options)
    {
        var algorithmProvider = new AlgorithmProvider();
        var sorter = new Sorter<T>(options, algorithmProvider);
        var copiedList = new List<T>(list);

        return sorter.Sort(copiedList, comparison, startIndex, count);
    }
}