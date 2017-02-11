using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProjectEuler.Toolbox;
using System.Linq;

namespace ProjectEuler.ToolboxTests
{
    [TestClass]
    public class BackingStoreQueueTests
    {
        [TestMethod]
        public void Constructor()
        {
            var bsq = new CompressedQueue();

            Assert.IsNotNull(bsq);
        }

        [TestMethod]
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

        [TestMethod]
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