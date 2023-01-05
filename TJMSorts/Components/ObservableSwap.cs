using TJMSorts.AttributeClasses;
using TJMSorts.EventArguments;

namespace TJMSorts.Components;

internal sealed class ObservableSwap<T> : ISwapEncapsulation
{
    private readonly ISwapEncapsulation _innerSwap;
    private readonly ISortingObserver<T> _observer;

    public ObservableSwap(ISwapEncapsulation innerSwap, ISortingObserver<T> observer)
    {
        _innerSwap = innerSwap;
        _observer = observer;
    }

    public void Swap<T>(IList<T> list, SwappedArgs args)
    {
        _innerSwap.Swap(list, args);
        _observer.OnElementsSwapped(args);
    }
}