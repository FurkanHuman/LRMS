﻿using Business.Abstract.Base;
using Core.Utilities.Result.Abstract;
using Entities.Concrete.Infos;

namespace Business.Abstract
{
    public interface IConsultantService : IFirstPersonBaseService<Consultant>
    {
        IDataResult<IList<Consultant>> GetAllByNamePreAttachment(string namePreAttachment);
    }
}
