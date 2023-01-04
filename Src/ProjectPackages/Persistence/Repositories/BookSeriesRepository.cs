// this file was created automatically.
using Core.Persistence.Repositories;
using Domain.Entities.Mains;
using Persistence.Contexts;
using Application.Repositories;

namespace Persistence.Repositories;

public class BookSeriesRepository : EfRepositoryBase<BookSeries, PostgreLrmsDbContext>, IBookSeriesRepository
{
    public BookSeriesRepository(PostgreLrmsDbContext context) : base(context) { }
}
