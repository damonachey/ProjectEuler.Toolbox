using BenchmarkDotNet.Running;

namespace ToolboxBenchmarks;

public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Running BigRational ToDecimalString benchmarks...");
        Console.WriteLine();

        // Run the benchmark
        BenchmarkRunner.Run<BigRationalBenchmarks>();
    }
}
