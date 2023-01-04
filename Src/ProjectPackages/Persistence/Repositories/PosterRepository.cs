// this file was created automatically.
using Core.Persistence.Repositories;
using Domain.Entities.Mains;
using Persistence.Contexts;
using Application.Repositories;

namespace Persistence.Repositories;

public class PosterRepository : EfRepositoryBase<Poster, PostgreLrmsDbContext>, IPosterRepository
{
    public PosterRepository(PostgreLrmsDbContext context) : base(context) { }
}
