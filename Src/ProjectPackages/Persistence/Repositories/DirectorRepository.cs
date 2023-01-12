// this file was created automatically.
using Core.Persistence.Repositories;
using Domain.Entities.Infos;
using Persistence.Contexts;
using Application.Repositories;

namespace Persistence.Repositories;

public class DirectorRepository : EfRepositoryBase<Director, PostgreLrmsDbContext>, IDirectorRepository
{
    public DirectorRepository(PostgreLrmsDbContext context) : base(context) { }
}