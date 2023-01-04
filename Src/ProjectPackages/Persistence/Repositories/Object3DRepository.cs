// this file was created automatically.
using Core.Persistence.Repositories;
using Domain.Entities.Mains;
using Persistence.Contexts;
using Application.Repositories;

namespace Persistence.Repositories;

public class Object3DRepository : EfRepositoryBase<Object3D, PostgreLrmsDbContext>, IObject3DRepository
{
    public Object3DRepository(PostgreLrmsDbContext context) : base(context) { }
}
