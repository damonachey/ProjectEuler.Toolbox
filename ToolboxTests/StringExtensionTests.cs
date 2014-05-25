using NUnit.Framework;
using ProjectEuler.Toolbox;
using System;

namespace ProjectEuler.ToolboxTests
{
    [TestFixture]
    public class StringExtensionTests
    {
        [Test]
        public void SubstringFound()
        {
            var expected = " a midnight ";
            var actual = "Once upon a midnight dreary".Substring("upon", "dreary");

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void SubstringStartNotFound()
        {
            Assert.Throws<ArgumentException>(() => "Once upon a midnight dreary".Substring("upn", "dreary"));
        }

        [Test]
        public void SubstringEndNotFound()
        {
            Assert.Throws<ArgumentException>(() => "Once upon a midnight dreary".Substring("upon", "drery"));
        }

        [Test]
        public void TestRandomString()
        {
            var s1 = StringExtensions.RandomString();
            var s2 = StringExtensions.RandomString();

            Assert.AreNotEqual(s1, s2);
        }
    }
}