// this file was created automatically.
using Core.Persistence.Repositories;
using Domain.Entities.Infos;
using Persistence.Contexts;
using Application.Repositories;

namespace Persistence.Repositories;

public class GraphicDesignerRepository : EfRepositoryBase<GraphicDesigner, PostgreLrmsDbContext>, IGraphicDesignerRepository
{
    public GraphicDesignerRepository(PostgreLrmsDbContext context) : base(context) { }
}