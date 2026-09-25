using ProjectEuler.Toolbox;
using System.Linq;
using Xunit;

namespace ProjectEuler.ToolboxTests;

public class CompressedQueueTests
{
    [Fact]
    public void Constructor()
    {
        var actual = new CompressedQueue();

        Assert.Equal(0, actual.Count);
    }

    [Fact]
    public void Enqueue()
    {
        var expectedCount = 2 * CompressedQueue.CompressThreshold;
        var actual = new CompressedQueue();

        for (var i = 0; i < expectedCount; i++)
        {
            actual.Enqueue(i);
        }

        Assert.Equal(expectedCount, actual.Count);
    }

    [Fact]
    public void Dequeue()
    {
        var expectedCount = 2 * CompressedQueue.CompressThreshold;
        var expectedList = Enumerable.Range(0, expectedCount);
        var actual = new CompressedQueue();

        for (var i = 0; i < expectedCount; i++)
        {
            actual.Enqueue(i);
        }

        foreach (var expected in expectedList)
        {
            Assert.Equal(expected, actual.Dequeue());
        }

        Assert.Equal(0, actual.Count);
    }
}