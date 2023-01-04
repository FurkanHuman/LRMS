// this file was created automatically.
using Core.Persistence.Repositories;
using Domain.Entities.Infos;
using Persistence.Contexts;
using Application.Repositories;

namespace Persistence.Repositories;

public class ConsultantRepository : EfRepositoryBase<Consultant, PostgreLrmsDbContext>, IConsultantRepository
{
    public ConsultantRepository(PostgreLrmsDbContext context) : base(context) { }
}
