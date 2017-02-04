﻿using NUnit.Framework;
using ProjectEuler.Toolbox;
using System;
using System.Linq;

namespace ProjectEuler.ToolboxTests
{
    [TestFixture]
    public class LinearAssignmentProblemTests
    {
        [Test]
        public void FindAssignmentsNull()
        {
            Assert.Throws<ArgumentNullException>(() => LinearAssignmentProblem
                .HungarianAlgorithm
                .FindAssignments(null));
        }

        [Test]
        public void FindAssignments()
        {
            var expected = new[] { 4, 1, 2, 3, 0 };
            var actual = LinearAssignmentProblem
                .HungarianAlgorithm
                .FindAssignments(Parsers.ParseIntGrid(@"
                      -7  -53 -183 -439 -863
                    -497 -383 -563  -79 -973
                    -287  -63 -343 -169 -583
                    -627 -343 -773 -959 -943
                    -767 -473 -103 -699 -303
                    "));

            Assert.AreEqual(expected, actual);
        }
    }
}