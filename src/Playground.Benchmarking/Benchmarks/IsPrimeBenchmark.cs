namespace Playground.Benchmarking.Benchmarks
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using BenchmarkDotNet.Attributes;

    using Playground.Benchmarking.Configs;

    [Config(typeof(DefaultConfig))]
    public class IsPrimeBenchmark
    {
        [Benchmark(Baseline = true)]
        public List<int> Left() => Enumerable.Range(0, 10 * 1000).Where(IsPrimeLeft).ToList();

        [Benchmark]
        public List<int> Right() => Enumerable.Range(0, 10 * 1000).Where(IsPrimeRight).ToList();

        private static bool IsPrimeLeft(int number)
        {
            if (number == 0 || number == 1)
            {
                return false;
            }

            if (number == 2)
            {
                return true;
            }

            var max = number / 2;

            for (var divisor = 2; divisor <= max; divisor++)
            {
                if (number % divisor == 0)
                {
                    return false;
                }
            }

            return true;
        }

        private static bool IsPrimeRight(int number)
        {
            if (number == 0 || number == 1)
            {
                return false;
            }

            if (number == 2)
            {
                return true;
            }

            for (var divisor = 2; divisor <= (int)Math.Floor(Math.Sqrt(number)); divisor++)
            {
                if (number % divisor == 0)
                {
                    return false;
                }
            }

            return true;
        }
    }
}