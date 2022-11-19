using TJMSorts.Algorithms;
using TJMSorts.Algorithms.Components;

namespace TJMSorts;

/// <summary>
/// Static factory creating sorters
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
        var comparison = new ComparisonEncapsulation();
        var swap = new SwapEncapsulation();
        var algorithm = GetAlgorithm(options.Algorithm, comparison, swap);
        var result = new Sorter(algorithm);

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