using NUnit.Framework;
using ProjectEuler.Toolbox;
using System.Linq;

namespace ProjectEuler.ToolboxTests
{
    [TestFixture]
    public class BigRationalExtensionsTests
    {
        [Test]
        public void ToBigRationalsIrrational()
        {
            var expected = new[]
                {
                    new BigRational(1, 1),
                    new BigRational(3, 2),
                    new BigRational(7, 5),
                    new BigRational(17, 12),
                    new BigRational(41, 29),
                };
            var actual = new[] { 1, 2 }.ToBigRationals().Take(expected.Length);

            Assert.IsTrue(expected.SequenceEqual(actual));
        }

        [Test]
        public void ToBigRationalsPerfectSquareTest1()
        {
            var expected = new[]
                {
                    new BigRational(5, 1),
                };
            var actual = new[] { 5 }.ToBigRationals();

            Assert.IsTrue(expected.SequenceEqual(actual));
        }

        [Test]
        public void ToBigRationalsIrrationalTest2()
        {
            var expected = new[]
                {
                    new BigRational(1, 1),
                    new BigRational(3, 2),
                    new BigRational(7, 5),
                    new BigRational(17, 12),
                    new BigRational(41, 29),
                };
            var actual = new[] { 1, 2 }.ToBigRationals().Take(expected.Length);

            Assert.IsTrue(expected.SequenceEqual(actual));
        }

        [Test]
        public void ToBigRationalsPerfectSquareTest3()
        {
            var expected = new[]
                {
                    new BigRational(5, 1),
                };
            var actual = new[] { 5 }.ToBigRationals();

            Assert.IsTrue(expected.SequenceEqual(actual));
        }

        [Test]
        public void ToBigRationalsE()
        {
            var expected = new[]
                {
                    new BigRational(2), 
                    new BigRational(3), 
                    new BigRational(8, 3), 
                    new BigRational(11, 4), 
                    new BigRational(19, 7), 
                    new BigRational(87, 32),
                    new BigRational(106, 39), 
                    new BigRational(193, 71), 
                    new BigRational(1264 ,465), 
                    new BigRational(1457, 536), 
                    new BigRational(2721, 1001), 
                    new BigRational(23225, 8544), 
                    new BigRational(25946, 9545),
                    new BigRational(49171, 18089),
                    new BigRational(517656, 190435),
                    new BigRational(566827, 208524),
                    new BigRational(1084483, 398959),
                    new BigRational(13580623, 4996032),
                    new BigRational(14665106, 5394991),
                    new BigRational(28245729, 10391023),
                };
            var actual = new[] { 2, 1, 2, 1, 1, 4, 1, 1, 6, 1, 1, 8, 1, 1, 10, 1, 1, 12, 1, 1 }.ToBigRationals().Take(expected.Length);

            Assert.IsTrue(expected.SequenceEqual(actual));
        }
    }
}