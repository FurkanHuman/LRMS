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
    public class ConsultantManager : IConsultantService
    {
        private readonly IConsultantDal _consultantDal;

        public ConsultantManager(IConsultantDal consultantDal)
        {
            _consultantDal = consultantDal;
        }

        [ValidationAspect(typeof(ConsultantValidator), Priority = 1)]
        public IResult Add(Consultant entity)
        {
            IResult result = BusinessRules.Run(ConsultantExist(entity));
            if (result != null)
                return result;
            entity.IsDeleted = false;
            _consultantDal.Add(entity);
            return new SuccessResult(ConsultantConstants.AddSuccess);
        }

        public IResult ShadowDelete(Guid id)
        {
            Consultant consultant = _consultantDal.Get(c => c.Id == id && !c.IsDeleted);
            if (consultant == null)
                return new ErrorResult(ConsultantConstants.NotMatch);

            consultant.IsDeleted = true;
            _consultantDal.Update(consultant);
            return new SuccessResult(ConsultantConstants.ShadowDeleteSuccess);
        }

        public IResult Delete(Guid id)
        {
            Consultant consultant = _consultantDal.Get(c => c.Id == id);
            if (consultant == null)
                return new ErrorResult(ConsultantConstants.DataNotGet);

            _consultantDal.Delete(consultant);
            return new SuccessResult(ConsultantConstants.DeleteSuccess);
        }

        [ValidationAspect(typeof(ConsultantValidator), Priority = 1)]
        public IResult Update(Consultant entity)
        {
            IResult result = BusinessRules.Run(ConsultantExist(entity));
            if (result != null)
                return result;

            _consultantDal.Update(entity);
            return new SuccessResult(ConsultantConstants.UpdateSuccess);
        }

        public IDataResult<IList<Consultant>> GetAllByFilter(Expression<Func<Consultant, bool>>? filter = null)
        {
            IList<Consultant> consultants = _consultantDal.GetAll(filter);

            return consultants == null
                ? new ErrorDataResult<IList<Consultant>>(ConsultantConstants.DataNotGet)
                : new SuccessDataResult<IList<Consultant>>(consultants, ConsultantConstants.DataGet);
        }

        public IDataResult<Consultant> GetById(Guid id)
        {
            Consultant consultant = _consultantDal.Get(c => c.Id == id);
            return consultant == null
                ? new ErrorDataResult<Consultant>(ConsultantConstants.NotMatch)
                : new SuccessDataResult<Consultant>(consultant, ConsultantConstants.NotMatch);
        }

        public IDataResult<IList<Consultant>> GetAllByIds(Guid[] ids)
        {
            IList<Consultant> consultants = _consultantDal.GetAll(c => ids.Contains(c.Id) && !c.IsDeleted);

            return consultants == null
                ? new ErrorDataResult<IList<Consultant>>(ConsultantConstants.DataNotGet)
                : new SuccessDataResult<IList<Consultant>>(consultants, ConsultantConstants.DataGet);
        }

        public IDataResult<IList<Consultant>> GetAllByName(string name)
        {
            IList<Consultant> consultants = _consultantDal.GetAll(c => c.Name.Contains(name) && !c.IsDeleted);
            return consultants == null
                ? new ErrorDataResult<IList<Consultant>>(ConsultantConstants.DataNotGet)
                : new SuccessDataResult<IList<Consultant>>(consultants, ConsultantConstants.DataGet);
        }

        public IDataResult<IList<Consultant>> GetAllBySurname(string surname)
        {
            IList<Consultant> consultants = _consultantDal.GetAll(c => c.SurName.Contains(surname) && !c.IsDeleted);

            return consultants == null
                ? new ErrorDataResult<IList<Consultant>>(ConsultantConstants.DataNotGet)
                : new SuccessDataResult<IList<Consultant>>(consultants, ConsultantConstants.DataGet);
        }

        public IDataResult<IList<Consultant>> GetAllByNamePreAttachment(string namePreAttachment)
        {
            IList<Consultant> consultants = _consultantDal.GetAll(c => c.NamePreAttachment.Contains(namePreAttachment) && !c.IsDeleted);

            return consultants == null
                ? new ErrorDataResult<IList<Consultant>>(ConsultantConstants.DataNotGet)
                : new SuccessDataResult<IList<Consultant>>(consultants, ConsultantConstants.DataGet);
        }

        public IDataResult<IList<Consultant>> GetAllByIsDeleted()
        {
            return new SuccessDataResult<IList<Consultant>>(_consultantDal.GetAll(c => !c.IsDeleted), ConsultantConstants.DataGet);
        }

        public IDataResult<IList<Consultant>> GetAll()
        {
            return new SuccessDataResult<IList<Consultant>>(_consultantDal.GetAll(c => !c.IsDeleted), ConsultantConstants.DataGet);
        }

        private IResult ConsultantExist(Consultant entity)
        {
            Consultant consultant = _consultantDal.Get(c => c.Name == entity.Name
            && c.SurName == entity.SurName
            && c.NamePreAttachment == entity.NamePreAttachment);

            if (consultant == null)
                return new SuccessResult();
            return new ErrorResult(ConsultantConstants.AlreadyExists);
        }
    }
}
