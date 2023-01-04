// this file was created automatically.
using Core.Persistence.Repositories;
using Domain.Entities.Infos;
using Persistence.Contexts;
using Application.Repositories;

namespace Persistence.Repositories;

public class CommunicationRepository : EfRepositoryBase<Communication, PostgreLrmsDbContext>, ICommunicationRepository
{
    public CommunicationRepository(PostgreLrmsDbContext context) : base(context) { }
}
