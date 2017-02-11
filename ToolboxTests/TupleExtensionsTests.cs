using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProjectEuler.Toolbox;
using System;

namespace ProjectEuler.ToolboxTests
{
    [TestClass]
    public class TupleExtensionsTests
    {
        [TestMethod]
        public void Sum()
        {
            var expected = 123;
            var tuple = Tuple.Create(100, 20, 3);
            var actual = tuple.Sum();

            Assert.AreEqual(expected, actual);
        }
    }
}