namespace Playground.Benchmarking.Benchmarks
{
    using System.Collections.Generic;
    using System.Linq;

    using BenchmarkDotNet.Attributes;

    using Playground.Benchmarking.Configs;

    [Config(typeof(DefaultConfig))]
    public class LinqWhereBenchmark
    {
        private List<Customer> customers;

        [Params(10, 100, 1000, 10000)]
        public int CollectionSize;

        [Setup]
        public void Setup()
        {
            this.customers = GetCustomers(this.CollectionSize);
        }

        [Benchmark(Baseline = true)]
        public Customer WherePredicateFirstOrDefault()
        {
            return this.customers.Where(c => c.Id == this.CollectionSize - 1).FirstOrDefault();
        }

        [Benchmark]
        public Customer FirstOrDefaultPredicate()
        {
            return this.customers.FirstOrDefault(c => c.Id == this.CollectionSize - 1);
        }

        private static List<Customer> GetCustomers(int customersCount)
        {
            var list = new List<Customer>(customersCount);

            for (var i = 0; i < customersCount; i++)
            {
                list.Add(new Customer
                {
                    Id = i,
                    FirstName = "FirstName" + i,
                    LastName = "LastName" + i,
                    Email = i + "@gmail.com"
                });
            }

            return list;
        }

        public class Customer
        {
            public long Id { get; set; }

            public string FirstName { get; set; }

            public string LastName { get; set; }

            public string Email { get; set; }
        }
    }
}