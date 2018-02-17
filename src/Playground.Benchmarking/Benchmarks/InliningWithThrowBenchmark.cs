namespace Playground.Benchmarking.Benchmarks
{
    using System;
    using System.Runtime.CompilerServices;

    using BenchmarkDotNet.Attributes;
    using BenchmarkDotNet.Configs;
    using BenchmarkDotNet.Diagnostics.Windows;
    using BenchmarkDotNet.Environments;
    using BenchmarkDotNet.Jobs;

    [Config(typeof(BenchmarkConfig))]
    public class InliningWithThrowBenchmark
    {
        [Params("NotNull")]
        public object Parameter { get; set; }

        [Benchmark(Baseline = true)]
        public Controller1 IfNullThenThrow()
        {
            return new Controller1(this.Parameter);
        }


        [Benchmark]
        public Controller2 Ensure()
        {
            return new Controller2(this.Parameter);
        }

        [Benchmark]
        public Controller3 EnsureOnSteroids()
        {
            return new Controller3(this.Parameter);
        }

        [Benchmark]
        public Controller4 EnsureOnSteroidsWithoutArgument()
        {
            return new Controller4(this.Parameter);
        }

        class BenchmarkConfig : ManualConfig
        {
            public BenchmarkConfig()
            {
                this.Add(Job.Default.With(Jit.RyuJit).With(Runtime.Clr).With(Platform.X64));
                this.Add(new InliningDiagnoser());
            }
        }
    }

    public class Controller1
    {
        private readonly object dependency;

        public Controller1(object dependency)
        {
            if (dependency == null)
            {
                throw new ArgumentNullException(nameof(dependency));
            }

            this.dependency = dependency;
        }
    }

    public class Controller2
    {
        private readonly object dependency;

        public Controller2(object dependency)
        {
            Verify.Argument.IsNotNull(nameof(dependency), dependency);

            this.dependency = dependency;
        }
    }

    public class Controller3
    {
        private readonly object dependency;

        public Controller3(object dependency)
        {
            VerifyOnSteroids.Argument.NotNull(nameof(dependency), dependency);

            this.dependency = dependency;
        }
    }

    public class Controller4
    {
        private readonly object dependency;

        public Controller4(object dependency)
        {
            VerifyOnSteroids.IsNotNull(nameof(dependency), dependency);

            this.dependency = dependency;
        }
    }

    public static class Verify
    {
        public static class Argument
        {
            public static void IsNotNull<T>(string parameterName, T value) where T : class
            {
                if (value == null)
                {
                    throw new ArgumentNullException(parameterName);
                }
            }
        }
    }

    public static class VerifyOnSteroids
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void IsNotNull<T>(string parameterName, T value) where T : class
        {
            if (value == null)
            {
                Throw.ArgumentNullException(parameterName);
            }
        }

        public static class Argument
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static void NotNull<T>(string parameterName, T value) where T : class
            {
                if (value == null)
                {
                    Throw.ArgumentNullException(parameterName);
                }
            }
        }

        private static class Throw
        {
            [MethodImpl(MethodImplOptions.NoInlining)]
            public static void ArgumentNullException(string parameterName)
            {
                throw new ArgumentNullException(parameterName);
            }
        }
    }
}