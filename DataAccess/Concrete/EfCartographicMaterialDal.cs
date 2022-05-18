﻿using Core.DataAccess.PostgreDb;
using DataAccess.Abstract;
using DataAccess.Context;
using Entities.Concrete;

namespace DataAccess.Concrete
{
    public class EfCartographicMaterialDal : EfEntityRepositoryBase<CartographicMaterial, PostgreDbContext>, ICartographicMaterialDal
    {
    }
}