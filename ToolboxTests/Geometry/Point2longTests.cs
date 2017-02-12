using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProjectEuler.Toolbox;

namespace ProjectEuler.ToolboxTests
{
    [TestClass]
    public class Point2longTests
    {
        [TestMethod]
        public void Point2long()
        {
            var p = new Point2long(1, 2);

            Assert.AreEqual(1, p.X);
            Assert.AreEqual(2, p.Y);
        }

        [TestMethod]
        public new void ToString()
        {
            var expected = "(1, 2)";
            var p = new Point2long(1, 2);
            var actual = p.ToString();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void EqualsObjectFalse()
        {
            var p = new Point2long(1, 2);

            Assert.IsFalse(p.Equals(1));
        }

        [TestMethod]
        public void EqualsObjectFalse2()
        {
            var p1 = new Point2long(2, 2);
            var p2 = new Point2long(1, 2);

            Assert.IsFalse(p1.Equals((object)p2));
        }

        [TestMethod]
        public void EqualsObjectTrue()
        {
            var p1 = new Point2long(1, 2);
            var p2 = new Point2long(1, 2);

            Assert.IsTrue(p1.Equals((object)p2));
        }

        [TestMethod]
        public void EqualsPoint2longFalse()
        {
            var p1 = new Point2long(2, 2);
            var p2 = new Point2long(1, 2);

            Assert.IsFalse(p1.Equals(p2));
        }

        [TestMethod]
        public void EqualsPoint2longTrue()
        {
            var p1 = new Point2long(1, 2);
            var p2 = new Point2long(1, 2);

            Assert.IsTrue(p1.Equals(p2));
        }

        [TestMethod]
        public new void GetHashCode()
        {
            var expected = 3;
            var p = new Point2long(1, 2);
            var actual = p.GetHashCode();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void OperatorEqualsFalse()
        {
            var p1 = new Point2long(1, 2);
            var p2 = new Point2long(1, 3);

            Assert.IsFalse(p1 == p2);
        }

        [TestMethod]
        public void OperatorEqualsTrue()
        {
            var p1 = new Point2long(1, 2);
            var p2 = new Point2long(1, 2);

            Assert.IsTrue(p1 == p2);
        }

        [TestMethod]
        public void OperatorNotEqualsFalse()
        {
            var p1 = new Point2long(1, 2);
            var p2 = new Point2long(1, 2);

            Assert.IsFalse(p1 != p2);
        }

        [TestMethod]
        public void OperatorNotEqualsTrue()
        {
            var p1 = new Point2long(1, 2);
            var p2 = new Point2long(1, 3);

            Assert.IsTrue(p1 != p2);
        }
    }
}