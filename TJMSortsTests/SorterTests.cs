using Moq;
using TJMSorts;
using TJMSorts.Algorithms;

namespace TJMSortsTests;

internal class SorterTests
{
    private readonly Mock<IAlgorithmProvider> _mockAlgorithmProvider = new();
    private readonly ISorter<int> _sorter;
    
    public SorterTests()
    {
        var options = SortingOptions<int>.Default;
        _sorter = new Sorter<int>(options, _mockAlgorithmProvider.Object);
    }
    
    [Test]
    [TestCase(-1, 5)]
    [TestCase(5, -1)]
    [TestCase(100, -100)]
    public void Sort_WhenCalledWithOutOfRange_ThrowsArgumentOutOfRangeException(int startIndex, int count)
    {
        var list = TestCaseProvider.GetIntegerList(10);
        
        Assert.Throws<ArgumentOutOfRangeException>(() =>
            _sorter.Sort(list, Comparer<int>.Default.Compare,  startIndex, count));
    }
    
    [Test]
    public void Sort_WhenCalledWithWrongParameterSum_ThrowsArgumentException()
    {
        var list = TestCaseProvider.GetIntegerList(10);
        
        Assert.Throws<ArgumentException>(() =>
            _sorter.Sort(list, Comparer<int>.Default.Compare, 5, 6));
    }
}