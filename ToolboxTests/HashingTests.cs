﻿using NUnit.Framework;
using ProjectEuler.Toolbox;
using System;
using System.Linq;

namespace ProjectEuler.ToolboxTests
{
    [TestFixture]
    public class HashingTests
    {
        [Test]
        public void ModifiedFnv32()
        {
            var expected = 2730030712;
            var actual = Hashing.ModifiedFnv32(new byte[] { 1, 2, 3 });

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void EvaluateRPN()
        {
            var expected = 8270004038646870267;
            var actual = Hashing.ModifiedFnv64(new byte[] { 1, 2, 3 });

            Assert.AreEqual(expected, actual);
        }
    }
}