using Business.Abstract;
using Business.Constants;
using Business.DependencyResolvers.Facade;
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
        private readonly IFacadeService _facadeService;

        public ReferenceManager(IReferenceDal referenceDal)
        {
            _referenceDal = referenceDal;
        }

        [ValidationAspect(typeof(ReferenceValidator), Priority = 1)]
        public IResult Add(Reference entity)
        {
            IResult result = BusinessRules.Run(CheckRefence(entity));
            if (result != null)
                return result;

            IDataResult<TechnicalNumber> techNumber = _facadeService.TechnicalNumberService().GetById(entity.TechnicalNumber.Id);
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

            IDataResult<TechnicalNumber> techNumber = _facadeService.TechnicalNumberService().GetById(entity.TechnicalNumber.Id);
            if (!techNumber.Success)
                return techNumber;

            _referenceDal.Update(entity);
            return new SuccessResult();
        }

        public IDataResult<IList<Reference>> GetAll()
        {
            return new SuccessDataResult<IList<Reference>>(_referenceDal.GetAll(r => !r.IsDeleted), ReferenceConstants.DataGet);
        }

        public IDataResult<IList<Reference>> GetAllByIsDeleted()
        {
            return new SuccessDataResult<IList<Reference>>(_referenceDal.GetAll(r => r.IsDeleted), ReferenceConstants.DataGet);
        }

        public IDataResult<IList<Reference>> GetAllByFilter(Expression<Func<Reference, bool>>? filter = null)
        {
            return new SuccessDataResult<IList<Reference>>(_referenceDal.GetAll(filter), ReferenceConstants.DataGet);
        }

        public IDataResult<Reference> GetById(Guid id)
        {
            Reference reference = _referenceDal.Get(r => r.Id == id);

            return reference == null
                ? new ErrorDataResult<Reference>(ReferenceConstants.DataNotGet)
                : new SuccessDataResult<Reference>(reference, ReferenceConstants.DataGet);
        }

        public IDataResult<IList<Reference>> GetAllByIds(Guid[] ids)
        {
            IList<Reference> references = _referenceDal.GetAll(r => ids.Contains(r.Id) && !r.IsDeleted);
            return references == null
                 ? new ErrorDataResult<IList<Reference>>(ReferenceConstants.DataNotGet)
                 : new SuccessDataResult<IList<Reference>>(references, ReferenceConstants.DataGet);
        }

        public IDataResult<IList<Reference>> GetAllByName(string name)
        {
            return new ErrorDataResult<IList<Reference>>(ReferenceConstants.Disabled);
        }

        public IDataResult<IList<Reference>> GetAllByOwner(string ownerStr)
        {
            IList<Reference> references = _referenceDal.GetAll(r => r.Owner.Contains(ownerStr) && !r.IsDeleted);
            return references == null
                 ? new ErrorDataResult<IList<Reference>>(ReferenceConstants.DataNotGet)
                 : new SuccessDataResult<IList<Reference>>(references, ReferenceConstants.DataGet);
        }

        public IDataResult<IList<Reference>> GetAllByReferenceDate(DateTime date)
        {
            IList<Reference> references = _referenceDal.GetAll(r => r.ReferenceDate == date && !r.IsDeleted);
            return references == null
                 ? new ErrorDataResult<IList<Reference>>(ReferenceConstants.DataNotGet)
                 : new SuccessDataResult<IList<Reference>>(references, ReferenceConstants.DataGet);
        }

        public IDataResult<IList<Reference>> GetAllBySubText(string subText)
        {
            IList<Reference> references = _referenceDal.GetAll(r => r.SubText.Contains(subText) && !r.IsDeleted);
            return references == null
                 ? new ErrorDataResult<IList<Reference>>(ReferenceConstants.DataNotGet)
                 : new SuccessDataResult<IList<Reference>>(references, ReferenceConstants.DataGet);
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
