using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProjectEuler.Toolbox;
using System;
using System.Linq;

namespace ProjectEuler.ToolboxTests
{
    [TestClass]
    public class Point3Tests
    {
        [TestMethod]
        public void Point3()
        {
            var p = new Point3(1, 2, 3);

            Assert.AreEqual(1, p.X);
            Assert.AreEqual(2, p.Y);
            Assert.AreEqual(3, p.Z);
        }

        [TestMethod]
        public new void ToString()
        {
            var expected = "(1, 2, 3)";
            var p = new Point3(1, 2, 3);
            var actual = p.ToString();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Equals()
        {
            var p = new Point3(1, 2, 3);

            Assert.AreNotEqual(p, 1);
        }

        [TestMethod]
        public void Equals2()
        {
            var p1 = new Point3(1, 2, 3);
            var p2 = new Point3(1, 2, 3);

            Assert.AreEqual(p1, p2);
        }

        [TestMethod]
        public new void GetHashCode()
        {
            var expected = 1073217536;
            var p = new Point3(1, 2, 3);
            var actual = p.GetHashCode();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void op_Equals()
        {
            var p1 = new Point3(1, 2, 3);
            var p2 = new Point3(1, 2, 3);

            Assert.IsTrue(p1 == p2);
        }

        [TestMethod]
        public void op_NotEquals()
        {
            var p1 = new Point3(1, 2, 3);
            var p2 = new Point3(1, 2, 4);

            Assert.IsTrue(p1 != p2);
        }
    }
}