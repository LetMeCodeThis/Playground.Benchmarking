namespace Playground.Benchmarking.Benchmarks
{
    using BenchmarkDotNet.Attributes;

    using Playground.Benchmarking.Configs;

    [Config(typeof(DefaultConfig))]
    public class ReadOnlyFiledVsNormalFieldBenchmark
    {
        private readonly int readOnlyField = 1;

        private int normalField = 1;

        [Benchmark(Baseline = true)]
        public int NormalFieldAccess()
        {
            return this.normalField;
        }

        [Benchmark]
        public int ReadOnlyFieldAccess()
        {
            return this.readOnlyField;
        }
    }
}