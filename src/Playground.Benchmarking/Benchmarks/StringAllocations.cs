namespace Playground.Benchmarking.Benchmarks
{
    using BenchmarkDotNet.Attributes;

    using Playground.Benchmarking.Configs;

    [Config(typeof(DefaultConfig))]
    public class StringAllocations
    {
        private const string StringToCompare = "AGSDSFSDF";

        private const string ConstStringInClass = "Some dummy text1";

        [Params(1, 100, 10000)]
        public int Loops;

        [Benchmark(Baseline = true)]
        public bool WithInlinedString()
        {
            return this.StringStartsWith("Some dummy text1");
        }

        [Benchmark]
        public bool WithClassConstString()
        {
            return this.StringStartsWith(ConstStringInClass);
        }

        [Benchmark]
        public bool WithMethodConstString()
        {
            const string ConstStringInMethod = "Some dummy text2";

            return this.StringStartsWith(ConstStringInMethod);
        }

        [Benchmark]
        public bool WithInlinedStringAndWithInlinedStringToCompare()
        {
            return this.StringStartsWithButWithInlinedStringToCompare("Some dummy text1");
        }

        private bool StringStartsWith(string value)
        {
            return StringToCompare.StartsWith(value);
        }

        private bool StringStartsWithButWithInlinedStringToCompare(string value)
        {
            return "AGSDSFASD".StartsWith(value);
        }
    }
}