namespace TJMSorts.Algorithms;

internal interface IAlgorithmProvider
{
    ISortingAlgorithm CreateAlgorithm<T>(int strategyIndex, SortingOptions<T> options);
}