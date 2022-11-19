namespace TJMSortsTests.CustomComparison;

internal sealed record ComparableObject(int Value, string SomeOtherValue) : IComparable<ComparableObject>
{
    public int CompareTo(ComparableObject? other)
    {
        return Value.CompareTo(other?.Value);
    }
}