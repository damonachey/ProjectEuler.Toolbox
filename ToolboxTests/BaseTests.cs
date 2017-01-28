using NUnit.Framework;
using ProjectEuler.Toolbox;
using System.Linq;

namespace ProjectEuler.ToolboxTests
{
    [TestFixture]
    public class BaseTests
    {
        [Test]
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