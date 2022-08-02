
using Autofac;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using Business.Concrete;
using Business.DependencyResolvers.Facade;
using Core.Utilities.Result.Abstract;
using DataAccess.Concrete;
using Entities.Concrete.Infos;
using Microsoft.Extensions.Hosting;

namespace LRMS_Benchmark_CLI
{
    public class Program
    {
        private readonly EfCategoryDal _efCategoryDal = new();
        private readonly EfCategoryDal _iefCategoryDal = new();

        [Benchmark]
        public void IGetAllBechMark() => _iefCategoryDal.IGetAll();

        [Benchmark]
        public void GetAllBechMark() => _efCategoryDal.GetAll();


        static void Main(string[] args)
        {
            BenchmarkRunner.Run<Program>();
        }
    }
}