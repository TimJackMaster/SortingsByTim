namespace TJMSorts;

/// <summary>
/// Interface specification for a sorter.
/// </summary>
public interface ISorter<T>
{
    public List<T> Sort(List<T> list, Comparison<T> comparison, int startIndex, int count);
}