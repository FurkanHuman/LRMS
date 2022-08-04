﻿using Core.Utilities.Result.Abstract;
using Entities.Concrete.Infos;
using Microsoft.AspNetCore.Http;
using System.Linq.Expressions;

namespace Business.Abstract
{
    public interface IImageService
    {
        IDataResult<Image> Add(IFormFile file);
        IResult Delete(Guid id);
        IResult ShadowDelete(Guid id);
        IDataResult<Image> Update(IFormFile file, Image image);
        IDataResult<Image> GetById(Guid id);
        IDataResult<IList<Image>> GetAllByIds(Guid[] ids);
        IDataResult<IList<Image>> GetAllByFilter(Expression<Func<Image, bool>>? filter = null);
        IDataResult<IList<Image>> GetAllByIsDeleted();
        IDataResult<IList<Image>> GetAll();
    }
}
