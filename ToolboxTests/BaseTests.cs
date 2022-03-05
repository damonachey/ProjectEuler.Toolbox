using ProjectEuler.Toolbox;
using System.Linq;
using Xunit;

namespace ProjectEuler.ToolboxTests;

public class BaseTests
{
    [Fact]
    public void ConvertBase10toBase2()
    {
        {
            var expected = new[] { 0, 0, 1, 1 };
            var actual = Base.Convert(12.ToDigits(), 10, 2);

            Assert.True(expected.SequenceEqual(actual));
        }
    }
}
