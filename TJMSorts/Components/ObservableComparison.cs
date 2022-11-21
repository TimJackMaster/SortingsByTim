using TJMSorts.AttributeClasses;
using TJMSorts.EventArguments;

namespace TJMSorts.Components;

internal sealed class ObservableComparison : IComparisonEncapsulation
{
    private readonly IComparisonEncapsulation _innerComparison;
    private readonly ISortingObserver _observer;
    
    public ObservableComparison(IComparisonEncapsulation encapsulation, ISortingObserver observer)
    {
        _innerComparison = encapsulation;
        _observer = observer;
    }
    
    public bool Compare<T>(List<T> list, Func<T, T, bool> action, ComparingArgs args)
    {
        var result = _innerComparison.Compare(list, action, args);
        _observer.OnElementsCompared(args);
        return result;
    }
}