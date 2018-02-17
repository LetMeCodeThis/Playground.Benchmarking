namespace Playground.Benchmarking.Benchmarks
{
    using BenchmarkDotNet.Attributes;

    using Playground.Benchmarking.Configs;

    [Config(typeof(DefaultConfig))]
    public class ParamsAsNullBenchmark
    {
        private const string Template = "Template";

        [Benchmark(Baseline = true)]
        public string NoParameterProvided()
        {
            return Format(Template);
        }

        [Benchmark]
        public string WithParamsParameterAsNull()
        {
            return Format(Template, null);
        }

        [Benchmark]
        public string WithParamsParameterAsStringEmpty()
        {
            return Format(Template, string.Empty);
        }

        private static string Format(string format, params object[] parameters)
        {
            return string.Format(format, parameters);
        }
    }
}