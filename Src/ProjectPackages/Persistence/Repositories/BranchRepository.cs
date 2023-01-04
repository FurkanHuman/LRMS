// this file was created automatically.
using Core.Persistence.Repositories;
using Domain.Entities.Infos;
using Persistence.Contexts;
using Application.Repositories;

namespace Persistence.Repositories;

public class BranchRepository : EfRepositoryBase<Branch, PostgreLrmsDbContext>, IBranchRepository
{
    public BranchRepository(PostgreLrmsDbContext context) : base(context) { }
}
