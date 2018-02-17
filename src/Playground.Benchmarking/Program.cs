namespace Playground.Benchmarking
{
    using BenchmarkDotNet.Running;

    using Playground.Benchmarking.Benchmarks;

    public class Program
    {
        public static void Main(string[] args)
        {
            var switcher =
                new BenchmarkSwitcher(
                    new[]
                        {
                            typeof(DictionaryVsIDictionaryBenchmark),
                            typeof(ListVsIEnumerableBenchmark),
                            typeof(StringFormatBenchmark),
                            typeof(RedundantTypeSpecificationBenchmark),
                            typeof(StringAllocations),
                            typeof(SimpleExtensionMethods),
                            typeof(StringInterningBenchmark),
                            typeof(StringInterningTrickBenchmark),
                            typeof(StringSplitBenchmark),
                            typeof(LinqWhereBenchmark),
                            typeof(SimpleStringFormattingBenchmark),
                            typeof(StringFormatterBenchmark),
                            typeof(MethodInvocationOverheadBenchmark),
                            typeof(UniValueGetValueBenchmark),
                            typeof(MethodGroupExpressionBenchmark),
                            typeof(CostOfIsSubclassOfBenchmark),
                            typeof(StringEmptyBenchmark),
                            typeof(InliningWithThrowBenchmark),
                            typeof(HashSetVsUnsafeArrayLookupBenchmark),
                            typeof(InstructionLevelParallelism),
                            typeof(IsPrimeBenchmark),
                            typeof(LoopVariableBenchmark),
                            typeof(FalseSharingBenchmark)
                        });

            switcher.Run(args);
        }
    }
}