// this file was created automatically.
using Core.Persistence.Repositories;
using Domain.Entities.Infos;
using Persistence.Contexts;
using Application.Repositories;

namespace Persistence.Repositories;

public class LanguageRepository : EfRepositoryBase<Language, PostgreLRMSDbContext>, ILanguageRepository
{
    public LanguageRepository(PostgreLRMSDbContext context) : base(context) { }
}
