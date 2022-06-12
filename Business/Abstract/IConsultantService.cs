﻿using Business.Abstract.Base;
using Core.Utilities.Result.Abstract;
using Entities.Concrete;
using Entities.Concrete.Infos;

namespace Business.Abstract
{
    public interface IConsultantService : IFirstPersonBaseService<Consultant>
    {
        IDataResult<List<Consultant>> GetNamePreAttachmentLists(string namePreAttachment);
    }
}
