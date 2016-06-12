namespace Playground.Benchmarking.Benchmarks
{
    using System.Runtime.CompilerServices;

    using BenchmarkDotNet.Attributes;

    using Playground.Benchmarking.Configs;

    [Config(typeof(DefaultConfig))]
    public class MethodInvocationOverheadBenchmark
    {
        private readonly int value = 1;

        [Benchmark(Baseline = true)]
        public int MethodCallDepthOf1()
        {
            return this.Method();
        }

        [Benchmark]
        public int MethodCallDepthOf2()
        {
            return this.NestingDepthOf2();
        }

        [Benchmark]
        public int MethodCallDepthOf3()
        {
            return this.NestingDepthOf3();
        }

        [Benchmark]
        public int MethodCallDepthOf5()
        {
            return this.NestingDepthOf5();
        }

        [Benchmark]
        public int MethodCallDepthOf10()
        {
            return this.NestingDepthOf10();
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public int Method() => this.value;

        [MethodImpl(MethodImplOptions.NoInlining)]
        public int NestingDepthOf2() => this.Method();

        [MethodImpl(MethodImplOptions.NoInlining)]
        public int NestingDepthOf3() => this.NestingDepthOf2();

        [MethodImpl(MethodImplOptions.NoInlining)]
        public int NestingDepthOf4() => this.NestingDepthOf3();

        [MethodImpl(MethodImplOptions.NoInlining)]
        public int NestingDepthOf5() => this.NestingDepthOf4();

        [MethodImpl(MethodImplOptions.NoInlining)]
        public int NestingDepthOf6() => this.NestingDepthOf5();

        [MethodImpl(MethodImplOptions.NoInlining)]
        public int NestingDepthOf7() => this.NestingDepthOf6();

        [MethodImpl(MethodImplOptions.NoInlining)]
        public int NestingDepthOf8() => this.NestingDepthOf7();

        [MethodImpl(MethodImplOptions.NoInlining)]
        public int NestingDepthOf9() => this.NestingDepthOf8();

        [MethodImpl(MethodImplOptions.NoInlining)]
        public int NestingDepthOf10() => this.NestingDepthOf9();
    }
}