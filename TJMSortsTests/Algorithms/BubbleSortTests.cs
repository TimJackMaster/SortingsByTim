using System.Collections;
using TJMSorts.Algorithms;
using TJMSorts.Algorithms.Components;
using TJMSortsTests.CustomComparison;

namespace TJMSortsTests.Algorithms;

internal sealed class BubbleSortTests
{
    private static readonly List<IList> TestCasesWithDefaultComparer = TestCaseProvider.TestCases();
    private readonly ISortingAlgorithm _bubbleSort;

    public BubbleSortTests()
    {
        _bubbleSort = new BubbleSort(new ComparisonEncapsulation(), new SwapEncapsulation());
    }

    [Test, TestCaseSource(nameof(TestCasesWithDefaultComparer))]
    public void Sort_WhenCalled_ReturnsSortedList<T>(List<T> list) where T : IComparable<T>
    {
        var expectedResult = new List<T>(list);
        expectedResult.Sort();
        
        var actual = _bubbleSort.Sort(list);
        
        CollectionAssert.AreEqual(expectedResult, actual);
    }
    
    [Test]
    public void Sort_WhenCalledWithCustomComparer_ReturnsSortedList()
    {
        var list = TestCaseProvider.GetComparableObjectList();
        var comparer = new CustomComparableObjectComparer();
        var expectedResult = new List<ComparableObject>(list);
        expectedResult.Sort(comparer);
        
        var actual = _bubbleSort.Sort(list, comparer);
        
        CollectionAssert.AreEqual(expectedResult, actual);
    }

    [Test, TestCaseSource(nameof(TestCasesWithDefaultComparer))]
    public void Sort_WhenCalledWithRange_ReturnsSortedList<T>(List<T> list) where T : IComparable<T>
    {
        var expectedResult = new List<T>(list);
        expectedResult.Sort();
        
        var actual = _bubbleSort.Sort(list, 1, 3, Comparer<T>.Default);
        
        CollectionAssert.AreEqual(expectedResult, actual);
    }
    
    [Test]
    public void Sort_WhenCalledWithCustomComparerWithRange_ReturnsSortedList()
    {
        var list = TestCaseProvider.GetComparableObjectList();
        var comparer = new CustomComparableObjectComparer();
        var expectedResult = new List<ComparableObject>(list);
        expectedResult.Sort(1, 3, comparer);
        
        var actual = _bubbleSort.Sort(list, 1, 3, comparer);
        
        CollectionAssert.AreEqual(expectedResult, actual);
    }
    
    [Test]
    public void Sort_WhenCalledWithCustomComparison_ReturnsSortedList()
    {
        var list = TestCaseProvider.GetComparableObjectList();
        var comparison = new Comparison<ComparableObject>((x, y) =>
        {
            if (x.SomeOtherValue.Length > y.SomeOtherValue.Length)
            {
                return 1;
            }
            if (x.SomeOtherValue.Length == y.SomeOtherValue.Length)
            {
                return string.Compare(x.SomeOtherValue, y.SomeOtherValue, StringComparison.Ordinal);
            }

            return -1;
        });
        var expectedResult = new List<ComparableObject>(list);
        expectedResult.Sort(comparison);
        
        var actual = _bubbleSort.Sort(list, comparison);
        
        CollectionAssert.AreEqual(expectedResult, actual);
    }
}