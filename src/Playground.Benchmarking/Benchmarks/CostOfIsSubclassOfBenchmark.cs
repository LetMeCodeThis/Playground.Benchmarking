namespace Playground.Benchmarking.Benchmarks
{
    using BenchmarkDotNet.Attributes;

    using Playground.Benchmarking.Configs;

    [Config(typeof(DefaultConfig))]
    public class CostOfIsSubclassOfBenchmark
    {
        private bool isSubclass;

        [Setup]
        public void Setup()
        {
            this.isSubclass = typeof(DerivedClass).IsSubclassOf(typeof(BaseClass));
        }

        [Benchmark(Baseline = true)]
        public bool IsSubClassOf()
        {
            return typeof(DerivedClass).IsSubclassOf(typeof(BaseClass));
        }

        [Benchmark]
        public bool PreCachedResult()
        {
            return this.isSubclass;
        }

        private class BaseClass
        {
        }

        private class DerivedClass : BaseClass
        {
        }
    }
}