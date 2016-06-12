namespace Playground.Benchmarking
{
    using System;

    using BenchmarkDotNet.Running;

    using Playground.Benchmarking.Benchmarks;

    public class Program
    {
        public static void Main(string[] args)
        {
            ////BenchmarkRunner.Run<DictionaryVsIDictionaryBenchmark>();

            ////BenchmarkRunner.Run<ListVsIEnumerableBenchmark>();

            ////BenchmarkRunner.Run<StringFormatBenchmark>();

            ////BenchmarkRunner.Run<RedundantTypeSpecificationBenchmark>();

            ////BenchmarkRunner.Run<StringAllocations>();

            ////BenchmarkRunner.Run<SimpleExtensionMethods>();

            ////BenchmarkRunner.Run<Gen2CollectionBenchmark>();

            ////BenchmarkRunner.Run<StringInterningBenchmark>();

            ////BenchmarkRunner.Run<StringInterningTrickBenchmark>();

            ////BenchmarkRunner.Run<StringSplitBenchmark>();

            ////BenchmarkRunner.Run<Gen2CollectionBenchmark>();

            ////BenchmarkRunner.Run<LinqWhereBenchmark>();

            ////BenchmarkRunner.Run<SimpleStringFormattingBenchmark>();

            ////BenchmarkRunner.Run<StringFormatterBenchmark>();

            ////BenchmarkRunner.Run<MethodInvocationOverheadBenchmark>();

            ////BenchmarkRunner.Run<ReadOnlyFiledVsNormalFieldBenchmark>();

            BenchmarkRunner.Run<UniValueGetValueBenchmark>();

            Console.ReadKey(false);
        }
    }
}
