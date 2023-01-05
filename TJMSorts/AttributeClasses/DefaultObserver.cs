using TJMSorts.EventArguments;

namespace TJMSorts.AttributeClasses;

public sealed class DefaultObserver<T> : ISortingObserver<T>
{
    public event EventHandler<ComparedArgs> ElementsCompared = delegate { };
    public event EventHandler<SwappedArgs> ElementsSwapped = delegate { };
    public event EventHandler<UpdatedListArgs<T>> UpdatedList = delegate { };

    public void OnElementsCompared(ComparedArgs args) => ElementsCompared.Invoke(this, args);

    public void OnElementsSwapped(SwappedArgs args) => ElementsSwapped.Invoke(this, args);

    public void OnEntireListUpdated(UpdatedListArgs<T> args) => UpdatedList.Invoke(this, args);
}