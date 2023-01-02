// this file was created automatically.
using Core.Persistence.Repositories;
using Domain.Entities.Infos;
using Persistence.Contexts;
using Application.Repositories;

namespace Persistence.Repositories;

public class ConsultantRepository : EfRepositoryBase<Consultant, PostgreLRMSDbContext>, IConsultantRepository
{
    public ConsultantRepository(PostgreLRMSDbContext context) : base(context) { }
}
