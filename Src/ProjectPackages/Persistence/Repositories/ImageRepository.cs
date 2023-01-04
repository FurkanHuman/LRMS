// this file was created automatically.
using Core.Persistence.Repositories;
using Domain.Entities.Infos;
using Persistence.Contexts;
using Application.Repositories;

namespace Persistence.Repositories;

public class ImageRepository : EfRepositoryBase<Image, PostgreLrmsDbContext>, IImageRepository
{
    public ImageRepository(PostgreLrmsDbContext context) : base(context) { }
}
