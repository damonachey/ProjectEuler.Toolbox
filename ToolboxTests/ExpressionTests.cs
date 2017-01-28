using NUnit.Framework;
using ProjectEuler.Toolbox;
using System;
using System.Linq;

namespace ProjectEuler.ToolboxTests
{
    [TestFixture]
    public class ExpressionTests
    {
        [Test]
        public void Evaluate()
        {
            var expected = 7;
            var actual = Expression.Evaluate("1 + (2 * 3)");

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void EvaluateRPN()
        {
            var expected = 7;
            var actual = Expression.EvaluateRPN("3 2 * 1 +");

            Assert.AreEqual(expected, actual);
        }
    }
}