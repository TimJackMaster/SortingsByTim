using Moq;
using TJMSorts;
using TJMSorts.Algorithms;

namespace TJMSortsTests;

internal class SorterTests
{
    private readonly Mock<ISortingAlgorithm> _mockSortingAlgorithm = new();
    private readonly ISorter _sorter;
    
    public SorterTests()
    {
        _sorter = new Sorter(_mockSortingAlgorithm.Object);
    }
    
    [Test]
    [TestCase(-1, 5)]
    [TestCase(5, -1)]
    [TestCase(100, -100)]
    public void Sort_WhenCalledWithOutOfRange_ThrowsArgumentOutOfRangeException(int startIndex, int count)
    {
        var list = TestCaseProvider.GetIntegerList(10);
        
        Assert.Throws<ArgumentOutOfRangeException>(() =>
            _sorter.Sort(list, startIndex, count, Comparer<int>.Default));
    }
    
    [Test]
    public void Sort_WhenCalledWithWrongParameterSum_ThrowsArgumentException()
    {
        var list = TestCaseProvider.GetIntegerList(10);
        
        Assert.Throws<ArgumentException>(() =>
            _sorter.Sort(list, 5, 6, Comparer<int>.Default));
    }
}