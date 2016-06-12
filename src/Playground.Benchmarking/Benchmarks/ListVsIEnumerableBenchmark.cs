namespace Playground.Benchmarking.Benchmarks
{
    using System.Collections.Generic;

    using BenchmarkDotNet.Attributes;

    using Playground.Benchmarking.Configs;

    [Config(typeof(DefaultConfig))]
    public class ListVsIEnumerableBenchmark
    {
        private List<string> emptyList;
        private List<string> list;
        private IEnumerable<string> emptyEnumerable;
        private IEnumerable<string> enumerable;

        [Setup]
        public void Setup()
        {
            this.emptyList = new List<string>();
            this.list = new List<string> { "text1", "text2", "text3", "text4", "text5", "text6" };
            this.emptyEnumerable = new List<string>();
            this.enumerable = this.list;
        }

        [Benchmark(Baseline = true)]
        public void EmptyListEnumeration()
        {
            foreach (var item in this.emptyList)
            {
            }
        }

        [Benchmark]
        public void EmptyIEnumerableEnumeration()
        {
            foreach (var item in this.emptyEnumerable)
            {
            }
        }

        [Benchmark]
        public void ListEnumeration()
        {
            foreach (var item in this.list)
            {
            }
        }

        [Benchmark]
        public void IEnumerableEnumeration()
        {
            foreach (var item in this.enumerable)
            {
            }
        }
    }
}