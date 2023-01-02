// this file was created automatically.
using Core.Persistence.Repositories;
using Domain.Entities.Infos;
using Persistence.Contexts;
using Application.Repositories;

namespace Persistence.Repositories;

public class CloudStorageRepository : EfRepositoryBase<CloudStorage, PostgreLRMSDbContext>, ICloudStorageRepository
{
    public CloudStorageRepository(PostgreLRMSDbContext context) : base(context) { }
}
