// this file was created automatically.
using Core.Persistence.Repositories;
using Domain.Entities.Infos;
using Persistence.Contexts;
using Application.Repositories;

namespace Persistence.Repositories;

public class OtherPeopleRepository : EfRepositoryBase<OtherPeople, PostgreLRMSDbContext>, IOtherPeopleRepository
{
    public OtherPeopleRepository(PostgreLRMSDbContext context) : base(context) { }
}
