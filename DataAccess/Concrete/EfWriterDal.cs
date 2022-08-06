using Core.DataAccess.PostgreDb;
using DataAccess.Abstract;
using DataAccess.Contexts;
using Entities.Concrete.Infos;
using Entities.DTOs.Infos;
using System.Linq.Expressions;

namespace DataAccess.Concrete
{
    public class EfWriterDal : EfEntityRepositoryBase<Writer, PostgreDbContext>, IWriterDal
    {
        public WriterDto? DtoGet(Expression<Func<Writer, bool>> filter)
        {
            using PostgreDbContext context = new();
            Writer? w = context.Set<Writer>().FirstOrDefault(filter.Compile());
            return w != null
                ? new WriterDto
                {
                    Id = w.Id,
                    Name = w.Name,
                    SurName = w.SurName,
                    NamePreAttachment = w.NamePreAttachment
                }
                : null;
        }

        public IList<WriterDto> DtoGetAll(Expression<Func<Writer, bool>>? filter = null)
        {
            using PostgreDbContext context = new();

            IQueryable<WriterDto> wDto =

                from dw in filter is null
                      ? context.Writers
                      : context.Writers.Where(filter)

                select new WriterDto
                {
                    Id = dw.Id,
                    Name = dw.Name,
                    SurName = dw.SurName,
                    NamePreAttachment = dw.NamePreAttachment
                };

            return wDto.ToList();
        }
    }
}
