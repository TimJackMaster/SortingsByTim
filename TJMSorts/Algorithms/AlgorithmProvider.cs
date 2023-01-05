using TJMSorts.Components;
using TJMSorts.Enums;

namespace TJMSorts.Algorithms;

internal sealed class AlgorithmProvider : IAlgorithmProvider
{
    public ISortingAlgorithm CreateAlgorithm<T>(int strategyIndex, SortingOptions<T> options) =>
        options.AlgorithmStrategy[strategyIndex] switch
        {
            AlgorithmDecoration.Base => GetBaseAlgorithm(options),
            _ => throw new NotImplementedException()
        };

    private static ISwapEncapsulation CreateSwap<T>(int strategyIndex, SortingOptions<T> options) =>
        options.ComponentStrategy[strategyIndex] switch
        {
            ComponentDecoration.Base => new SwapEncapsulation(),
            ComponentDecoration.Observable =>
                new ObservableSwap<T>(
                    CreateSwap(strategyIndex + 1, options),
                    options.Observer),
            _ => throw new NotImplementedException()
        };
    
    private static IComparisonEncapsulation CreateComparison<T>(int strategyIndex, SortingOptions<T> options) =>
        options.ComponentStrategy[strategyIndex] switch
        {
            ComponentDecoration.Base => new ComparisonEncapsulation(),
            ComponentDecoration.Observable => new ObservableComparison<T>(
                CreateComparison(strategyIndex + 1, options),
                options.Observer),
            _ => throw new NotImplementedException()
        };
    
    private static ISortingAlgorithm GetBaseAlgorithm<T>(SortingOptions<T> options) => 
        options.Algorithm switch
        {
            Algorithm.BubbleSort => new BubbleSort(CreateComparison(0, options), CreateSwap(0, options)),
            _ => throw new NotImplementedException()
        };
}