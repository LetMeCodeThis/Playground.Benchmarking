namespace Playground.Benchmarking.Benchmarks
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using BenchmarkDotNet.Attributes;

    using Playground.Benchmarking.Configs;

    [Config(typeof(DefaultConfig))]
    public class HashSetVsUnsafeArrayLookupBenchmark
    {
        private HashSet<int> hashSet;

        private int[] array;

        private int valueToLookFor;

        [Params(10, 100, 200, 1000, 10000, 100000)]
        public int Parameter { get; set; }

        [Setup]
        public void SetUp()
        {
            var values = Enumerable.Range(0, this.Parameter).ToArray();

            this.hashSet = new HashSet<int>(values);
            this.array = values;
            this.valueToLookFor = new Random().Next(0, 500);
        }

        [Benchmark(Baseline = true)]
        public bool Array()
        {
            var hasValue = false;

            for (var i = 0; i < this.array.Length; i++)
            {
                if (this.array[i] == this.valueToLookFor)
                {
                    hasValue = true;
                    break;
                }
            }

            return hasValue;
        }

        [Benchmark]
        public unsafe bool ArrayUnsafe()
        {
            var hasValue = false;

            fixed (int* p = this.array)
            {
                for (var i = 0; i < this.array.Length; i++)
                {
                    if (p[i] == this.valueToLookFor)
                    {
                        hasValue = true;
                        break;
                    }
                }
            }

            return hasValue;
        }

        [Benchmark]
        public bool HashSet() => this.hashSet.Contains(this.valueToLookFor);
    }
}