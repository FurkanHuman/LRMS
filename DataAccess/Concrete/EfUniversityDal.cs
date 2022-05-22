﻿using Core.DataAccess.PostgreDb;
using DataAccess.Abstract;
using DataAccess.Contexts;
using Entities.Concrete.Infos;

namespace DataAccess.Concrete
{
    public class EfUniversityDal : EfEntityRepositoryBase<University, PostgreDbContext>, IUniversityDal
    {
    }
}
