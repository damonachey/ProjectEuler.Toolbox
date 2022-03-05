using ProjectEuler.Toolbox;
using System.Linq;
using Xunit;

namespace ProjectEuler.ToolboxTests;

public class BackingStoreQueueTests
{
    [Fact]
    public void Constructor()
    {
        var bsq = new CompressedQueue();

        Assert.NotNull(bsq);
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
    }
}
