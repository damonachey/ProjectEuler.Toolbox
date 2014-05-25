using System.Linq;
using System.Numerics;
using NUnit.Framework;
using ProjectEuler.Toolbox;

namespace ProjectEuler.ToolboxTests
{
    [TestFixture]
    public class PrimeHelperTests
    {
        [Test]
        public void IsPrimeLessThan2()
        {
            var actual = PrimeHelper.IsPrime(1);

            Assert.IsFalse(actual);
        }

        [Test]
        public void IsPrime2To4()
        {
            var actual = PrimeHelper.IsPrime(3);

            Assert.IsTrue(actual);
        }

        [Test]
        public void IsPrimeOdds4To9()
        {
            var actual = PrimeHelper.IsPrime(7);

            Assert.IsTrue(actual);
        }

        [Test]
        public void IsPrimeEven()
        {
            var actual = PrimeHelper.IsPrime(10);

            Assert.IsFalse(actual);
        }

        [Test]
        public void IsPrimeMultipleOfThree()
        {
            var actual = PrimeHelper.IsPrime(51);

            Assert.IsFalse(actual);
        }

        [Test]
        public void IsPrimeSquare()
        {
            var actual = PrimeHelper.IsPrime(25);

            Assert.IsFalse(actual);
        }

        [Test]
        public void IsPrimePrime()
        {
            var actual = PrimeHelper.IsPrime(8219);

            Assert.IsTrue(actual);
        }

        [Test]
        public void IsPrimeNotPrime()
        {
            var actual = PrimeHelper.IsPrime(8227);

            Assert.IsFalse(actual);
        }

        [Test]
        public void IsPrimeMemoized()
        {
            var actual = PrimeHelper.IsPrimeMemoized(8227);

            Assert.IsFalse(actual);
        }

        [Test]
        public void PrimesRepeatability()
        {
            var primes = PrimeHelper.Primes().Take(20).ToList();
            var p2 = PrimeHelper.Primes().Take(20).ToList();

            for (var i = 0; i < p2.Count(); i++)
                if (primes[i] != p2[i])
                    Assert.Fail("Oops");
        }

        [Test]
        public void Primes()
        {
            var expected = 15485863;
            var actual = PrimeHelper.Primes().Skip(1000000 - 1).First();

            Assert.AreEqual(expected, actual);
        }
    }
}