// this file was created automatically.
using Core.Persistence.Repositories;
using Domain.Entities.Infos;
using Persistence.Contexts;
using Application.Repositories;

namespace Persistence.Repositories;

public class CloudStorageRepository : EfRepositoryBase<CloudStorage, PostgreLrmsDbContext>, ICloudStorageRepository
{
    public CloudStorageRepository(PostgreLrmsDbContext context) : base(context) { }
}
