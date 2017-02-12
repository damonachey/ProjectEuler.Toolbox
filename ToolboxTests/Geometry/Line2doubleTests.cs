using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProjectEuler.Toolbox;
using System;

namespace ProjectEuler.ToolboxTests
{
    [TestClass]
    public class Line2doubleTests
    {
        [TestMethod]
        public void Line2doubleConstructorPointPoint()
        {
            var p1 = new Point2double(1, 2);
            var p2 = new Point2double(3, 4);
            var actual = new Line2double(p1, p2);

            Assert.AreEqual(p1, actual.P1);
            Assert.AreEqual(p2, actual.P2);
        }

        [TestMethod]
        public void Line2doubleConstructorPointSlope()
        {
            var p1 = new Point2double(1, 2);
            var p2 = new Point2double(0, 1.5);
            var slope = 0.5;
            var actual = new Line2double(p1, slope);

            Assert.AreEqual(p1, actual.P1);
            Assert.AreEqual(p2, actual.P2);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Line2doubleConstructorSlopeInfinate()
        {
            var p1 = new Point2double(0, 2);
            var p2 = new Point2double(0, 1.5);
            var slope = 0.5;

            new Line2double(p1, slope);
        }

        [TestMethod]
        public new void ToString()
        {
            var expected = "((1, 2), (3, 4))";
            var p1 = new Point2double(1, 2);
            var p2 = new Point2double(3, 4);
            var actual = new Line2double(p1, p2).ToString();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void EqualsObjectFalse()
        {
            var p1 = new Point2double(1, 2);
            var p2 = new Point2double(3, 4);
            var p3 = new Point2double(5, 5);
            var l1 = new Line2double(p1, p2);
            var l2 = new Line2double(p1, p3);

            Assert.IsFalse(l1.Equals((object)l2));
        }

        [TestMethod]
        public void EqualsObjectTrue()
        {
            var p1 = new Point2double(1, 2);
            var p2 = new Point2double(3, 4);
            var l1 = new Line2double(p1, p2);
            var l2 = new Line2double(p1, p2);

            Assert.IsTrue(l1.Equals((object)l2));
        }

        [TestMethod]
        public void EqualsLine2doubleFalse()
        {
            var p1 = new Point2double(1, 2);
            var p2 = new Point2double(3, 4);
            var p3 = new Point2double(5, 5);
            var l1 = new Line2double(p1, p2);
            var l2 = new Line2double(p1, p3);

            Assert.IsFalse(l1.Equals(l2));
        }

        [TestMethod]
        public void EqualsLine2doubleTrue()
        {
            var p1 = new Point2double(1, 2);
            var p2 = new Point2double(3, 4);
            var l1 = new Line2double(p1, p2);
            var l2 = new Line2double(p1, p2);

            Assert.IsTrue(l1.Equals(l2));
        }

        [TestMethod]
        public new void GetHashCode()
        {
            var expected = 2145910784;
            var p1 = new Point2double(1, 2);
            var p2 = new Point2double(3, 4);
            var actual = new Line2double(p1, p2).GetHashCode();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void OperatorEqualsFalse()
        {
            var p1 = new Point2double(1, 2);
            var p2 = new Point2double(3, 4);
            var p3 = new Point2double(5, 5);
            var l1 = new Line2double(p1, p2);
            var l2 = new Line2double(p1, p3);

            Assert.IsFalse(l1 == l2);
        }

        [TestMethod]
        public void OperatorEqualsTrue()
        {
            var p1 = new Point2double(1, 2);
            var p2 = new Point2double(3, 4);
            var l1 = new Line2double(p1, p2);
            var l2 = new Line2double(p1, p2);

            Assert.IsTrue(l1 == l2);
        }

        [TestMethod]
        public void OperatorNotEqualsFalse()
        {
            var p1 = new Point2double(1, 2);
            var p2 = new Point2double(3, 4);
            var l1 = new Line2double(p1, p2);
            var l2 = new Line2double(p1, p2);

            Assert.IsFalse(l1 != l2);
        }

        [TestMethod]
        public void OperatorNotEqualsTrue()
        {
            var p1 = new Point2double(1, 2);
            var p2 = new Point2double(3, 4);
            var p3 = new Point2double(5, 5);
            var l1 = new Line2double(p1, p2);
            var l2 = new Line2double(p1, p3);

            Assert.IsTrue(l1 != l2);
        }
    }
}