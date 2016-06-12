namespace Playground.Benchmarking.Benchmarks
{
    using System.Runtime.CompilerServices;

    using BenchmarkDotNet.Attributes;

    using Playground.Benchmarking.Configs;

    [Config(typeof(DefaultConfig))]
    public class SimpleExtensionMethods
    {
        [Params(10000)]
        public int Loops;

        private readonly string value = string.Empty;

        [Benchmark(Baseline = true)]
        public bool BasicNullComparison()
        {
            return this.value == null;
        }

        [Benchmark]
        public bool BasicNullComparisonOpositeOrder()
        {
            return null == this.value;
        }

        [Benchmark]
        public bool IsNull()
        {
            return this.value.IsNull();
        }

        [Benchmark]
        public bool IsNullOppositeOrder()
        {
            return this.value.IsNullOppositeOrder();
        }

        [Benchmark]
        public bool IsNullWithNoInlining()
        {
            return this.value.IsNullWithNoInlining();
        }

        [Benchmark]
        public bool IsNullOppositeOrderWithNoInlining()
        {
            return this.value.IsNullOppositeOrderWithNoInlining();
        }

        [Benchmark]
        public bool IsNullWithAggressiveInlining()
        {
            return this.value.IsNullWithAggressiveInlining();
        }

        [Benchmark]
        public bool IsNullOppositeOrderWithAggressiveInlining()
        {
            return this.value.IsNullOppositeOrderWithAggressiveInlining();
        }
    }

    public static class Extensions
    {
        public static bool IsNull(this object value)
        {
            return value == null;
        }

        public static bool IsNullOppositeOrder(this object value)
        {
            return null == value;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static bool IsNullWithNoInlining(this object value)
        {
            return value == null;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static bool IsNullOppositeOrderWithNoInlining(this object value)
        {
            return null == value;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsNullWithAggressiveInlining(this object value)
        {
            return value == null;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsNullOppositeOrderWithAggressiveInlining(this object value)
        {
            return value == null;
        }
    }
}