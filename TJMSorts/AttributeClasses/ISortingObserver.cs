using TJMSorts.EventArguments;

namespace TJMSorts.AttributeClasses;

/// <summary>
/// Interface for class used to handle certain sorting events.
/// </summary>
public interface ISortingObserver<T>
{
    /// <summary>
    /// Handles the event that is raised when a comparison is made.
    /// </summary>
    /// <param name="args"></param>
    public void OnElementsCompared(ComparedArgs args);
    /// <summary>
    /// Handles the event that is raised when a swap is made.
    /// </summary>
    /// <param name="args"></param>
    public void OnElementsSwapped(SwappedArgs args);
    /// <summary>
    /// Handles the event that is raised when more then two elements changed position.
    /// </summary>
    /// <param name="args"></param>
    /// <typeparam name="T"></typeparam>
    public void OnEntireListUpdated(UpdatingListArgs<T> args);
}