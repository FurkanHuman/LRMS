using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Utilities.Result.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class GraphicalImageManager: IGraphicalImageService
    {
        private readonly IGraphicalImageDal _graphicalImageDal;

        public IResult Add(GraphicalImage entity)
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

        public IResult Update(GraphicalImage entity)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<GraphicalImage>> GetAll()
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<GraphicalImage>> GetAllByFilter(Expression<Func<GraphicalImage, bool>>? filter = null)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<GraphicalImage>> GetAllBySecrets()
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<GraphicalImage>> GetByCategories(int[] categoriesId)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<GraphicalImage>> GetByDescriptionFinder(string finderString)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<GraphicalImage>> GetByDimension(Guid dimensionId)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<GraphicalImage>> GetByEMFiles(Guid eMFilesId)
        {
            throw new NotImplementedException();
        }

        public IDataResult<GraphicalImage> GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<GraphicalImage>> GetByIds(Guid[] ids)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<GraphicalImage>> GetByImageCreatedDate(DateTime DateTime)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<GraphicalImage>> GetByNames(string name)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<GraphicalImage>> GetByOtherPeoples(Guid otherPeopleId)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<GraphicalImage>> GetByPrice(decimal minPrice, decimal? maxPrice = null)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<GraphicalImage>> GetByTechnicalPlaceholders(Guid technicalPlaceholderId)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<GraphicalImage>> GetByTitles(string title)
        {
            throw new NotImplementedException();
        }

        public IDataResult<byte?> GetSecretLevel(Guid id)
        {
            throw new NotImplementedException();
        }

        public IDataResult<byte> GetState(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
