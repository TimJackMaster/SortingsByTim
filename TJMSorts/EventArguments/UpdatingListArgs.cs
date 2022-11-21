namespace TJMSorts.EventArguments;

/// <summary>
/// Arguments when more than two elements changed position.
/// </summary>
/// <typeparam name="T"></typeparam>
public sealed class UpdatingListArgs<T> : EventArgs
{
    /// <summary>
    /// Copy of the list after the change.
    /// </summary>
    public List<T> NewList { get; }

    /// <summary>
    /// ctor
    /// </summary>
    /// <param name="list">List after the change.</param>
    public UpdatingListArgs(List<T> list)
    {
        NewList = new List<T>(list);
    }
}