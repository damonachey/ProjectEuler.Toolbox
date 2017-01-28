using NUnit.Framework;
using ProjectEuler.Toolbox;

namespace ProjectEuler.ToolboxTests
{
    [TestFixture]
    public class TotientTests
    {
        [Test]
        public void PhiMaxSet()
        {
            var expected = 3852;
            var totient = new Totient(4800);
            var actual = totient.Phi(4501);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void PhiOne()
        {
            var expected = 1;
            var totient = new Totient(1);
            var actual = totient.Phi(1);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Phi()
        {
            var expected = 8;
            var totient = new Totient(100);
            var actual = totient.Phi(20);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Phi2()
        {
            var expected = 10083087720778;
            var actual = Totient.Phi2(10083087720779);

            Assert.AreEqual(expected, actual);
        }

        [Test, Timeout(2000)]
        public void PhiPhi2()
        {
            var totient = new Totient(100830877);
            var expected = totient.Phi(100830877);
            var actual = Totient.Phi2(100830877);

            Assert.AreEqual(expected, actual);
        }
    }
}