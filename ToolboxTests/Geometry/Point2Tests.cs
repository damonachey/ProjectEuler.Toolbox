using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProjectEuler.Toolbox;
using System;
using System.Linq;

namespace ProjectEuler.ToolboxTests
{
    [TestClass]
    public class Point2Tests
    {
        [TestMethod]
        public void Point2()
        {
            var p = new Point2(1, 2);

            Assert.AreEqual(1, p.X);
            Assert.AreEqual(2, p.Y);
        }

        [TestMethod]
        public new void ToString()
        {
            var expected = "(1, 2)";
            var p = new Point2(1, 2);
            var actual = p.ToString();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void EqualsFalse()
        {
            var p = new Point2(1, 2);

            Assert.AreNotEqual(p, 1);
        }

        [TestMethod]
        public void EqualsFalse2()
        {
            var p1 = new Point2(2, 2);
            var p2 = new Point2(1, 2);

            Assert.AreNotEqual(p1, p2);
        }

        [TestMethod]
        public void EqualsTrue()
        {
            var p1 = new Point2(1, 2);
            var p2 = new Point2(1, 2);

            Assert.AreEqual(p1, p2);
        }

        [TestMethod]
        public new void GetHashCode()
        {
            var expected = 2146435072;
            var p = new Point2(1, 2);
            var actual = p.GetHashCode();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void op_Equals()
        {
            var p1 = new Point2(1, 2);
            var p2 = new Point2(1, 2);

            Assert.IsTrue(p1 == p2);
        }

        [TestMethod]
        public void op_NotEquals()
        {
            var p1 = new Point2(1, 2);
            var p2 = new Point2(1, 3);

            Assert.IsTrue(p1 != p2);
        }
    }
}