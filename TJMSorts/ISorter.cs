namespace TJMSorts;

//Interface specifying the methods that a sorter class must implement
public interface ISorter
{
    //uses default comparer
    public List<T> Sort<T>(List<T> list) where T : IComparable<T>;
        
    //uses custom comparer
    public List<T> Sort<T>(List<T> list, IComparer<T> comparer);
        
    //uses specified comparison
    public List<T> Sort<T>(List<T> list, Comparison<T> comparison);
    
    //sorts elements in a range of the list
    public List<T> Sort<T>(List<T> list, IComparer<T> comparer, int startIndex, int count);
}