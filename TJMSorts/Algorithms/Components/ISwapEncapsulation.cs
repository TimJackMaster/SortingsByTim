namespace TJMSorts.Algorithms.Components;

/// <summary>
/// Interface specifying an operation of swapping two elements in a list.
/// </summary>
internal interface ISwapEncapsulation
{
    public void Swap<T>(IList<T> list, int index1, int index2);
}