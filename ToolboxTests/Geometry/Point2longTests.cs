using ProjectEuler.Toolbox;
using Xunit;

namespace ProjectEuler.ToolboxTests;

public class Point2longTests
{
    [Fact]
    public void ToStringTest()
    {
        var expected = "(1, 2)";
        var p = new Point2long(1, 2);
        var actual = p.ToString();

        Assert.Equal(expected, actual);
    }
}
