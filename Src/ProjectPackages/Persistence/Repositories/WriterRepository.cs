// this file was created automatically.
using Core.Persistence.Repositories;
using Domain.Entities.Infos;
using Persistence.Contexts;
using Application.Repositories;

namespace Persistence.Repositories;

public class WriterRepository : EfRepositoryBase<Writer, PostgreLrmsDbContext>, IWriterRepository
{
    public WriterRepository(PostgreLrmsDbContext context) : base(context) { }
}
