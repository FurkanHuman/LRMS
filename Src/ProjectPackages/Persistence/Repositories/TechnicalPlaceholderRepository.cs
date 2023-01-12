// this file was created automatically.
using Core.Persistence.Repositories;
using Domain.Entities.Infos;
using Persistence.Contexts;
using Application.Repositories;

namespace Persistence.Repositories;

public class TechnicalPlaceholderRepository : EfRepositoryBase<TechnicalPlaceholder, PostgreLrmsDbContext>, ITechnicalPlaceholderRepository
{
    public TechnicalPlaceholderRepository(PostgreLrmsDbContext context) : base(context) { }
}