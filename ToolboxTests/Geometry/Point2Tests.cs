using NUnit.Framework;
using ProjectEuler.Toolbox;
using System;
using System.Linq;

namespace ProjectEuler.ToolboxTests
{
    [TestFixture]
    public class Point2Tests
    {
        [Test]
        public void Point2()
        {
            var p = new Point2<long>(1, 2);

            Assert.AreEqual(1, p.X);
            Assert.AreEqual(2, p.Y);
        }

        [Test]
        public new void ToString()
        {
            var expected = "(1, 2)";
            var p = new Point2<long>(1, 2);
            var actual = p.ToString();

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Equals()
        {
            var p = new Point2<long>(1, 2);

            Assert.AreNotEqual(p, 1);
        }

        [Test]
        public void Equals2()
        {
            var p1 = new Point2<long>(1, 2);
            var p2 = new Point2<long>(1, 2);

            Assert.AreEqual(p1, p2);
        }

        [Test]
        public new void GetHashCode()
        {
            var expected = 3;
            var p = new Point2<long>(1, 2);
            var actual = p.GetHashCode();

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void op_Equals()
        {
            var p1 = new Point2<long>(1, 2);
            var p2 = new Point2<long>(1, 2);

            Assert.IsTrue(p1 == p2);
        }

        [Test]
        public void op_NotEquals()
        {
            var p1 = new Point2<long>(1, 2);
            var p2 = new Point2<long>(1, 3);

            Assert.IsTrue(p1 != p2);
        }
    }
}