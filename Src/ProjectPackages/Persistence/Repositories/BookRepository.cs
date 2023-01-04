// this file was created automatically.
using Core.Persistence.Repositories;
using Domain.Entities.Mains;
using Persistence.Contexts;
using Application.Repositories;

namespace Persistence.Repositories;

public class BookRepository : EfRepositoryBase<Book, PostgreLrmsDbContext>, IBookRepository
{
    public BookRepository(PostgreLrmsDbContext context) : base(context) { }
}
