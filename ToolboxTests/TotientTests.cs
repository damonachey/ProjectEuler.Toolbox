using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProjectEuler.Toolbox;
using System;

namespace ProjectEuler.ToolboxTests
{
    [TestClass]
    public class TotientTests
    {
        [TestMethod]
        public void PhiMaxSet()
        {
            var expected = 3852;
            var totient = new Totient(4800);
            var actual = totient.Phi(4501);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void PhiOne()
        {
            var expected = 1;
            var totient = new Totient(1);
            var actual = totient.Phi(1);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Phi()
        {
            var expected = 8;
            var totient = new Totient(100);
            var actual = totient.Phi(20);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void PhiGreaterThanN()
        {
            var totient = new Totient(10);
            totient.Phi(20);
        }

        [TestMethod]
        public void Phi2()
        {
            var expected = 10083087720778;
            var actual = Totient.Phi2(10083087720779);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void PhiPhi2()
        {
            var totient = new Totient(100);
            var expected = totient.Phi(20);
            var actual = Totient.Phi2(20);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void MaxnOverPhin()
        {
            var expected = 30;
            var actual = Totient.MaxnOverPhin(100);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void MinnOverPhin()
        {
            var expected = 49;
            var actual = Totient.MinnOverPhin(100);

            Assert.AreEqual(expected, actual);
        }
    }
}