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
    public class OtherPeopleManager : IOtherPeopleService
    {
        private readonly IOtherPeopleDal _otherPeopleDal;

        public OtherPeopleManager(IOtherPeopleDal otherPeopleDal)
        {
            _otherPeopleDal = otherPeopleDal;
        }

        [ValidationAspect(typeof(OtherPeopleValidator), Priority = 1)]
        public IResult Add(OtherPeople entity)
        {
            IResult result = BusinessRules.Run(OtherPeopleExits(entity));
            if (result != null)
                return result;

            entity.IsDeleted = false;
            _otherPeopleDal.Add(entity);
            return new SuccessResult(OtherPeopleConstants.AddSuccess);
        }

        public IResult Delete(Guid id)
        {
            OtherPeople otherPeople = _otherPeopleDal.Get(op => op.Id == id);
            if (otherPeople == null)
                return new ErrorResult(OtherPeopleConstants.NotMatch);

            _otherPeopleDal.Delete(otherPeople);
            return new SuccessResult(OtherPeopleConstants.DeleteSuccess);
        }

        public IResult ShadowDelete(Guid id)
        {
            OtherPeople otherPeople = _otherPeopleDal.Get(op => op.Id == id && !op.IsDeleted);
            if (otherPeople == null)
                return new ErrorResult(OtherPeopleConstants.NotMatch);

            otherPeople.IsDeleted = true;
            _otherPeopleDal.Update(otherPeople);
            return new SuccessResult(OtherPeopleConstants.ShadowDeleteSuccess);
        }

        [ValidationAspect(typeof(OtherPeopleValidator), Priority = 1)]
        public IResult Update(OtherPeople entity)
        {
            bool opQ = _otherPeopleDal.GetAll(op => op.Id == entity.Id && !op.IsDeleted).Any();
            if (!opQ)
                return new ErrorResult(OtherPeopleConstants.NotMatch);

            _otherPeopleDal.Update(entity);
            return new SuccessResult(OtherPeopleConstants.UpdateSuccess);
        }

        public IDataResult<IList<OtherPeople>> GetAllByFilter(Expression<Func<OtherPeople, bool>>? filter = null)
        {
            return new SuccessDataResult<IList<OtherPeople>>(_otherPeopleDal.GetAll(filter), OtherPeopleConstants.DataGet);
        }

        public IDataResult<OtherPeople> GetById(Guid id)
        {
            OtherPeople otherPeople = _otherPeopleDal.Get(op => op.Id == id);
            return otherPeople == null
                ? new ErrorDataResult<OtherPeople>(OtherPeopleConstants.DataNotGet)
                : new SuccessDataResult<OtherPeople>(otherPeople, OtherPeopleConstants.DataGet);
        }

        public IDataResult<IList<OtherPeople>> GetAllByIds(Guid[] ids)
        {
            IList<OtherPeople> otherPeoples = _otherPeopleDal.GetAll(op => ids.Contains(op.Id) && !op.IsDeleted);

            return otherPeoples == null
                ? new ErrorDataResult<IList<OtherPeople>>(OtherPeopleConstants.DataNotGet)
                : new SuccessDataResult<IList<OtherPeople>>(otherPeoples, OtherPeopleConstants.DataGet);
        }

        public IDataResult<IList<OtherPeople>> GetAllByNamePreAttach(string preAttch)
        {
            IList<OtherPeople> otherPeoples = _otherPeopleDal.GetAll(op => op.NamePreAttachment.Contains(preAttch)
            && !op.IsDeleted);

            if (otherPeoples == null)
                return new ErrorDataResult<IList<OtherPeople>>(OtherPeopleConstants.DataNotGet);
            return new SuccessDataResult<IList<OtherPeople>>(otherPeoples, OtherPeopleConstants.DataGet);
        }

        public IDataResult<IList<OtherPeople>> GetAllByName(string name)
        {
            IList<OtherPeople> otherPeoples = _otherPeopleDal.GetAll(op => op.Name.Contains(name)
            && !op.IsDeleted);

            if (otherPeoples == null)
                return new ErrorDataResult<IList<OtherPeople>>(OtherPeopleConstants.DataNotGet);

            return new SuccessDataResult<IList<OtherPeople>>(otherPeoples, OtherPeopleConstants.DataGet);
        }

        public IDataResult<IList<OtherPeople>> GetAllBySurname(string surname)
        {
            IList<OtherPeople> otherPeoples = _otherPeopleDal.GetAll(op => op.SurName.Contains(surname) && !op.IsDeleted
            && !op.IsDeleted);

            if (otherPeoples == null)
                return new ErrorDataResult<IList<OtherPeople>>(OtherPeopleConstants.DataNotGet);

            return new SuccessDataResult<IList<OtherPeople>>(otherPeoples, OtherPeopleConstants.DataGet);
        }

        public IDataResult<IList<OtherPeople>> GetAllByTitle(string title)
        {
            IList<OtherPeople> otherPeoples = _otherPeopleDal.GetAll(op => op.Title.Contains(title)
            && !op.IsDeleted);

            if (otherPeoples == null)
                return new ErrorDataResult<IList<OtherPeople>>(OtherPeopleConstants.DataNotGet);

            return new SuccessDataResult<IList<OtherPeople>>(otherPeoples, OtherPeopleConstants.DataGet);
        }

        public IDataResult<IList<OtherPeople>> GetAllByIsDeleted()
        {
            return new SuccessDataResult<IList<OtherPeople>>(_otherPeopleDal.GetAll(op => op.IsDeleted), OtherPeopleConstants.DataGet);
        }

        public IDataResult<IList<OtherPeople>> GetAll()
        {
            return new SuccessDataResult<IList<OtherPeople>>(_otherPeopleDal.GetAll(op => !op.IsDeleted), OtherPeopleConstants.DataGet);
        }

        private IResult OtherPeopleExits(OtherPeople otherPeople)
        {
            bool res = _otherPeopleDal.GetAll(op =>
            op.Name.Contains(otherPeople.Name)
            && op.SurName.Contains(otherPeople.SurName)
            && op.Title.Contains(otherPeople.Title)
            && op.NamePreAttachment.Contains(otherPeople.NamePreAttachment)
            ).Any();

            if (res)
                return new ErrorResult(OtherPeopleConstants.OtherPAlreadyExists);

            return new SuccessResult();
        }
    }
}
