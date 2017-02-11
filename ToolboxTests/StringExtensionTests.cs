using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProjectEuler.Toolbox;
using System;

namespace ProjectEuler.ToolboxTests
{
    [TestClass]
    public class StringExtensionTests
    {
        [TestMethod]
        public void SubstringFound()
        {
            var expected = " a midnight ";
            var actual = "Once upon a midnight dreary".Substring("upon", "dreary");

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void SubstringStartNotFound()
        {
            "Once upon a midnight dreary".Substring("upn", "dreary");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void SubstringEndNotFound()
        {
            "Once upon a midnight dreary".Substring("upon", "drery");
        }

        [TestMethod]
        public void TestRandomString()
        {
            var s1 = StringExtensions.RandomString();
            var s2 = StringExtensions.RandomString();

            Assert.AreNotEqual(s1, s2);
        }
    }
}