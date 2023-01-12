// this file was created automatically.
using Core.Persistence.Repositories;
using Domain.Entities.Infos;
using Persistence.Contexts;
using Application.Repositories;

namespace Persistence.Repositories;

public class InterpretersRepository : EfRepositoryBase<Interpreters, PostgreLrmsDbContext>, IInterpretersRepository
{
    public InterpretersRepository(PostgreLrmsDbContext context) : base(context) { }
}