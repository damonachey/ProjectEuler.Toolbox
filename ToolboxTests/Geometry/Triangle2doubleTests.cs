using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProjectEuler.Toolbox;

namespace ProjectEuler.ToolboxTests
{
    [TestClass]
    public class Triangle2doubleTests
    {
        [TestMethod]
        public void Triangle2doubleConstructor()
        {
            var p1 = new Point2double(1, 2);
            var p2 = new Point2double(3, 4);
            var p3 = new Point2double(5, 6);
            var actual = new Triangle2double(p1, p2, p3);

            Assert.AreEqual(p1, actual.P1);
            Assert.AreEqual(p2, actual.P2);
            Assert.AreEqual(p3, actual.P3);
        }

        [TestMethod]
        public new void ToString()
        {
            var expected = "((1, 2), (3, 4), (5, 6))";
            var p1 = new Point2double(1, 2);
            var p2 = new Point2double(3, 4);
            var p3 = new Point2double(5, 6);
            var actual = new Triangle2double(p1, p2, p3).ToString();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void EqualsObjectFalse()
        {
            var p1 = new Point2double(1, 2);
            var p2 = new Point2double(3, 4);
            var p3 = new Point2double(5, 6);
            var p4 = new Point2double(7, 8);
            var t1 = new Triangle2double(p1, p2, p3);
            var t2 = new Triangle2double(p1, p2, p4);

            Assert.IsFalse(t1.Equals((object)t2));
        }

        [TestMethod]
        public void EqualsObjectTrue()
        {
            var p1 = new Point2double(1, 2);
            var p2 = new Point2double(3, 4);
            var p3 = new Point2double(5, 6);
            var t1 = new Triangle2double(p1, p2, p3);
            var t2 = new Triangle2double(p1, p2, p3);

            Assert.IsTrue(t1.Equals((object)t2));
        }

        [TestMethod]
        public void EqualsTriangle2doubleFalse()
        {
            var p1 = new Point2double(1, 2);
            var p2 = new Point2double(3, 4);
            var p3 = new Point2double(5, 6);
            var p4 = new Point2double(7, 8);
            var t1 = new Triangle2double(p1, p2, p3);
            var t2 = new Triangle2double(p1, p2, p4);

            Assert.IsFalse(t1.Equals(t2));
        }

        [TestMethod]
        public void EqualsTriangle2doubleTrue()
        {
            var p1 = new Point2double(1, 2);
            var p2 = new Point2double(3, 4);
            var p3 = new Point2double(5, 6);
            var t1 = new Triangle2double(p1, p2, p3);
            var t2 = new Triangle2double(p1, p2, p3);

            Assert.IsTrue(t1.Equals(t2));
        }

        [TestMethod]
        public new void GetHashCode()
        {
            var expected = 2145648640;
            var p1 = new Point2double(1, 2);
            var p2 = new Point2double(3, 4);
            var p3 = new Point2double(5, 6);
            var actual = new Triangle2double(p1, p2, p3).GetHashCode();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void OperatorEqualsFalse()
        {
            var p1 = new Point2double(1, 2);
            var p2 = new Point2double(3, 4);
            var p3 = new Point2double(5, 6);
            var p4 = new Point2double(7, 8);
            var t1 = new Triangle2double(p1, p2, p3);
            var t2 = new Triangle2double(p1, p2, p4);

            Assert.IsFalse(t1 == t2);
        }

        [TestMethod]
        public void OperatorEqualsTrue()
        {
            var p1 = new Point2double(1, 2);
            var p2 = new Point2double(3, 4);
            var p3 = new Point2double(5, 6);
            var t1 = new Triangle2double(p1, p2, p3);
            var t2 = new Triangle2double(p1, p2, p3);

            Assert.IsTrue(t1 == t2);
        }

        [TestMethod]
        public void OperatorNotEqualsFalse()
        {
            var p1 = new Point2double(1, 2);
            var p2 = new Point2double(3, 4);
            var p3 = new Point2double(5, 6);
            var t1 = new Triangle2double(p1, p2, p3);
            var t2 = new Triangle2double(p1, p2, p3);

            Assert.IsFalse(t1 != t2);
        }

        [TestMethod]
        public void OperatorNotEqualsTrue()
        {
            var p1 = new Point2double(1, 2);
            var p2 = new Point2double(3, 4);
            var p3 = new Point2double(5, 6);
            var p4 = new Point2double(7, 8);
            var t1 = new Triangle2double(p1, p2, p3);
            var t2 = new Triangle2double(p1, p2, p4);

            Assert.IsTrue(t1 != t2);
        }
    }
}