using ProjectEuler.Toolbox;
using Xunit;

namespace ProjectEuler.ToolboxTests;

public class ExpressionTests
{
    [Fact]
    public void Evaluate()
    {
        var expected = 7;
        var actual = Expression.Evaluate("1 + (2 * 3)");

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void EvaluateRPN()
    {
        var expected = 7;
        var actual = Expression.EvaluateRPN("3 2 * 1 +");

        Assert.Equal(expected, actual);
    }
}
