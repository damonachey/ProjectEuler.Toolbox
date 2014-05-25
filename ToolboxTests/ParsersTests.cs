using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using ProjectEuler.Toolbox;

namespace ProjectEuler.ToolboxTests
{
    [TestFixture]
    public class ParsersTests
    {
        [Test]
        public void ParseStringLists()
        {
            var expected = new List<List<string>>
                {
                    new List<string>{ "1", "2", "3", "4" },
                    new List<string>{ "5", "6", "7", "8" },
                };
            var actual = Parsers.ParseStringLists(@"
                    1 2 3 4
                    5 6 7 8
                    ");

            Assert.IsTrue(expected.SelectMany(sequence => sequence).SequenceEqual(actual.SelectMany(sequence => sequence)));
        }

        [Test]
        public void ParseStringList()
        {
            var expected = new List<string>
                {
                    "1 2 3 4",
                    "5 6 7 8",
                };
            var actual = Parsers.ParseStringList(@"
                    1 2 3 4
                    5 6 7 8
                    ")
                .Select(str => str.Trim());

            Assert.IsTrue(expected.SequenceEqual(actual));
        }

        [Test]
        public void ParseLongLists()
        {
            var expected = new List<List<long>>
                {
                    new List<long>{ 1, 2, 3, 4 },
                    new List<long>{ 5, 6, 7, 8 },
                };
            var actual = Parsers.ParseLongLists(@"
                    1 2 3 4
                    5 6 7 8
                    ");

            Assert.IsTrue(expected.SelectMany(sequence => sequence).SequenceEqual(actual.SelectMany(sequence => sequence)));
        }

        [Test]
        public void ParseLongGrid()
        {
            var expected = new int[,] { { 1, 5 }, { 2, 6 }, { 3, 7 }, { 4, 8 } };
            var actual = Parsers.ParseIntGrid(@"
                    1 2 3 4
                    5 6 7 8
                    ");

            for (var i = 0; i < expected.GetLength(0); i++)
            {
                for (int j = 0; j < expected.GetLength(1); j++)
                {
                    Assert.AreEqual(expected[i, j], actual[i, j]);
                }
            }
        }

        [Test]
        public void ParseIntGrid()
        {
            var expected = new long[,] { { 1, 5 }, { 2, 6 }, { 3, 7 }, { 4, 8 } };
            var actual = Parsers.ParseLongGrid(@"
                    1 2 3 4
                    5 6 7 8
                    ");

            for (var i = 0; i < expected.GetLength(0); i++)
            {
                for (int j = 0; j < expected.GetLength(1); j++)
                {
                    Assert.AreEqual(expected[i, j], actual[i, j]);
                }
            }
        }
    }
}