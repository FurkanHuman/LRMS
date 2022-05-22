﻿using Core.DataAccess.PostgreDb;
using DataAccess.Abstract;
using DataAccess.Contexts;
using Entities.Concrete;

namespace DataAccess.Concrete
{
    public class EfObject3DDal : EfEntityRepositoryBase<Object3D, PostgreDbContext>, IObject3DDal
    {
    }
}
