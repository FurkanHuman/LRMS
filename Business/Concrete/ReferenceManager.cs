using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Result.Abstract;
using Core.Utilities.Result.Concrete;
using DataAccess.Abstract;
using Entities.Concrete.Infos;
using System.Linq.Expressions;

namespace Business.Concrete
{
    public class ReferenceManager : IReferenceService   //reference Todo
    {
        private readonly IReferenceDal _referenceDal;
        private readonly ITechnicalNumberService _numberService;

        public ReferenceManager(IReferenceDal referenceDal, ITechnicalNumberService numberService)
        {
            _referenceDal = referenceDal;
            _numberService = numberService;
        }

        [ValidationAspect(typeof(ReferenceValidator), Priority = 1)]
        public IResult Add(Reference entity)
        {
            IResult result = BusinessRules.Run(CheckRefence(entity));
            if (result != null)
                return result;

            _referenceDal.Add(entity);
            return new SuccessResult();
        }

        public IResult Delete(Guid id)
        {
            return new ErrorResult(ReferenceConstants.Maintenance);
        }

        public IResult ShadowDelete(Guid id)
        {
            return new ErrorResult(ReferenceConstants.Maintenance);
        }

        [ValidationAspect(typeof(ReferenceValidator), Priority = 1)]
        public IResult Update(Reference entity)
        {
            return new ErrorResult(ReferenceConstants.Maintenance);
        }

        public IDataResult<List<Reference>> GetAll()
        {
            return new SuccessDataResult<List<Reference>>(_referenceDal.GetAll(r => !r.IsDeleted).ToList(), ReferenceConstants.DataGet);
        }

        public IDataResult<List<Reference>> GetAllBySecrets()
        {
            return new SuccessDataResult<List<Reference>>(_referenceDal.GetAll(r => r.IsDeleted).ToList(), ReferenceConstants.DataGet);
        }

        public IDataResult<List<Reference>> GetByFilterLists(Expression<Func<Reference, bool>>? filter = null)
        {
            return new SuccessDataResult<List<Reference>>(_referenceDal.GetAll(filter).ToList(), ReferenceConstants.DataGet);
        }

        public IDataResult<Reference> GetById(Guid id)
        {
            Reference reference = _referenceDal.Get(r => r.Id == id);

            return reference == null
                ? new ErrorDataResult<Reference>(ReferenceConstants.DataNotGet)
                : new SuccessDataResult<Reference>(reference, ReferenceConstants.DataGet);
        }

        public IDataResult<List<Reference>> GetByNames(string name)
        {
            return new ErrorDataResult<List<Reference>>(ReferenceConstants.Disabled);
        }

        private IResult CheckRefence(Reference entity)
        {
            return new ErrorResult(ReferenceConstants.Maintenance);
        }
    }
}
