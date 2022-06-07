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
        private readonly ITechnicalNumberService _technicalNumberService;

        public ReferenceManager(IReferenceDal referenceDal, ITechnicalNumberService technicalNumberService)
        {
            _referenceDal = referenceDal;
            _technicalNumberService = technicalNumberService;
        }

        [ValidationAspect(typeof(ReferenceValidator), Priority = 1)]
        public IResult Add(Reference entity)
        {
            IResult result = BusinessRules.Run(CheckRefence(entity));
            if (result != null)
                return result;

            IDataResult<TechnicalNumber> techNumber = _technicalNumberService.GetById(entity.TechnicalNumber.Id);
            if (!techNumber.Success)
                return techNumber;

            entity.IsDeleted = false;
            _referenceDal.Add(entity);
            return new SuccessResult();
        }

        public IResult Delete(Guid id)
        {
            Reference reference = _referenceDal.Get(r => r.Id == id);
            if (reference == null)
                return new ErrorResult(ReferenceConstants.NotMatch);

            _referenceDal.Delete(reference);
            return new SuccessResult(ReferenceConstants.DeleteSuccess);
        }

        public IResult ShadowDelete(Guid id)
        {
            Reference reference = _referenceDal.Get(r => r.Id == id);
            if (reference == null)
                return new ErrorResult(ReferenceConstants.NotMatch);

            reference.IsDeleted = true;
            _referenceDal.Update(reference);
            return new SuccessResult(ReferenceConstants.ShadowDeleteSuccess);
        }

        [ValidationAspect(typeof(ReferenceValidator), Priority = 1)]
        public IResult Update(Reference entity)
        {
            IResult result = BusinessRules.Run(CheckRefence(entity));
            if (result != null)
                return result;

            IDataResult<TechnicalNumber> techNumber = _technicalNumberService.GetById(entity.TechnicalNumber.Id);
            if (!techNumber.Success)
                return techNumber;

            _referenceDal.Update(entity);
            return new SuccessResult();
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

        public IDataResult<List<Reference>> GetByOwner(string ownerStr)
        {
            List<Reference> references = _referenceDal.GetAll(r => r.Owner.Contains(ownerStr) && !r.IsDeleted).ToList();
            return references == null
                 ? new ErrorDataResult<List<Reference>>(ReferenceConstants.DataNotGet)
                 : new SuccessDataResult<List<Reference>>(references, ReferenceConstants.DataGet);
        }

        public IDataResult<List<Reference>> GetByReferenceDate(DateOnly date)
        {
            List<Reference> references = _referenceDal.GetAll(r => r.ReferenceDate == date && !r.IsDeleted).ToList();
            return references == null
                 ? new ErrorDataResult<List<Reference>>(ReferenceConstants.DataNotGet)
                 : new SuccessDataResult<List<Reference>>(references, ReferenceConstants.DataGet);
        }

        public IDataResult<List<Reference>> GetBySubText(string subText)
        {
            List<Reference> references = _referenceDal.GetAll(r => r.SubText.Contains(subText) && !r.IsDeleted).ToList();
            return references == null
                 ? new ErrorDataResult<List<Reference>>(ReferenceConstants.DataNotGet)
                 : new SuccessDataResult<List<Reference>>(references, ReferenceConstants.DataGet);
        }

        private IResult CheckRefence(Reference entity)
        {
            bool refControl = _referenceDal.GetAll(r =>
               r.SubText.Contains(entity.SubText)
            && r.Owner.Contains(entity.Owner)
            && r.ReferenceDate == entity.ReferenceDate
            && r.TechnicalNumber == entity.TechnicalNumber).Any();

            if (refControl)
                return new ErrorResult(ReferenceConstants.ReferenceExist);

            if (entity.ReferenceDate.Day >= 10)
                return new ErrorResult(ReferenceConstants.DateError);

            return new SuccessResult();
        }
    }
}
