namespace TJMSortsTests.CustomComparison;

internal sealed record ComparableObject : IComparable<ComparableObject>
{
    public int Value { get; }
    
    public string SomeOtherValue { get; }
    
    public ComparableObject(int value, string someOtherValue)
    {
        Value = value;
        SomeOtherValue = someOtherValue;
    }

    public int CompareTo(ComparableObject? other)
    {
        return Value.CompareTo(other?.Value);
    }
}