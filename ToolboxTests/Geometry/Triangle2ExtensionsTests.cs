using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProjectEuler.Toolbox;

namespace ProjectEuler.ToolboxTests
{
    [TestClass]
    public class Triangle2ExtensionsTests
    {
        [TestMethod]
        public void Area()
        {
            var expected = 1.5;
            var p1 = new Point2double(0, 0);
            var p2 = new Point2double(1, 1);
            var p3 = new Point2double(3, 0);
            var actual = new Triangle2double(p1, p2, p3).Area();

            Assert.AreEqual(expected, actual);
        }
    }
}