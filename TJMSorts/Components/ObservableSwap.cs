using TJMSorts.AttributeClasses;
using TJMSorts.EventArguments;

namespace TJMSorts.Components;

internal sealed class ObservableSwap : ISwapEncapsulation
{
    private readonly ISwapEncapsulation _innerSwap;
    private readonly ISortingObserver _observer;

    public ObservableSwap(ISwapEncapsulation innerSwap, ISortingObserver observer)
    {
        _innerSwap = innerSwap;
        _observer = observer;
    }

    public void Swap<T>(IList<T> list, SwappingArgs args)
    {
        _innerSwap.Swap(list, args);
        _observer.OnElementsSwapped(args);
    }
}