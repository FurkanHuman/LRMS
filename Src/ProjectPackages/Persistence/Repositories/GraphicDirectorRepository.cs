// this file was created automatically.
using Core.Persistence.Repositories;
using Domain.Entities.Infos;
using Persistence.Contexts;
using Application.Repositories;

namespace Persistence.Repositories;

public class GraphicDirectorRepository : EfRepositoryBase<GraphicDirector, PostgreLRMSDbContext>, IGraphicDirectorRepository
{
    public GraphicDirectorRepository(PostgreLRMSDbContext context) : base(context) { }
}
