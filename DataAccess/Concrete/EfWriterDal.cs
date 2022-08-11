using AutoMapper;
using Core.DataAccess.PostgreDb;
using DataAccess.Abstract;
using DataAccess.Contexts;
using Entities.Concrete.Infos;
using Entities.DTOs.Infos;
using System.Linq.Expressions;

namespace DataAccess.Concrete
{
    public class EfWriterDal : EfEntityRepositoryBase<Writer, WriterDto, PostgreDbContext>, IWriterDal
    {
    }
}
