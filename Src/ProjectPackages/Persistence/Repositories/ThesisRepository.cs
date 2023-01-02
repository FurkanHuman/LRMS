// this file was created automatically.
using Core.Persistence.Repositories;
using Domain.Entities.Mains;
using Persistence.Contexts;
using Application.Repositories;

namespace Persistence.Repositories;

public class ThesisRepository : EfRepositoryBase<Thesis, PostgreLRMSDbContext>, IThesisRepository
{
    public ThesisRepository(PostgreLRMSDbContext context) : base(context) { }
}
