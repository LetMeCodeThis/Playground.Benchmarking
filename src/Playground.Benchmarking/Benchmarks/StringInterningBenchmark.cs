namespace Playground.Benchmarking.Benchmarks
{
    using BenchmarkDotNet.Attributes;

    using Playground.Benchmarking.Configs;

    [Config(typeof(DefaultConfig))]
    public class StringInterningBenchmark
    {
        private const string value = "sample";

        [Benchmark(Baseline = true)]
        public string NormalStringAllocation()
        {
            return value + "string";
        }

        [Benchmark]
        public string InternedStringAllocation()
        {
            return string.Intern(value + "string");
        }

        [Benchmark]
        public void NormalMultipleStringAllocation()
        {
            var str1 = value + "string";
            var str2 = value + "string";
            var str3 = value + "string";
            var str4 = value + "string";
            var str5 = value + "string";
            var str6 = value + "string";
            var str7 = value + "string";
            var str8 = value + "string";
            var str9 = value + "string";
            var str10 = value + "string";
        }

        [Benchmark]
        public void InternedMultipleStringAllocation()
        {
            var str1 = string.Intern(value + "string");
            var str2 = string.Intern(value + "string");
            var str3 = string.Intern(value + "string");
            var str4 = string.Intern(value + "string");
            var str5 = string.Intern(value + "string");
            var str6 = string.Intern(value + "string");
            var str7 = string.Intern(value + "string");
            var str8 = string.Intern(value + "string");
            var str9 = string.Intern(value + "string");
            var str10 = string.Intern(value + "string");
        }
    }
}