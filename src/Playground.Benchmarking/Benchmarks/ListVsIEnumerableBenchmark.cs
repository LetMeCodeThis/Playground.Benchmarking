namespace Playground.Benchmarking.Benchmarks
{
    using System.Collections.Generic;

    using BenchmarkDotNet.Attributes;

    using Playground.Benchmarking.Configs;

    [Config(typeof(DefaultConfig))]
    public class ListVsIEnumerableBenchmark
    {
        private List<string> list;
        private IList<string> ilist;
        private IEnumerable<string> enumerable;

        [Params(0, 10, 100, 1000, 10000)]
        public int CollectionSize;

        [Setup]
        public void Setup()
        {
            this.list = this.GetList(this.CollectionSize);
            this.ilist = this.list;
            this.enumerable = this.list;
        }

        [Benchmark(Baseline = true)]
        public void ListEnumeration()
        {
            foreach (var item in this.list)
            {
            }
        }

        [Benchmark]
        public void IListEnumeration()
        {
            foreach (var item in this.ilist)
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

        private List<string> GetList(int collectionSize)
        {
            var list = new List<string>(collectionSize);

            for (var i = 0; i < collectionSize; i++)
            {
                list.Add("value");
            }

            return list;
        }
    }
}