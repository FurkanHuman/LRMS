using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using Business.Concrete;
using DataAccess.Concrete;

namespace LRMS_Benchmark
{
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
}