// this file was created automatically.
using Core.Persistence.Repositories;
using Domain.Entities.Mains;
using Persistence.Contexts;
using Application.Repositories;

namespace Persistence.Repositories;

public class ThesisRepository : EfRepositoryBase<Thesis, PostgreLrmsDbContext>, IThesisRepository
{
    public ThesisRepository(PostgreLrmsDbContext context) : base(context) { }
}
