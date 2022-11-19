using System.Collections;
using Bogus;
using TJMSortsTests.CustomComparison;

namespace TJMSortsTests;

internal static class TestCaseProvider
{
    private static readonly Faker Faker = new();

    public static List<IList> TestCases()
    {
        return new List<IList>
        {
            GetIntegerList(),
            GetDecimalList(),
            GetDoubleList(),
            GetFloatList(),
            GetLongList(),
            GetStringList(),
            GetDateTimeList(),
            GetComparableObjectList(),
        };
    }

    public static List<int> GetIntegerList(int count = 5)
        => Enumerable.Range(1, count).Select(_ => Faker.Random.Int()).ToList();
    public static List<decimal> GetDecimalList(int count = 5)
        => Enumerable.Range(1, count).Select(_ => Faker.Random.Decimal()).ToList();
    public static List<double> GetDoubleList(int count = 5)
        => Enumerable.Range(1, count).Select(_ => Faker.Random.Double()).ToList();
    public static List<long> GetLongList(int count = 5)
        => Enumerable.Range(1, count).Select(_ => Faker.Random.Long()).ToList();
    public static List<float> GetFloatList(int count = 5)
        => Enumerable.Range(1, count).Select(_ => Faker.Random.Float()).ToList();
    
    public static List<string> GetStringList(int count = 5)
        => Enumerable.Range(1, count).Select(_ => Faker.Name.FirstName()).ToList();
    
    public static List<DateTime> GetDateTimeList(int count = 5)
        => Enumerable.Range(1, count).Select(_ => Faker.Date.Future()).ToList();
    
    public static List<ComparableObject> GetComparableObjectList(int count = 5)
        => Enumerable
            .Range(1, count)
            .Select(_ => new ComparableObject(Faker.Random.Int() ,Faker.Name.FirstName())).ToList();

}