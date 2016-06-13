namespace Playground.Benchmarking.Benchmarks
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using BenchmarkDotNet.Attributes;
    using BenchmarkDotNet.Configs;
    using BenchmarkDotNet.Diagnostics.Windows;
    using BenchmarkDotNet.Jobs;

    [Config(typeof(MethodGroupExpressionBenchmarkConfig))]
    public class MethodGroupExpressionBenchmark
    {
        private readonly string[] strings = { "test", "asd", "dsa", "qwe", "ewq" };

        [Benchmark(Baseline = true)]
        public IEnumerable<string> LambdaWithInstanceMethod()
        {
            return this.Evaluate(s => this.Filter(s));
        }

        [Benchmark]
        public IEnumerable<string> LambdaWithStaticMethod()
        {
            return this.Evaluate(s => StaticFilter(s));
        }

        [Benchmark]
        public IEnumerable<string> MethodGroupExpressionWithInstanceMethod()
        {
            return this.Evaluate(this.Filter);
        }

        [Benchmark]
        public IEnumerable<string> MethodGroupExpressionWithStaticMethod()
        {
            return this.Evaluate(StaticFilter);
        }

        private IEnumerable<string> Evaluate(Func<string, bool> func)
        {
            return this.strings.Where(s => func(s));
        }

        private static bool StaticFilter(string value)
        {
            return !value.Contains("test");
        }

        private bool Filter(string value)
        {
            return !value.Contains("test");
        }

        public class MethodGroupExpressionBenchmarkConfig : ManualConfig
        {
            public MethodGroupExpressionBenchmarkConfig()
            {
                ////this.Add(Job.Default.With(Framework.V45).With(Runtime.Clr).With(Platform.X64));
                ////this.Add(Job.Default.With(Framework.V462).With(Runtime.Clr).With(Platform.X64));
                ////this.Add(Job.LegacyJitX64, Job.RyuJitX64);
                this.Add(new MemoryDiagnoser());
            }
        }
    }
}