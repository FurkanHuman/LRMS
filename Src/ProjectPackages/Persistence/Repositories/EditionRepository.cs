// this file was created automatically.
using Core.Persistence.Repositories;
using Domain.Entities.Infos;
using Persistence.Contexts;
using Application.Repositories;

namespace Persistence.Repositories;

public class EditionRepository : EfRepositoryBase<Edition, PostgreLrmsDbContext>, IEditionRepository
{
    public EditionRepository(PostgreLrmsDbContext context) : base(context) { }
}
