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
            var totient = new Totient(4000);
            var actual = totient.Phi(4501);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void PhiOne()
        {
            var expected = 1;
            var totient = new Totient();
            var actual = totient.Phi(1);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Phi()
        {
            var expected = 8;
            var totient = new Totient();
            var actual = totient.Phi(20);

            Assert.AreEqual(expected, actual);
        }
    }
}