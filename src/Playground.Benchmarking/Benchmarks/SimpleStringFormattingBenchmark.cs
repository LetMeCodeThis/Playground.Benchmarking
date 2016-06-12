namespace Playground.Benchmarking.Benchmarks
{
    using System.Text.Formatting;

    using BenchmarkDotNet.Attributes;

    using Playground.Benchmarking.Configs;

    [Config(typeof(DefaultConfig))]
    public class SimpleStringFormattingBenchmark
    {
        private int value = 1;

        [Benchmark(Baseline = true)]
        public string StringFormatWithBoxing()
        {
            return string.Format("{0} place", this.value);
        }

        [Benchmark]
        public string StringFormatWithoutBoxing()
        {
            return string.Format("{0} place", this.value.ToString());
        }

        [Benchmark]
        public string InterpolatedStringWithBoxing()
        {
            return $"{this.value} place";
        }

        [Benchmark]
        public string InterpolatedStringWithoutBoxing()
        {
            return $"{this.value.ToString()} place";
        }

        [Benchmark]
        public string StringConcatenationWithBoxing()
        {
            return this.value + " place";
        }


        [Benchmark]
        public string StringConcatenationWithoutBoxing()
        {
            return this.value.ToString() + " place";
        }

        [Benchmark]
        public string StringFormatterWithBoxing()
        {
            return StringBuffer.Format("{0} place", this.value.ToString());
        }

        [Benchmark]
        public string StringFormatterWithoutBoxing()
        {
            return StringBuffer.Format("{0} place", this.value.ToString());
        }
    }
}