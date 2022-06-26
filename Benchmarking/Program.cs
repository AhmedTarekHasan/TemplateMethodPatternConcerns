using System;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

namespace Benchmarking
{
    public class Program
    {
        static void Main(string[] args)
        {
            BenchmarkRunner.Run<MemoryBenchmarker>();
        }
    }

    [MemoryDiagnoser]
    [RankColumn]
    public class MemoryBenchmarker
    {
        [Benchmark]
        public decimal RunTemplateMethodPattern()
        {
            return TemplateMethodPattern.Program.Run();
        }

        [Benchmark]
        public decimal RunTemplateMethodPatternWithProperties()
        {
            return TemplateMethodPatternWithProperties.Program.Run();
        }

        [Benchmark]
        public decimal RunTemplateMethodPatternWithFlaggedEnums()
        {
            return TemplateMethodPatternWithFlaggedEnums.Program.Run();
        }

        [Benchmark]
        public decimal RunTemplateMethodPatternWithInterfaces()
        {
            return TemplateMethodPatternWithInterfaces.Program.Run();
        }

        [Benchmark]
        public decimal RunTemplateMethodPatternWithGeneratedExpressionUsingProperties()
        {
            return TemplateMethodPatternWithGeneratedExpressionUsingProperties.Program.Run();
        }
    }
}