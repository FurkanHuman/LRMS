﻿using Core.DataAccess.PostgreDb;
using DataAccess.Abstract;
using DataAccess.Contexts;
using Entities.Concrete.Infos;

namespace DataAccess.Concrete
{
    public class EfRedactionDal : EfEntityRepositoryBase<Redaction, PostgreDbContext>, IRedactionDal
    {
    }
}
