using ProjectEuler.Toolbox;

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

using Xunit;

namespace ProjectEuler.ToolboxTests;

public class LinqExtensionsTests
{
    [Fact]
    public void BinarySearchForMatchFound()
    {
        var expected = 2;
        var list = new[] { 1, 3, 5, 7 };
        var actual = list.BinarySearchForMatch(x => x.CompareTo(5));

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void BinarySearchForMatchNotFoundReturnsInsertionPoint()
    {
        var list = new[] { 1, 3, 5, 7 };
        var actual = list.BinarySearchForMatch(x => x.CompareTo(4));

        Assert.Equal(~2, actual);
    }

    [Fact]
    public void BinarySearchForMatchLessThanAll()
    {
        var list = new[] { 1, 3, 5, 7 };
        var actual = list.BinarySearchForMatch(x => x.CompareTo(0));

        Assert.Equal(~0, actual);
    }

    [Fact]
    public void BinarySearchForMatchGreaterThanAll()
    {
        var list = new[] { 1, 3, 5, 7 };
        var actual = list.BinarySearchForMatch(x => x.CompareTo(9));

        Assert.Equal(~4, actual);
    }

    [Fact]
    public void BinarySearchForMatchFirstElement()
    {
        var list = new[] { 1, 3, 5, 7 };
        var actual = list.BinarySearchForMatch(x => x.CompareTo(1));

        Assert.Equal(0, actual);
    }

    [Fact]
    public void BinarySearchForMatchEmptyList()
    {
        var list = Array.Empty<int>();
        var actual = list.BinarySearchForMatch(x => x.CompareTo(1));

        Assert.Equal(~0, actual);
    }

    [Fact]
    public void ReverseRangePartial()
    {
        var expected = new[] { 1, 4, 3, 2, 5 };
        var list = new[] { 1, 2, 3, 4, 5 };
        var actual = list.ReverseRange(1, 4);

        Assert.Equal(expected, actual);
        Assert.Same(list, actual);
    }

    [Fact]
    public void ReverseRangeFull()
    {
        var expected = new[] { 5, 4, 3, 2, 1 };
        var list = new[] { 1, 2, 3, 4, 5 };
        var actual = list.ReverseRange(0, list.Length);

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void ReverseRangeSingleElement()
    {
        var list = new[] { 1, 2, 3, 4, 5 };
        var actual = list.ReverseRange(2, 3);

        Assert.Equal(list, actual);
    }

    [Fact]
    public void ReverseRangeEmptyRange()
    {
        var list = new[] { 1, 2, 3, 4, 5 };
        var actual = list.ReverseRange(2, 2);

        Assert.Equal(list, actual);
    }

    [Fact]
    public void SumBigInteger()
    {
        var expected = new BigInteger(6);
        var actual = new[] { new BigInteger(1), new BigInteger(2), new BigInteger(3) }.Sum();

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void SumBigIntegerEmpty()
    {
        var actual = Array.Empty<BigInteger>().Sum();

        Assert.Equal(BigInteger.Zero, actual);
    }

    [Fact]
    public void SumBigRational()
    {
        var expected = new BigRational(2, 3);
        var actual = new[] { new BigRational(1, 3), new BigRational(1, 3) }.Sum();

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void SumGeneric()
    {
        var expected = 6.0;
        var actual = new[] { 1.0, 2.0, 3.0 }.Sum<double>();

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void MergeEqualLength()
    {
        var expected = new[] { 2, 6, 12 };
        var first = new[] { 1, 2, 3 };
        var second = new[] { 2, 3, 4 };
        var actual = first.Merge(second, (a, b) => a * b, () => 0, () => 0).ToList();

        Assert.True(expected.SequenceEqual(actual));
    }

    [Fact]
    public void MergeFirstLonger()
    {
        var expected = new[] { 2, 6, 9, 12 };
        var first = new[] { 1, 2, 3, 4 };
        var second = new[] { 2, 3 };
        var default2Calls = 0;
        var actual = first
            .Merge(second, (a, b) => a * b, () => 1, () => { default2Calls++; return 3; })
            .ToList();

        Assert.True(expected.SequenceEqual(actual));
        Assert.Equal(2, default2Calls);
    }

    [Fact]
    public void MergeSecondLonger()
    {
        var expected = new[] { 2, 6, 15, 24 };
        var first = new[] { 1, 2 };
        var second = new[] { 2, 3, 5, 8 };
        var default1Calls = 0;
        var actual = first
            .Merge(second, (a, b) => a * b, () => { default1Calls++; return 3; }, () => 0)
            .ToList();

        Assert.True(expected.SequenceEqual(actual));
        Assert.Equal(2, default1Calls);
    }

    [Fact]
    public void MergeEmptyFirst()
    {
        var expected = new[] { 4, 6 };
        var second = new[] { 2, 3 };
        var actual = Array.Empty<int>().Merge(second, (a, b) => a * b, () => 2, () => 0).ToList();

        Assert.True(expected.SequenceEqual(actual));
    }

    [Fact]
    public void MergeEmptySecond()
    {
        var expected = new[] { 2, 2 };
        var first = new[] { 1, 1 };
        var actual = first.Merge(Array.Empty<int>(), (a, b) => a * b, () => 0, () => 2).ToList();

        Assert.True(expected.SequenceEqual(actual));
    }

    [Fact]
    public void MergeBothEmpty()
    {
        var actual = Array.Empty<int>().Merge(Array.Empty<int>(), (a, b) => a * b, () => 0, () => 0);

        Assert.Empty(actual);
    }

    [Fact]
    public void MergeNullArguments()
    {
        int[] first = null!;

        Assert.Throws<ArgumentNullException>(() => first.Merge(new[] { 1 }, (a, b) => a + b, () => 0, () => 0).ToList());
        Assert.Throws<ArgumentNullException>(() => new[] { 1 }.Merge(null!, (a, b) => a + b, () => 0, () => 0).ToList());
        Assert.Throws<ArgumentNullException>(() => new[] { 1 }.Merge<int, int, int>(new[] { 1 }, null!, () => 0, () => 0).ToList());
    }

    [Fact]
    public void MergeRepeatLastEqualLength()
    {
        var expected = new[] { 2, 6, 12 };
        var first = new[] { 1, 2, 3 };
        var second = new[] { 2, 3, 4 };
        var actual = first.MergeRepeatLast(second, (a, b) => a * b).ToList();

        Assert.True(expected.SequenceEqual(actual));
    }

    [Fact]
    public void MergeRepeatLastFirstLonger()
    {
        var expected = new[] { 2, 6, 12, 16 };
        var first = new[] { 1, 2, 3, 4 };
        var second = new[] { 2, 3, 4 };
        var actual = first.MergeRepeatLast(second, (a, b) => a * b).ToList();

        Assert.True(expected.SequenceEqual(actual));
    }

    [Fact]
    public void MergeRepeatLastSecondLonger()
    {
        var expected = new[] { 2, 6, 10, 16 };
        var first = new[] { 1, 2 };
        var second = new[] { 2, 3, 5, 8 };
        var actual = first.MergeRepeatLast(second, (a, b) => a * b).ToList();

        Assert.True(expected.SequenceEqual(actual));
    }

    [Fact]
    public void MergeRepeatLastEmptyFirstRepeatsDefault()
    {
        var expected = new[] { "(,2)", "(,5)" };
        var actual = Array.Empty<string>()
            .MergeRepeatLast(new[] { "2", "5" }, (a, b) => $"({a},{b})")
            .ToList();

        Assert.True(expected.SequenceEqual(actual));
    }

    [Fact]
    public void MergeRepeatLastEmptySecondRepeatsDefault()
    {
        var expected = new[] { "(1,)", "(2,)" };
        var actual = new[] { "1", "2" }
            .MergeRepeatLast(Array.Empty<string>(), (a, b) => $"({a},{b})")
            .ToList();

        Assert.True(expected.SequenceEqual(actual));
    }

    [Fact]
    public void MergeRepeatLastBothEmpty()
    {
        var actual = Array.Empty<int>().MergeRepeatLast(Array.Empty<int>(), (a, b) => a + b);

        Assert.Empty(actual);
    }

    [Fact]
    public void MergeRepeatLastNullArguments()
    {
        int[] source = null!;

        Assert.Throws<ArgumentNullException>(() => source.MergeRepeatLast(new[] { 1 }, (a, b) => a + b).ToList());
        Assert.Throws<ArgumentNullException>(() => new[] { 1 }.MergeRepeatLast<int, int, int>(null!, (a, b) => a + b).ToList());
        Assert.Throws<ArgumentNullException>(() => new[] { 1 }.MergeRepeatLast<int, int, int>(new[] { 1 }, null!).ToList());
    }

    [Fact]
    public void SecondLast()
    {
        var expected = 4;
        var actual = new[] { 1, 2, 3, 4, 5 }.SecondLast();

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void SecondLastExactlyTwo()
    {
        var expected = 1;
        var actual = new[] { 1, 2 }.SecondLast();

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void SecondLastSingleElementThrows()
    {
        Assert.Throws<InvalidOperationException>(() => new[] { 1 }.SecondLast());
    }

    [Fact]
    public void SecondLastEmptyThrows()
    {
        Assert.Throws<InvalidOperationException>(() => Array.Empty<int>().SecondLast());
    }

    [Fact]
    public void SecondLastNullElement()
    {
        var actual = new string?[] { null, "a" }.SecondLast();

        Assert.Null(actual);
    }

    [Fact]
    public void SecondLastValueTypeDefaultElement()
    {
        var expected = 10;
        var actual = new[] { 10, 0 }.SecondLast();

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void TrySelectAllSuccessful()
    {
        var expected = new[] { 10, 20, 30 };
        var actual = new[] { 1, 2, 3 }.TrySelect(i => i * 10).ToList();

        Assert.True(expected.SequenceEqual(actual));
    }

    [Fact]
    public void TrySelectSkipsFailures()
    {
        var expected = new[] { 10, 30 };
        var actual = new[] { 1, 2, 3 }
            .TrySelect<int, int>(i => i == 2 ? throw new InvalidOperationException("boom") : i * 10)
            .ToList();

        Assert.True(expected.SequenceEqual(actual));
    }

    [Fact]
    public void TrySelectContinuesAfterFailure()
    {
        var processed = new List<int>();
        var actual = new[] { 1, 2, 3 }
            .TrySelect(i =>
            {
                processed.Add(i);

                return i == 1 ? throw new Exception("boom") : i;
            })
            .ToList();

        Assert.Equal(new[] { 1, 2, 3 }, processed);
        Assert.Equal(new[] { 2, 3 }, actual);
    }

    [Fact]
    public void TrySelectErrorHandlerCalled()
    {
        var errors = new List<(int Item, Exception Exception)>();
        var actual = new[] { 1, 2, 3 }
            .TrySelect(
                i => i == 2 ? throw new InvalidOperationException("boom") : i * 10,
                (item, ex) => errors.Add((item, ex)))
            .ToList();

        Assert.Equal(new[] { 10, 30 }, actual);

        var error = Assert.Single(errors);
        Assert.Equal(2, error.Item);
        Assert.IsType<InvalidOperationException>(error.Exception);
    }

    [Fact]
    public void TrySelectEmpty()
    {
        var actual = Array.Empty<int>().TrySelect(i => i);

        Assert.Empty(actual);
    }

    [Fact]
    public void TrySelectNullArguments()
    {
        int[] source = null!;

        Assert.Throws<ArgumentNullException>(() => source.TrySelect(i => i).ToList());
        Assert.Throws<ArgumentNullException>(() => new[] { 1 }.TrySelect<int, int>(null!).ToList());
    }

    [Fact]
    public void ForAll()
    {
        var sum = 0;
        new[] { 1, 2, 3 }.ForAll(i => sum += i);

        Assert.Equal(6, sum);
    }

    [Fact]
    public void ForAllEmpty()
    {
        var count = 0;
        Array.Empty<int>().ForAll(i => count++);

        Assert.Equal(0, count);
    }

    [Fact]
    public void ForAllNullArguments()
    {
        int[] source = null!;

        Assert.Throws<ArgumentNullException>(() => source.ForAll(i => { }));
        Assert.Throws<ArgumentNullException>(() => new[] { 1 }.ForAll(null!));
    }

    [Fact]
    public void EnumerableToString()
    {
        var expected = "[1, 2, 3]";
        var actual = new[] { 1, 2, 3 }.EnumerableToString();

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void EnumerableToStringEmpty()
    {
        var expected = "[]";
        var actual = Array.Empty<int>().EnumerableToString();

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void RandomSampleEmptySource()
    {
        var actual = Array.Empty<int>().RandomSample(3, new Random(1)).ToList();

        Assert.Empty(actual);
    }

    [Fact]
    public void RandomSampleZeroSamples()
    {
        var actual = new[] { 1, 2, 3 }.RandomSample(0, new Random(1)).ToList();

        Assert.Empty(actual);
    }

    [Fact]
    public void RandomSampleMoreSamplesThanSource()
    {
        var expected = new[] { 4, 8, 15, 16 };
        var actual = new[] { 4, 8, 15, 16 }.RandomSample(10, new Random(1)).ToList();

        Assert.True(expected.SequenceEqual(actual));
    }

    [Fact]
    public void RandomSampleDeterministic()
    {
        var source = Enumerable.Range(0, 100).ToList();
        var a = source.RandomSample(10, new Random(42)).ToList();
        var b = source.RandomSample(10, new Random(42)).ToList();

        Assert.True(a.SequenceEqual(b));
    }

    [Fact]
    public void RandomSampleIsUniformSubset()
    {
        var source = Enumerable.Range(0, 100).ToArray();
        var actual = source.RandomSample(10, new Random(12345)).ToList();

        Assert.Equal(10, actual.Count);
        Assert.Equal(10, actual.Distinct().Count());
        Assert.True(actual.All(source.Contains));
        Assert.True(actual.SequenceEqual(actual.OrderBy(x => x)));
    }

    [Fact]
    public void RandomSampleSinglePass()
    {
        var source = new SingleEnumerationEnumerable<int>(Enumerable.Range(0, 100));
        var actual = source.RandomSample(10, new Random(7)).ToList();

        Assert.Equal(10, actual.Count);
        Assert.Equal(1, source.Enumerations);
    }

    [Fact]
    public void RandomSampleZeroSamplesDoesNotEnumerate()
    {
        var source = new SingleEnumerationEnumerable<int>(Enumerable.Range(0, 100));
        var actual = source.RandomSample(0, new Random(7)).ToList();

        Assert.Empty(actual);
        Assert.Equal(0, source.Enumerations);
    }

    [Fact]
    public void RandomSampleNegativeThrows()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => new[] { 1, 2, 3 }.RandomSample(-1, new Random(1)).ToList());
    }

    [Fact]
    public void RandomSampleNullSourceThrows()
    {
        int[] source = null!;

        Assert.Throws<ArgumentNullException>(() => source.RandomSample(1, new Random(1)).ToList());
    }

    private sealed class SingleEnumerationEnumerable<T> : IEnumerable<T>
    {
        private readonly IEnumerable<T> _source;
        private int _enumerations;

        public SingleEnumerationEnumerable(IEnumerable<T> source) => _source = source;

        public int Enumerations => _enumerations;

        public IEnumerator<T> GetEnumerator()
        {
            if (_enumerations++ > 0)
            {
                throw new InvalidOperationException("Source was enumerated more than once");
            }

            return _source.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}