using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProjectEuler.Toolbox;

namespace ProjectEuler.ToolboxTests
{
    [TestClass]
    public class StringExtensionsTests
    {
        [TestMethod]
        public void Replace()
        {
            var expected = "testing";
            var actual = "tasting".Replace(1, 'e');

            Assert.AreEqual(expected, actual);
        }
    }
}