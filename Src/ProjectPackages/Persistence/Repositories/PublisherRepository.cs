// this file was created automatically.
using Core.Persistence.Repositories;
using Domain.Entities.Infos;
using Persistence.Contexts;
using Application.Repositories;

namespace Persistence.Repositories;

public class PublisherRepository : EfRepositoryBase<Publisher, PostgreLrmsDbContext>, IPublisherRepository
{
    public PublisherRepository(PostgreLrmsDbContext context) : base(context) { }
}
