namespace Playground.Benchmarking.Benchmarks
{
    using System.Collections.Generic;

    using BenchmarkDotNet.Attributes;

    using Playground.Benchmarking.Configs;

    [Config(typeof(DefaultConfig))]
    public class RedundantTypeSpecificationBenchmark
    {
        ////[Params(1, 5, 20, 100, 1000, 10000)]
        ////public int ArrayElementsCount;

        ////private int[] intValues;

        ////private object[] objectValues;

        ////[Setup]
        ////public void Setup()
        ////{
        ////    this.intValues = new int[this.ArrayElementsCount];
        ////    this.objectValues = new object[this.ArrayElementsCount];

        ////    for (int i = 0; i < this.ArrayElementsCount; i++)
        ////    {
        ////        this.intValues[i] = i;
        ////        this.objectValues[i] = i;
        ////    }
        ////}

        [Benchmark]
        public void ArgumentAsArrayOfIntPassedAsArrayOfInt()
        {
            this.ArgumentAsArrayOfInt(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 });
        }

        [Benchmark]
        public void ArgumentAsArrayOfIntPassedAsArrayOfObjects()
        {
            this.ArgumentAsArrayOfInt(new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 });
        }

        [Benchmark]
        public void ArgumentAsIEnumerableOfIntPassedAsArrayOfInt()
        {
            this.ArgumentAsIEnumerableOfInt(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 });
        }

        [Benchmark]
        public void ArgumentAsIEnumerableOfIntPassedAsArrayOfObjects()
        {
            this.ArgumentAsIEnumerableOfInt(new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 });
        }

        [Benchmark]
        public void ArgumentAsArrayOfIntWithEnumerationPassedAsArrayOfInt()
        {
            this.ArgumentAsArrayOfIntWithEnumeration(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 });
        }

        [Benchmark]
        public void ArgumentAsArrayOfIntWithEnumerationPassedAsArrayOfObjects()
        {
            this.ArgumentAsArrayOfIntWithEnumeration(new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 });
        }

        private void ArgumentAsArrayOfInt(int[] ints)
        {
            foreach (var value in ints)
            {
            }
        }

        private void ArgumentAsArrayOfIntWithEnumeration(int[] ints)
        {
            foreach (var value in ints)
            {
            }
        }

        private void ArgumentAsIEnumerableOfInt(IEnumerable<int> ints)
        {
            foreach (var value in ints)
            {
            }
        }
    }
}