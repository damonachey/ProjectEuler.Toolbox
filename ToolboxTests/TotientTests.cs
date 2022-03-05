using ProjectEuler.Toolbox;
using System;
using Xunit;

namespace ProjectEuler.ToolboxTests;

public class TotientTests
{
    [Fact]
    public void PhiMaxSet()
    {
        var expected = 3852;
        var totient = new Totient(4800);
        var actual = totient.Phi(4501);

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void PhiOne()
    {
        var expected = 1;
        var totient = new Totient(1);
        var actual = totient.Phi(1);

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void Phi()
    {
        var expected = 8;
        var totient = new Totient(100);
        var actual = totient.Phi(20);

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void PhiGreaterThanN()
    {
        var totient = new Totient(10);
        Assert.Throws<ArgumentOutOfRangeException>(() => totient.Phi(20));
    }

    [Fact]
    public void Phi2()
    {
        var expected = 10083087720778;
        var actual = Totient.Phi2(10083087720779);

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void PhiPhi2()
    {
        var totient = new Totient(100);
        var expected = totient.Phi(20);
        var actual = Totient.Phi2(20);

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void MaxnOverPhin()
    {
        var expected = 30;
        var actual = Totient.MaxnOverPhin(100);

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void MinnOverPhin()
    {
        var expected = 49;
        var actual = Totient.MinnOverPhin(100);

        Assert.Equal(expected, actual);
    }
}
