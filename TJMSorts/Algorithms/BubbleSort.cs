using TJMSorts.Algorithms.Components;

namespace TJMSorts.Algorithms;

/// <summary>
/// Implementation of the Bubble Sort algorithm.
/// </summary>
/// <inheritdoc cref="ISortingAlgorithm"/>
internal sealed class BubbleSort : ISortingAlgorithm
{
    private readonly IComparisonEncapsulation _comparisonEncapsulation;
    private readonly ISwapEncapsulation _swapEncapsulation;

    public BubbleSort(IComparisonEncapsulation comparisonEncapsulation, ISwapEncapsulation swapEncapsulation)
    {
        _comparisonEncapsulation = comparisonEncapsulation;
        _swapEncapsulation = swapEncapsulation;
    }
    
    public List<T> Sort<T>(List<T> list) where T : IComparable<T>
    {
        return Sort(list, Comparer<T>.Default);
    }

    public List<T> Sort<T>(List<T> list, IComparer<T> comparer)
    {
        var comparison = new Comparison<T>(comparer.Compare);
        
        return Sort(list, comparison);
    }

    public List<T> Sort<T>(List<T> list, Comparison<T> comparison)
    {
        return Sort(list, comparison, 0, list.Count);
    }

    public List<T> Sort<T>(List<T> list, IComparer<T> comparer, int startIndex, int count)
    {
        var comparison = new Comparison<T>(comparer.Compare);
        
        return Sort(list, comparison, startIndex, count);
    }
    
    private List<T> Sort<T>(List<T> list, Comparison<T> comparison, int startIndex, int count)
    {
        for (var i = startIndex + 1 + count; i > startIndex + 1; i--)
            for (var j = startIndex; j < i - 1; j++)
                if (_comparisonEncapsulation.Compare(list[j], list[j + 1],(x, y) => comparison(x, y) > 0))
                    _swapEncapsulation.Swap(list, j, j + 1);

        return list;
    }
}