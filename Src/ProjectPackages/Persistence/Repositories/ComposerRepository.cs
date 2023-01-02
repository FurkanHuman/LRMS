// this file was created automatically.
using Core.Persistence.Repositories;
using Domain.Entities.Infos;
using Persistence.Contexts;
using Application.Repositories;

namespace Persistence.Repositories;

public class ComposerRepository : EfRepositoryBase<Composer, PostgreLRMSDbContext>, IComposerRepository
{
    public ComposerRepository(PostgreLRMSDbContext context) : base(context) { }
}
