using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

namespace CallingEmptyMethods
{
    public class Program
    {
        static void Main(string[] args)
        {
            var summary = BenchmarkRunner.Run<MemoryBenchmarker>();
        }
    }

    [MemoryDiagnoser]
    [RankColumn]
    public class MemoryBenchmarker
    {
        [Benchmark]
        public decimal RunSlow()
        {
            decimal total = 0;

            for (int i = 0; i < 10_000_000; i++)
            {
                total += Calc(1);
            }

            return total;
        }

        [Benchmark]
        public decimal RunFast()
        {
            decimal total = 0;

            for (int i = 0; i < 10_000_000; i++)
            {
                // do nothing
            }

            return total;
        }

        public decimal Calc(decimal a)
        {
            return a;
        }
    }
}