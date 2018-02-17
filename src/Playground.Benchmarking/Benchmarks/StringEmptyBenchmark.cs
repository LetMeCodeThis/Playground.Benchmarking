namespace Playground.Benchmarking.Benchmarks
{
    using System.Runtime.CompilerServices;

    using BenchmarkDotNet.Attributes;

    using Playground.Benchmarking.Configs;

    [Config(typeof(DefaultConfig))]
    public class StringEmptyBenchmark
    {
        // TODO: Check this: There is one downside however: each time we use "", the intern pool is checked which spends some precious CPU time. (https://blog.maartenballiauw.be/post/2016/11/15/exploring-memory-allocation-and-strings.html)

        ////""		IL_000C: ldstr     ""
        ////string.Empty IL_000C: ldsfld string[mscorlib] System.String::Empty
        ////http://stackoverflow.com/questions/3674288/whats-the-different-between-ldsfld-and-ldstr-in-il
        ////private static readonly string[] Strings = { "", string.Empty };
        private static readonly string[] Strings = { "1", "2" };

        [Params(0, 1)]
        public int StringIndex { get; set; }

        ////[Benchmark(Baseline = true)]
        ////public bool StringEmpty()
        ////{
        ////    return Strings[this.StringIndex] == "1";
        ////}

        [Benchmark(Baseline = true)]
        [MethodImpl(MethodImplOptions.NoInlining)]
        public bool StringDotEmpty()
        {
            return Strings[this.StringIndex] == string.Empty;
        }

        [Benchmark]
        [MethodImpl(MethodImplOptions.NoInlining)]
        public bool EmptyString()
        {
            return Strings[this.StringIndex] == "";
        }
    }
}