// this file was created automatically.
using Core.Persistence.Repositories;
using Domain.Entities.Mains;
using Persistence.Contexts;
using Application.Repositories;

namespace Persistence.Repositories;

public class BookSeriesRepository : EfRepositoryBase<BookSeries, PostgreLRMSDbContext>, IBookSeriesRepository
{
    public BookSeriesRepository(PostgreLRMSDbContext context) : base(context) { }
}
