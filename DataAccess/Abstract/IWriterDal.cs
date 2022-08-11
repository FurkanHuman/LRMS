using Core.DataAccess;
using Entities.Concrete.Infos;
using Entities.DTOs.Infos;

namespace DataAccess.Abstract
{
    public interface IWriterDal : IEntityRepository<Writer>, IDtoRepository<Writer>, IDtoRepository<WriterDto, Writer>
    {
    }
}
