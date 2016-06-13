namespace Playground.Benchmarking.Configs
{
    using BenchmarkDotNet.Configs;
    using BenchmarkDotNet.Diagnostics.Windows;

    public class DefaultConfig : ManualConfig
    {
        public DefaultConfig()
        {
            this.Add(new MemoryDiagnoser());
            //this.Add(new InliningDiagnoser());
        }
    }
}