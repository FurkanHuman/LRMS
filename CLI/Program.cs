// See https://aka.ms/new-console-template for more information
using DataAccess.Abstract;
using DataAccess.Concrete;
using Entities.Concrete.Infos;

Console.WriteLine("Hello, World!");

ICategoryDal _CategoryDal = new EfCategoryDal();

IEnumerable<Category> categories = _CategoryDal.IGetAll();

foreach (var item in categories)
{
    Console.WriteLine(item.Name);
}
