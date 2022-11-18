namespace TJMSorts;

/// <summary>
/// Interface specification for a sorter.
/// </summary>
public interface ISorter
{
    /// <summary>
    /// Sorts all elements in the List using the default comparison
    /// </summary>
    /// <param name="list">The original list</param>
    /// <typeparam name="T">Type of elements in the list that implements IComparable</typeparam>
    /// <returns>A sorted list of type T</returns>
    public List<T> Sort<T>(List<T> list) where T : IComparable<T>;
        
    /// <summary>
    /// Sorts all elements in the List using the specified comparor
    /// </summary>
    /// <param name="list">The original list</param>
    /// <param name="comparer">The used comparer</param>
    /// <typeparam name="T">Type of elements in the list</typeparam>
    /// <returns>A sorted list of type T</returns>
    public List<T> Sort<T>(List<T> list, IComparer<T> comparer);
        
    /// <summary>
    /// Sorts all elements in the List using the specified comparison
    /// </summary>
    /// <param name="list">The original list</param>
    /// <param name="comparison">The used comparison delegator</param>
    /// <typeparam name="T">Type of elements in the list</typeparam>
    /// <returns>A sorted list of type T</returns>
    public List<T> Sort<T>(List<T> list, Comparison<T> comparison);
    
    /// <summary>
    /// Sorts the range of elements in the List using the specified comparer.
    /// </summary>
    /// <param name="list">The original list</param>
    /// <param name="comparer">In implementation of the comparer for T</param>
    /// <param name="startIndex">The starting index of the range</param>
    /// <param name="count">The amount of items to be sorted</param>
    /// <typeparam name="T">Type of elements in the list</typeparam>
    /// <returns>A sorted list of type T</returns>
    public List<T> Sort<T>(List<T> list, IComparer<T> comparer, int startIndex, int count);
}