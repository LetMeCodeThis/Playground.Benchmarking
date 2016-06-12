namespace Playground.Benchmarking.Benchmarks
{
    using BenchmarkDotNet.Attributes;

    using Playground.Benchmarking.Configs;

    [Config(typeof(DefaultConfig))]
    public class StringSplitBenchmark
    {
        private const string Value = "123,123,123,123,123";

        private static readonly char[] Comma = {','};

        [Params(1, 100, 1000)]
        public int Loops;

        [Benchmark(Baseline = true)]
        public string[] Split()
        {
            var val = new string[0];

            for (var i = 0; i < this.Loops; i++)
            {
                val = Value.Split(',');
            }

            return val;
        }

        [Benchmark]
        public string[] SplitWithStatic()
        {
            var val = new string[0];

            for (var i = 0; i < this.Loops; i++)
            {
                val = Value.Split(Comma);
            }

            return val;
        }
    }
}