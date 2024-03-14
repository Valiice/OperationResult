using BenchmarkDotNet.Running;

namespace OperationResult.Benchmarks;

static class Program
{
    static void Main()
    {
        BenchmarkRunner.Run<Benchmark>();
        Console.ReadLine();
    }
}