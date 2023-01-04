// this file was created automatically.
using Core.Persistence.Repositories;
using Domain.Entities.Infos;
using Persistence.Contexts;
using Application.Repositories;

namespace Persistence.Repositories;

public class GraphicDirectorRepository : EfRepositoryBase<GraphicDirector, PostgreLrmsDbContext>, IGraphicDirectorRepository
{
    public GraphicDirectorRepository(PostgreLrmsDbContext context) : base(context) { }
}
