// Ignore Spelling: Fnv

using ProjectEuler.Toolbox;
using Xunit;

namespace ProjectEuler.ToolboxTests;

public class HashingTests
{
    [Fact]
    public void ModifiedFnv32()
    {
        var expected = 2730030712;
        var actual = Hashing.ModifiedFnv32([1, 2, 3]);

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void EvaluateRPN()
    {
        var expected = 8270004038646870267ul;
        var actual = Hashing.ModifiedFnv64([1, 2, 3]);

        Assert.Equal(expected, actual);
    }
}
