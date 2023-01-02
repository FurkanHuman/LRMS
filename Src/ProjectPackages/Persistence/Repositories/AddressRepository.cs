// this file was created automatically.
using Core.Persistence.Repositories;
using Domain.Entities.Infos;
using Persistence.Contexts;
using Application.Repositories;

namespace Persistence.Repositories;

public class AddressRepository : EfRepositoryBase<Address, PostgreLRMSDbContext>, IAddressRepository
{
    public AddressRepository(PostgreLRMSDbContext context) : base(context) { }
}
