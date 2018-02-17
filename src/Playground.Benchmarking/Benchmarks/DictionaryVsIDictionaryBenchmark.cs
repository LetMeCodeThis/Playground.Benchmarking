namespace Playground.Benchmarking.Benchmarks
{
    using System.Collections.Generic;

    using BenchmarkDotNet.Attributes;
    using BenchmarkDotNet.Configs;
    using BenchmarkDotNet.Diagnosers;

    [Config(typeof(BenchmarkConfig))]
    public class DictionaryVsIDictionaryBenchmark
    {
        private Dictionary<string, string> dict;
        private IDictionary<string, string> idict;

        [Setup]
        public void Setup()
        {
            this.dict = new Dictionary<string, string>();
            this.idict = new Dictionary<string, string>();
        }

        [Benchmark(Baseline = true)]
        public void DictionaryEnumeration()
        {
            foreach (var item in this.dict)
            {
            }
        }

        [Benchmark]
        public void IDictionaryEnumeration()
        {
            foreach (var item in this.idict)
            {
            }
        }

        private class BenchmarkConfig : ManualConfig
        {
            public BenchmarkConfig()
            {
                this.Add(new MemoryDiagnoser());
            }
        }
    }
}