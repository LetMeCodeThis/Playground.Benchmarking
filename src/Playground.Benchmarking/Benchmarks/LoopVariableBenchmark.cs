namespace Playground.Benchmarking.Benchmarks
{
    using System.Linq;

    using BenchmarkDotNet.Attributes;

    using Playground.Benchmarking.Configs;

    [Config(typeof(DefaultConfig))]
    public class LoopVariableBenchmark
    {
        private readonly int[] values = Enumerable.Range(0, 1000 * 1000).ToArray();

        [Benchmark(Baseline = true)]
        public long Left()
        {
            var sum = 0L;
            var vals = this.values;

            for (var i = 0; i < vals.Length; i++)
            {
                vals[i] = vals[i] - 1;
            }

            return sum;
        }

        [Benchmark]
        public long Right()
        {
            var sum = 0L;

            for (var i = 0; i < this.values.Length; i++)
            {
                this.values[i] = this.values[i] - 1;
            }

            return sum;
        }
    }
}