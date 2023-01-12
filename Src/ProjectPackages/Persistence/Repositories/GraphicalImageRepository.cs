// this file was created automatically.
using Core.Persistence.Repositories;
using Domain.Entities.Mains;
using Persistence.Contexts;
using Application.Repositories;

namespace Persistence.Repositories;

public class GraphicalImageRepository : EfRepositoryBase<GraphicalImage, PostgreLrmsDbContext>, IGraphicalImageRepository
{
    public GraphicalImageRepository(PostgreLrmsDbContext context) : base(context) { }
}