using NUnit.Framework;
using ProjectEuler.Toolbox;
using System;

namespace ProjectEuler.ToolboxTests
{
    [TestFixture]
    public class SimilarityTests
    {
        [Test]
        public void EditDistanceString()
        {
            var expected = 2;
            var actual = Similarity.EditDistance("this is just a test", "this was just a test");

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void EditDistanceEnumerable()
        {
            var expected = 2;
            var actual = Similarity.EditDistance("this is just a test".ToCharArray(), "this was just a test".ToCharArray());

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void EditDistanceSame()
        {
            var expected = 0;
            var actual = Similarity.EditDistance("this is just a test".ToCharArray(), "this is just a test".ToCharArray());

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void EditDistanceBadArguments()
        {
            Assert.Throws<ArgumentNullException>(() =>Similarity.EditDistance(null, "this is just a test".ToCharArray()));
        }

        [Test]
        public void EditDistanceBadArguments2()
        {
            Assert.Throws<ArgumentNullException>(() =>Similarity.EditDistance("this is just a test".ToCharArray(), null));
        }

        [Test]
        public void EditDistanceEmpty()
        {
            var expected = 19;
            var actual = Similarity.EditDistance("this is just a test".ToCharArray(), "".ToCharArray());

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void EditDistanceEmpty2()
        {
            var expected = 19;
            var actual = Similarity.EditDistance("".ToCharArray(), "this is just a test".ToCharArray());

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void EditDistanceStringBadArguments()
        {
            Assert.Throws<ArgumentNullException>(() => Similarity.EditDistance(null, "this is just a test"));
        }

        [Test]
        public void EditDistanceStringBadArguments2()
        {
            Assert.Throws<ArgumentNullException>(() => Similarity.EditDistance("this is just a test", null));
        }

        [Test]
        public void EditDistanceStringEmpty()
        {
            var expected = 19;
            var actual = Similarity.EditDistance("this is just a test", "");

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void EditDistanceStringEmpty2()
        {
            var expected = 19;
            var actual = Similarity.EditDistance("", "this is just a test");

            Assert.AreEqual(expected, actual);
        }
    }
}