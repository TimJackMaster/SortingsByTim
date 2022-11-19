namespace TJMSortsTests.CustomComparison;

internal sealed class CustomComparableObjectComparer : IComparer<ComparableObject>
{
    public int Compare(ComparableObject? x, ComparableObject? y)
    {
        return string.Compare(x?.SomeOtherValue, y?.SomeOtherValue, StringComparison.Ordinal);
    }
}