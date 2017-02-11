using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProjectEuler.Toolbox;
using System;

namespace ProjectEuler.ToolboxTests
{
    [TestClass]
    public class SimilarityTests
    {
        [TestMethod]
        public void EditDistanceString()
        {
            var expected = 2;
            var actual = Similarity.EditDistance("this is just a test", "this was just a test");

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void EditDistanceEnumerable()
        {
            var expected = 2;
            var actual = Similarity.EditDistance("this is just a test".ToCharArray(), "this was just a test".ToCharArray());

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void EditDistanceSame()
        {
            var expected = 0;
            var actual = Similarity.EditDistance("this is just a test".ToCharArray(), "this is just a test".ToCharArray());

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void EditDistanceBadArguments()
        {
            Similarity.EditDistance(null, "this is just a test".ToCharArray());
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void EditDistanceBadArguments2()
        {
            Similarity.EditDistance("this is just a test".ToCharArray(), null);
        }

        [TestMethod]
        public void EditDistanceEmpty()
        {
            var expected = 19;
            var actual = Similarity.EditDistance("this is just a test".ToCharArray(), "".ToCharArray());

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void EditDistanceEmpty2()
        {
            var expected = 19;
            var actual = Similarity.EditDistance("".ToCharArray(), "this is just a test".ToCharArray());

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void EditDistanceStringBadArguments()
        {
            Similarity.EditDistance(null, "this is just a test");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void EditDistanceStringBadArguments2()
        {
            Similarity.EditDistance("this is just a test", null);
        }

        [TestMethod]
        public void EditDistanceStringEmpty()
        {
            var expected = 19;
            var actual = Similarity.EditDistance("this is just a test", "");

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void EditDistanceStringEmpty2()
        {
            var expected = 19;
            var actual = Similarity.EditDistance("", "this is just a test");

            Assert.AreEqual(expected, actual);
        }
    }
}