using NUnit.Framework;
using ProjectEuler.Toolbox;
using System.Linq;

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
                Assert.AreEqual(primes[i], p2[i]);
        }

        [Test]
        public void Primes()
        {
            var expected = 15485863;
            var actual = PrimeHelper.Primes().Skip(1000000 - 1).First();

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void PrimesMax()
        {
            var last = 0L;
            var count = 0L;

            try
            {
                foreach (var prime in PrimeHelper.Primes())
                {
                    last = prime;
                    count++;
                }
            }
            catch { };

            Assert.AreEqual(2147483647, last);
            Assert.AreEqual(105097565, count);
        }
    }
}