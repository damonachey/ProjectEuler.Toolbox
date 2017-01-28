﻿using NUnit.Framework;
using ProjectEuler.Toolbox;
using System;
using System.Linq;

namespace ProjectEuler.ToolboxTests
{
    [TestFixture]
    public class GeometryTests
    {
        [Test]
        public void Diamonds()
        {
            var expected = 3669546;
            var actual = Geometry.Diamonds(77, 36);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void PointInTriangleTrue()
        {
            var actual = Geometry.IsPointInTriangle(
                new Microsoft.Xna.Framework.Vector3(0),
                new Microsoft.Xna.Framework.Vector3(0, 1, 0),
                new Microsoft.Xna.Framework.Vector3(1, -1, 0),
                new Microsoft.Xna.Framework.Vector3(-1, -1, 0));

            Assert.IsTrue(actual);
        }

        [Test]
        public void PointInTriangleFalse()
        {
            var actual = Geometry.IsPointInTriangle(
                new Microsoft.Xna.Framework.Vector3(2, 0, 0),
                new Microsoft.Xna.Framework.Vector3(0, 1, 0),
                new Microsoft.Xna.Framework.Vector3(1, -1, 0),
                new Microsoft.Xna.Framework.Vector3(-1, -1, 0));

            Assert.IsFalse(actual);
        }

        [Test]
        public void PythagoreanTriples()
        {
            var expected = new Tuple<int, int, int>[]
                {
                    Tuple.Create(3, 4, 5),
                    Tuple.Create(6, 8, 10),
                    Tuple.Create(9, 12, 15),
                    Tuple.Create(8, 15, 17),
                    Tuple.Create(5, 12, 13),
                };

            var actual = Geometry.PythagoreanTriples(42);

            Assert.IsTrue(expected.SequenceEqual(actual));
        }

        [Test]
        public void Distance()
        {
            var expected = new BigRational(5);
            var p1 = new Point2<BigRational>(1, 2);
            var p2 = new Point2<BigRational>(4, 6);
            var actual = Geometry.Distance(p1, p2);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Side()
        {
            var expected = -5;
            var p1 = new Point2<long>(1, 2);
            var p2 = new Point2<long>(4, 6);
            var p3 = new Point2<long>(3, 3);
            var actual = Geometry.Side(p1, p2, p3);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Rectangles()
        {
            var expected = 1999998;
            var actual = Geometry.Rectangles(77, 36);

            Assert.AreEqual(expected, actual);
        }
    }
}