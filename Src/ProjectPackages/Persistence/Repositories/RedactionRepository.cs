// this file was created automatically.
using Core.Persistence.Repositories;
using Domain.Entities.Infos;
using Persistence.Contexts;
using Application.Repositories;

namespace Persistence.Repositories;

public class RedactionRepository : EfRepositoryBase<Redaction, PostgreLRMSDbContext>, IRedactionRepository
{
    public RedactionRepository(PostgreLRMSDbContext context) : base(context) { }
}
