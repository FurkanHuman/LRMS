// this file was created automatically.
using Core.Persistence.Repositories;
using Domain.Entities.Mains;
using Persistence.Contexts;
using Application.Repositories;

namespace Persistence.Repositories;

public class CartographicMaterialRepository : EfRepositoryBase<CartographicMaterial, PostgreLRMSDbContext>, ICartographicMaterialRepository
{
    public CartographicMaterialRepository(PostgreLRMSDbContext context) : base(context) { }
}
