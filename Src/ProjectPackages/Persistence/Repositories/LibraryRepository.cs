// this file was created automatically.
using Core.Persistence.Repositories;
using Domain.Entities.Infos;
using Persistence.Contexts;
using Application.Repositories;

namespace Persistence.Repositories;

public class LibraryRepository : EfRepositoryBase<Library, PostgreLrmsDbContext>, ILibraryRepository
{
    public LibraryRepository(PostgreLrmsDbContext context) : base(context) { }
}
