namespace Playground.Benchmarking.Benchmarks
{
    using BenchmarkDotNet.Attributes;

    using Playground.Benchmarking.Configs;

    [Config(typeof(DefaultConfig))]
    public class UniValueGetValueBenchmark
    {
        private readonly UniValue uniValue = new UniValue("5");

        private readonly StructUniValue structUniValue = new StructUniValue("5");

        class UniValue
        {
            private string value;

            // NOTE: New property
            public string Value => this.value;

            public UniValue(string theValue)
            {
                this.value = theValue;
            }

            public override string ToString()
            {
                return this.value;
            }
        }

        struct StructUniValue
        {
            private string value;

            // NOTE: New property
            public string Value => this.value;

            public StructUniValue(string theValue)
            {
                this.value = theValue;
            }

            public override string ToString()
            {
                return this.value;
            }
        }

        [Benchmark(Baseline = true)]
        public string GetValueByToString()
        {
            return this.uniValue.ToString();
        }

        [Benchmark]
        public string GetValueByProperty()
        {
            return this.uniValue.Value;
        }

        [Benchmark]
        public string GetValueByToStringFromStruct()
        {
            return this.structUniValue.ToString();
        }
    }
}