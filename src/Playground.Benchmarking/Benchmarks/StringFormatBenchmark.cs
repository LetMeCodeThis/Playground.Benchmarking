namespace Playground.Benchmarking.Benchmarks
{
    using BenchmarkDotNet.Attributes;

    using Playground.Benchmarking.Configs;

    [Config(typeof(DefaultConfig))]
    public class StringFormatBenchmark
    {
        [Benchmark(Baseline = true)]
        public void StringFormatOnObjectParameters()
        {
            this.StringFormatWithBoxing(1, 100);
        }

        [Benchmark]
        public void StringFormatOnStringParameters()
        {
            this.StringFormatWithoutBoxing(1, 100);
        }

        private string StringFormatWithBoxing(int id, int value)
        {
            return string.Format("{0} - {1}", id, value);
        }

        private string StringFormatWithoutBoxing(int id, int value)
        {
            return string.Format("{0} - {1}", id.ToString(), value.ToString());
        }
    }
}