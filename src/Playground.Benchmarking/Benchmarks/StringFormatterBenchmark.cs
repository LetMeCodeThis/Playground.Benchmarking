namespace Playground.Benchmarking.Benchmarks
{
    using System.Text.Formatting;

    using BenchmarkDotNet.Attributes;

    using Playground.Benchmarking.Configs;

    [Config(typeof(DefaultConfig))]
    public class StringFormatterBenchmark
    {
        private readonly string[] FormattingSpecifications =
            {
                "My name is {0} {1} and my email address is {2}|Joe,Doe,joe.doe@gmail.com",
                "Error occured while executing {0} with parameters: {1} - {2}, {3} - {4}, {5} - {6}|MethodName,name,Name,startIndex,0,endIndex,100"
            };

        [Benchmark(Baseline = true)]
        public string StringFormat()
        {
            return string.Format(
                "Error occured while executing {0} with parameters: {1} - {2}, {3} - {4}, {5} - {6}",
                "MethodName",
                "name",
                "Name",
                "startIndex",
                "0",
                "endIndex",
                "100");
        }

        [Benchmark]
        public string StringFormatter()
        {
            return
                StringBuffer.Format(
                    "Error occured while executing {0} with parameters: {1} - {2}, {3} - {4}, {5} - {6}",
                    "MethodName",
                    "name",
                    "Name",
                    "startIndex",
                    "0",
                    "endIndex",
                    "100");
        }
    }
}