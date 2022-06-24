using Business.Abstract.Base;
using Core.Utilities.Result.Abstract;
using Entities.Concrete;
using Entities.Concrete.Infos;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IDepictionService:IMaterialBaseService<Depiction>
    {
        IResult Add(IFormFile formFile, Depiction depiction);
        IResult Update(IFormFile formFile, Depiction depiction, Guid imageId);
        IDataResult<Depiction> GetByImages(Guid imageId);
    }
}
