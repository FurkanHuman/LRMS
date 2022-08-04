﻿using Business.Abstract.Base;
using Core.Utilities.Result.Abstract;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IPosterService : IMaterialBaseService<Poster>
    {
        IDataResult<IList<Poster>> GetAllByOwnerId(Guid ownerId);
        IDataResult<IList<Poster>> GetAllByOwnersId(Guid[] ownerIds);
        IDataResult<IList<Poster>> GetAllByDestroyState(bool state);
        IDataResult<Poster> GetByImageId(Guid imageId);
    }
}
