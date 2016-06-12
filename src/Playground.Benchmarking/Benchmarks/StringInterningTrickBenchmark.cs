namespace Playground.Benchmarking.Benchmarks
{
    using BenchmarkDotNet.Attributes;

    using Playground.Benchmarking.Configs;

    [Config(typeof(DefaultConfig))]
    public class StringInterningTrickBenchmark
    {
        private string value;

        [Params(1, 100, 1000)]
        public int Loops;

        [Params("", "0", "1", "value")]
        public string val;

        [Benchmark(Baseline = true)]
        public void SetValueNormal()
        {
            this.SetValue(this.val);
        }

        [Benchmark]
        public void SetValueWithTrick()
        {
            this.SetValueWithTrick(this.val);
        }

        public void SetValue(string val)
        {
            this.value = val;
        }

        public void SetValueWithTrick(string val)
        {
            if (val.Length == 1)
            {
                switch (val[0])
                {
                    case '0':
                        this.value = "0";
                        break;
                    case '1':
                        this.value = "1";
                        break;
                    default:
                        this.value = val;
                        break;
                }
            }
        }
    }
}