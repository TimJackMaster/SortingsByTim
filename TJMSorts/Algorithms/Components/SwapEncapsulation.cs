namespace TJMSorts.Algorithms.Components;

/// <summary>
/// <inheritdoc cref="ISwapEncapsulation"/>
/// </summary>
internal sealed class SwapEncapsulation : ISwapEncapsulation
{
    public void Swap<T>(IList<T> list, int index1, int index2)
    {
        (list[index1], list[index2]) = (list[index2], list[index1]);
    }
}