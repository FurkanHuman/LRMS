using Business.Abstract;
using Business.Constants;
using Business.DependencyResolvers.Facade;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Result.Abstract;
using Core.Utilities.Result.Concrete;
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
    public class ThesisManager : IThesisService
    {
        private readonly IThesisDal _thesisDal;
        private readonly IFacadeService _facadeService;

        public ThesisManager(IThesisDal thesisDal, IFacadeService facadeService)
        {
            _thesisDal = thesisDal;
            _facadeService = facadeService;
        }

        [ValidationAspect(typeof(ThesisValidator))]
        public IResult Add(Thesis entity)
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

        [ValidationAspect(typeof(ThesisValidator))]
        public IResult Update(Thesis entity)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<Thesis>> GetAll()
        {
            throw new NotImplementedException();
        }

        public IDataResult<IEnumerable<Thesis>> GetAllByApprovalStatus(bool status)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<Thesis>> GetAllByCategories(int[] categoriesId)
        {
            throw new NotImplementedException();
        }

        public IDataResult<IEnumerable<Thesis>> GetAllByCityId(int cityId)
        {
            throw new NotImplementedException();
        }

        public IDataResult<IEnumerable<Thesis>> GetAllByCityName(string cityName)
        {
            throw new NotImplementedException();
        }

        public IDataResult<IEnumerable<Thesis>> GetAllByConsultantId(Guid consultantId)
        {
            throw new NotImplementedException();
        }

        public IDataResult<IEnumerable<Thesis>> GetAllByConsultantIds(Guid[] consultantIds)
        {
            throw new NotImplementedException();
        }

        public IDataResult<IEnumerable<Thesis>> GetAllByCountryCode(string countryCode)
        {
            throw new NotImplementedException();
        }

        public IDataResult<IEnumerable<Thesis>> GetAllByCountryId(int countryId)
        {
            throw new NotImplementedException();
        }

        public IDataResult<IEnumerable<Thesis>> GetAllByDateTimeYear(ushort year)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<Thesis>> GetAllByDescriptionFinder(string finderString)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<Thesis>> GetAllByDimension(Guid dimensionId)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<Thesis>> GetAllByEMFile(Guid eMFileId)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<Thesis>> GetAllByFilter(Expression<Func<Thesis, bool>>? filter = null)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<Thesis>> GetAllByIds(Guid[] ids)
        {
            throw new NotImplementedException();
        }

        public IDataResult<IEnumerable<Thesis>> GetAllBylangaugeId(Guid langaugeId)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<Thesis>> GetAllByName(string name)
        {
            throw new NotImplementedException();
        }

        public IDataResult<IEnumerable<Thesis>> GetAllByPermissionStatus(bool status)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<Thesis>> GetAllByPrice(decimal minPrice, decimal? maxPrice = null)
        {
            throw new NotImplementedException();
        }

        public IDataResult<IEnumerable<Thesis>> GetAllByResearcherId(Guid researcherId)
        {
            throw new NotImplementedException();
        }

        public IDataResult<IEnumerable<Thesis>> GetAllByResearcherIds(Guid[] researcherIds)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<Thesis>> GetAllBySecret()
        {
            throw new NotImplementedException();
        }

        public IDataResult<IEnumerable<Thesis>> GetAllBySecretStatus(bool status)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<Thesis>> GetAllByTechnicalPlaceholder(Guid technicalPlaceholderId)
        {
            throw new NotImplementedException();
        }

        public IDataResult<IEnumerable<Thesis>> GetAllByThesisDegree(byte degree)
        {
            throw new NotImplementedException();
        }

        public IDataResult<IEnumerable<Thesis>> GetAllByThesisNumber(int thesisNumber)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<Thesis>> GetAllByTitle(string title)
        {
            throw new NotImplementedException();
        }

        public IDataResult<IEnumerable<Thesis>> GetAllByUniversityId(Guid universityId)
        {
            throw new NotImplementedException();
        }

        public IDataResult<IEnumerable<Thesis>> GetAllByUniversityId(Guid[] universityIds)
        {
            throw new NotImplementedException();
        }

        public IDataResult<Thesis> GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public IDataResult<Thesis> GetByStock(Guid stockId)
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

        private IResult ThesisDbControl(Thesis thesis)
        {
            bool thesisDbControl = _thesisDal.Get(t=>
            // todo return here 
            t.Name ==thesis.Name
            && t.Description.Contains(thesis.Description)
            
            ) != null;

            if (thesisDbControl)
                return new ErrorResult(ThesisConstants.AlreadyExists);

            return new SuccessResult();
        }
    }
}
