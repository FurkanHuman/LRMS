﻿using Core.DataAccess.PostgreDb;
using DataAccess.Abstract;
using DataAccess.Context;
using Entities.Concrete.Infos;

namespace DataAccess.Concrete
{
    public class EfImageDal : EfEntityRepositoryBase<Image, PostgreDbContext>, IImageDal
    {
    }
}