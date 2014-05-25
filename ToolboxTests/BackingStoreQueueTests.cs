using System.Linq;
using NUnit.Framework;
using ProjectEuler.Toolbox;

namespace ProjectEuler.ToolboxTests
{
    [TestFixture]
    public class BackingStoreQueueTests
    {
        [Test]
        public void Constructor()
        {
            var bsq = new CompressedQueue();

            Assert.IsNotNull(bsq);
        }

        [Test]
        public void Enqueue()
        {
            var expectedCount = 2 * CompressedQueue.CompressThreshold;
            var actual = new CompressedQueue();

            for (var i = 0; i < expectedCount; i++)
            {
                actual.Enqueue(i);
            }

            Assert.AreEqual(expectedCount, actual.Count);
        }

        [Test]
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
                Assert.AreEqual(expected, actual.Dequeue());
            }
        }
    }
}