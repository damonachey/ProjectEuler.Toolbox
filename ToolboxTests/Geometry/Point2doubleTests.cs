using ProjectEuler.Toolbox;
using Xunit;

namespace ProjectEuler.ToolboxTests;

public class Point2doubleTests
{
    [Fact]
    public void ToStringTest()
    {
        var expected = "(1, 2)";
        var p = new Point2double(1, 2);
        var actual = p.ToString();

        Assert.Equal(expected, actual);
    }
}
