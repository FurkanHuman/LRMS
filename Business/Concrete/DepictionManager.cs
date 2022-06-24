using Business.Abstract;
using DataAccess.Abstract;
using Core.Utilities.Result.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Core.Utilities.Result.Concrete;
using Business.Constants;

namespace Business.Concrete
{
    public class DepictionManager : IDepictionService
    {
        private readonly IDepictionDal _depictionDal;

        private readonly ICategoryService _categoryService;
        private readonly IDimensionService _dimensionService;
        private readonly IEMaterialFileService _eMaterialFileService;
        private readonly IImageService _imageService;
        private readonly ITechnicalPlaceholderService _technicalPlaceholderService;

        public IResult Add(Depiction entity)
        {
            throw new NotImplementedException();
        }

        public IResult Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public IResult ShadowDelete(Guid id)
        {
            throw new NotImplementedException();
        }

        public IResult Update(Depiction entity)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<Depiction>> GetAll()
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<Depiction>> GetAllByFilter(Expression<Func<Depiction, bool>>? filter = null)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<Depiction>> GetAllBySecrets()
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<Depiction>> GetByCategories(int[] categoriesId)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<Depiction>> GetByDescriptionFinder(string finderString)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<Depiction>> GetByDimension(Guid dimensionId)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<Depiction>> GetByEMFiles(Guid eMFilesId)
        {
            throw new NotImplementedException();
        }

        public IDataResult<Depiction> GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<Depiction>> GetByNames(string name)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<Depiction>> GetByPrice(decimal minPrice, decimal? maxPrice = null)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<Depiction>> GetByTechnicalPlaceholders(Guid technicalPlaceholderId)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<Depiction>> GetByTitles(string title)
        {
            throw new NotImplementedException();
        }

        public IDataResult<byte?> GetSecretLevel(Guid id)
        {
            byte? sLevel = _depictionDal.Get(d=>d.Id==id && !d.IsDeleted).SecretLevel;
            return sLevel == null
                ? new ErrorDataResult<byte?>(DepictionConstants.DataNotGet)
                : new SuccessDataResult<byte?>(sLevel, DepictionConstants.DataGet);
        }

        public IDataResult<byte> GetState(Guid id)
        {
            return new SuccessDataResult<byte>(_depictionDal.Get(d => d.Id == id && !d.IsDeleted).State,DepictionConstants.DataGet);
        }
    }
}
