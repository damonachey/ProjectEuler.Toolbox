using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Jobs;

using ProjectEuler.Toolbox;

using System.Numerics;
using System.Text;

namespace ToolboxBenchmarks;

/// <summary>
/// Simple side-by-side comparison of ToDecimalString performance
/// </summary>
[SimpleJob]
[MemoryDiagnoser]
[RankColumn]
public class BigRationalBenchmarks
{
    // Small set of test cases for clear comparison
    private readonly BigRational[] _testCases =
    [
        new (1, 3),        // 0.333...
        new (22, 7),       // π approximation
        new (355, 113),    // Better π approximation
        new (1, 7),        // 0.142857...
        new (2, 1)         // Simple integer
    ];

    [Params(10, 50)]
    public int Precision { get; set; }

    // Original ToDecimalString method
    [Benchmark(Baseline = true, Description = "Original ToDecimalString")]
    public string[] OriginalToDecimalString()
    {
        var results = new string[_testCases.Length];
        for (int i = 0; i < _testCases.Length; i++)
        {
            results[i] = _testCases[i].ToDecimalString(Precision);
        }
        return results;
    }
}
