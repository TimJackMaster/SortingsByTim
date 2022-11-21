using TJMSorts.Algorithms;
using TJMSorts.Components;

namespace TJMSorts;

/// <summary>
/// Static factory creating sorters. For use in cases without dependency injection.
/// </summary>
public static class SorterFactory
{
    /// <summary>
    /// Creates a new object implementing ISorter
    /// </summary>
    /// <param name="options">Sorting options</param>
    /// <returns>An object implementing ISorter</returns>
    public static ISorter CreateSorter(SortingOptions options)
    {
        var comparison = GetComparisonEncapsulation(options);
        var swap = GetSwapEncapsulation(options);
        var algorithm = GetAlgorithm(options.Algorithm, comparison, swap);
        var result = new Sorter(algorithm);

        return result;
    }
    
    private static IComparisonEncapsulation GetComparisonEncapsulation(SortingOptions options)
    {
        var result = new ComparisonEncapsulation();
        if (options.Observer is not null)
            return new ObservableComparison(result, options.Observer);
        return result;
    }
    
    private static ISwapEncapsulation GetSwapEncapsulation(SortingOptions options)
    {
        var result = new SwapEncapsulation();
        if (options.Observer is not null)
            return new ObservableSwap(result, options.Observer);
        return result;
    }

    private static ISortingAlgorithm GetAlgorithm(
        Algorithm algorithm,
        IComparisonEncapsulation comparison,
        ISwapEncapsulation swap)
    {
        return algorithm switch
        {
            Algorithm.BubbleSort => new BubbleSort(comparison, swap),
            _ => throw new Exception("Algorithm not implemented")
        };
    }
}