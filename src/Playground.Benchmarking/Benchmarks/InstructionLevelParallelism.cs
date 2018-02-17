namespace Playground.Benchmarking.Benchmarks
{
    using System;
    using System.Linq;

    using BenchmarkDotNet.Attributes;
    using BenchmarkDotNet.Diagnosers;

    using Playground.Benchmarking.Configs;

    [Config(typeof(DefaultConfig))]
    [HardwareCounters(HardwareCounter.CacheMisses)]
    public class InstructionLevelParallelism
    {
        private const int Count = 200;

        private static readonly int[] X = Enumerable.Range(0, Count).ToArray();

        private static readonly int[] Result = Enumerable.Range(0, Count).ToArray();

        [Benchmark(Baseline = true)]
        public void Left()
        {
            Array.Clear(Result, 0, Count);

            for (var index = 1; index < Count; index++)
            {
                Result[index] = X[index] + Result[index - 1];
            }
        }

        [Benchmark]
        public void Right()
        {
            Array.Clear(Result, 0, Count);

            for (var index = 1; index < Count; index++)
            {
                Result[index] = X[index] + X[index - 1];
            }
        }
    }
}