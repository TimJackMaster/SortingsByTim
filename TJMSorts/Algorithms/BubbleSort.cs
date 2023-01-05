using TJMSorts.Components;
using TJMSorts.EventArguments;

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
    
    public List<T> Sort<T>(List<T> list, Comparison<T> comparison, int startIndex, int count)
    {
        for (var n = count + startIndex; n > startIndex + 1; n--)
            for (var i = startIndex; i < n - 1; i++)
                if (_comparisonEncapsulation.Compare(
                        list,
                        (x, y) => comparison(x, y) > 0,
                        new ComparedArgs(i, i + 1)))
                    _swapEncapsulation.Swap(list, new SwappedArgs(i, i + 1));
        return list;
    }
}