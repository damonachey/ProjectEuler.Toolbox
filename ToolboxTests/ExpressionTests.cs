using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProjectEuler.Toolbox;
using System;
using System.Linq;

namespace ProjectEuler.ToolboxTests
{
    [TestClass]
    public class ExpressionTests
    {
        [TestMethod]
        public void Evaluate()
        {
            var expected = 7;
            var actual = Expression.Evaluate("1 + (2 * 3)");

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void EvaluateRPN()
        {
            var expected = 7;
            var actual = Expression.EvaluateRPN("3 2 * 1 +");

            Assert.AreEqual(expected, actual);
        }
    }
}