namespace TJMSorts.EventArguments;

/// <summary>
/// Arguments when two elements are compared.
/// </summary>
public sealed class ComparingArgs : EventArgs
{
    /// <summary>
    /// Index of the first element.
    /// </summary>
    public int Index1 { get; }
    /// <summary>
    /// Index of the second element.
    /// </summary>
    public int Index2 { get; }

    /// <summary>
    /// ctor
    /// </summary>
    /// <param name="index1">Index of the first element</param>
    /// <param name="index2">Index of the second element</param>
    public ComparingArgs(int index1, int index2)
    {
        Index1 = index1;
        Index2 = index2;
    }
}