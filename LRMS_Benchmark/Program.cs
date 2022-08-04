
using Autofac;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using Business.Concrete;
using Business.DependencyResolvers.Facade;
using Core.Utilities.Result.Abstract;
using DataAccess.Concrete;
using Entities.Concrete.Infos;
using Microsoft.Extensions.Hosting;

namespace LRMS_Benchmark
{
    public class Program
    {
        private readonly EfWriterDal _efCategoryDal = new();

        [Benchmark]
        public void IGetAllBechMark() => _efCategoryDal.IGetAll();

        [Benchmark]
        public void GetAllBechMark() => _efCategoryDal.GetAll();


        static void Main(string[] args)
        {
            BenchmarkRunner.Run<Program>();
        }
    }
}