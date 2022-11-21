using TJMSorts.EventArguments;

namespace TJMSorts.Components;

/// <summary>
/// <inheritdoc cref="ISwapEncapsulation"/>
/// </summary>
internal sealed class SwapEncapsulation : ISwapEncapsulation
{
    public void Swap<T>(IList<T> list, SwappingArgs args)
    {
        (list[args.Index1], list[args.Index2]) = (list[args.Index2], list[args.Index1]);
    }
}