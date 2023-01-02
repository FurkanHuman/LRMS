// this file was created automatically.
using Core.Persistence.Repositories;
using Domain.Entities.Infos;
using Persistence.Contexts;
using Application.Repositories;

namespace Persistence.Repositories;

public class EditionRepository : EfRepositoryBase<Edition, PostgreLRMSDbContext>, IEditionRepository
{
    public EditionRepository(PostgreLRMSDbContext context) : base(context) { }
}
