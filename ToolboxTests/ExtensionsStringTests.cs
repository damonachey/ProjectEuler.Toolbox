using NUnit.Framework;
using ProjectEuler.Toolbox;

namespace ProjectEuler.ToolboxTests
{
    [TestFixture]
    public class ExtensionsStringTests
    {
        [Test]
        public void Replace()
        {
            var expected = "testing";
            var actual = "tasting".Replace(1, 'e');

            Assert.AreEqual(expected, actual);
        }
    }
}