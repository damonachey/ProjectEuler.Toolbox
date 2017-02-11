using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProjectEuler.Toolbox;
using System.Linq;

namespace ProjectEuler.ToolboxTests
{
    [TestClass]
    public class BaseTests
    {
        [TestMethod]
        public void ConvertBase10toBase2()
        {
            {
                var expected = new[] { 0, 0, 1, 1 };
                var actual = Base.Convert(12.ToDigits(), 10, 2);

                Assert.IsTrue(expected.SequenceEqual(actual));
            }
        }
    }
}