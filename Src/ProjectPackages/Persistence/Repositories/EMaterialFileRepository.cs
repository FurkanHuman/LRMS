// this file was created automatically.
using Core.Persistence.Repositories;
using Domain.Entities.Infos;
using Persistence.Contexts;
using Application.Repositories;

namespace Persistence.Repositories;

public class EMaterialFileRepository : EfRepositoryBase<EMaterialFile, PostgreLrmsDbContext>, IEMaterialFileRepository
{
    public EMaterialFileRepository(PostgreLrmsDbContext context) : base(context) { }
}
