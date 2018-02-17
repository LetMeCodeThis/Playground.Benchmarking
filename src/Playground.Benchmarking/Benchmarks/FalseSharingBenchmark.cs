namespace Playground.Benchmarking.Benchmarks
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    using BenchmarkDotNet.Attributes;

    using Playground.Benchmarking.Configs;

    [Config(typeof(DefaultConfig))]
    public class FalseSharingBenchmark
    {
        private const int PartitionCount = 8;

        private static readonly Random Random = new Random();

        private static readonly int[] Values = Enumerable.Range(0, 500).Select(_ => Random.Next(5000)).ToArray();

        [Benchmark(Baseline = true)]
        public int ListWithLock()
        {
            var results = new List<int>();

            Parallel.For(
                0,
                PartitionCount,
                i =>
                    {
                        var localResult = 0;

                        for (var index = i; index < Values.Length; index += PartitionCount)
                        {
                            localResult += Values[index];
                        }

                        lock (results)
                        {
                            results.Add(localResult);
                        }
                    });

            return results.Sum();
        }

        [Benchmark]
        public int ListWithArray()
        {
            var results = new int[PartitionCount];

            Parallel.For(
                0,
                PartitionCount,
                i =>
                {
                    for (var index = i; index < Values.Length; index += PartitionCount)
                    {
                        results[i] += Values[index];
                    }
                });

            return results.Sum();
        }

        [Benchmark]
        public int ListWithInterlockedAdd()
        {
            var result = 0;

            Parallel.For(
                0,
                PartitionCount,
                i =>
                {
                    var localResult = 0;

                    for (var index = i; index < Values.Length; index += PartitionCount)
                    {
                        localResult += Values[index];
                    }

                    Interlocked.Add(ref result, localResult);
                });

            return result;
        }
    }
}