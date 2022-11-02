using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

namespace Benchmark;

public class Program
{

    [Benchmark]
    public void GetAllBechMark()
    {

    }

    static void Main(string[] args)
    {
        BenchmarkRunner.Run<Program>();
    }
}