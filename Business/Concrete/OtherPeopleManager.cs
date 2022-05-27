﻿using Business.Abstract;
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
{   // true usage write all manager todo
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

        public IResult Delete(OtherPeople entity)
        {
            bool opQ = _otherPeopleDal.GetAll(op => op == entity).Any();
            if (!opQ)
                return new ErrorResult(OtherPeopleConstants.NotMatch);

            _otherPeopleDal.Delete(entity);
            return new SuccessResult(OtherPeopleConstants.DeleteSuccess);
        }

        public IResult ShadowDelete(Guid guid)
        {
            OtherPeople otherPeople = _otherPeopleDal.Get(op => op.Id == guid && !op.IsDeleted);
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

        public IDataResult<List<OtherPeople>> GetByFilterList(Expression<Func<OtherPeople, bool>>? filter = null)
        {
            return new SuccessDataResult<List<OtherPeople>>(_otherPeopleDal.GetAll(filter).ToList(), OtherPeopleConstants.DataGet);
        }

        public IDataResult<OtherPeople> GetById(Guid guid)
        {
            OtherPeople otherPeople = _otherPeopleDal.Get(op => op.Id == guid && !op.IsDeleted);
            if (otherPeople == null)
                return new ErrorDataResult<OtherPeople>(OtherPeopleConstants.DataNotGet);
            return new SuccessDataResult<OtherPeople>(OtherPeopleConstants.DataGet);
        }

        public IDataResult<List<OtherPeople>> GetByNamePreAttch(string preAttch)
        {
            List<OtherPeople> otherPeoples = _otherPeopleDal.GetAll(op => op.NamePreAttachment.Contains(preAttch, StringComparison.CurrentCultureIgnoreCase)
            && !op.IsDeleted).ToList();

            if (otherPeoples == null)
                return new ErrorDataResult<List<OtherPeople>>(OtherPeopleConstants.DataNotGet);

            return new SuccessDataResult<List<OtherPeople>>(otherPeoples, OtherPeopleConstants.DataGet);
        }

        public IDataResult<List<OtherPeople>> GetByNames(string name)
        {
            List<OtherPeople> otherPeoples = _otherPeopleDal.GetAll(op => op.Name.Contains(name, StringComparison.CurrentCultureIgnoreCase)
            && !op.IsDeleted).ToList();

            if (otherPeoples == null)
                return new ErrorDataResult<List<OtherPeople>>(OtherPeopleConstants.DataNotGet);

            return new SuccessDataResult<List<OtherPeople>>(otherPeoples, OtherPeopleConstants.DataGet);
        }

        public IDataResult<List<OtherPeople>> GetBySurnames(string surname)
        {
            List<OtherPeople> otherPeoples = _otherPeopleDal.GetAll(op => op.SurName.Contains(surname, StringComparison.CurrentCultureIgnoreCase) && !op.IsDeleted
            && !op.IsDeleted).ToList();

            if (otherPeoples == null)
                return new ErrorDataResult<List<OtherPeople>>(OtherPeopleConstants.DataNotGet);

            return new SuccessDataResult<List<OtherPeople>>(otherPeoples, OtherPeopleConstants.DataGet);
        }

        public IDataResult<List<OtherPeople>> GetByTitles(string title)
        {
            List<OtherPeople> otherPeoples = _otherPeopleDal.GetAll(op => op.Title.Contains(title, StringComparison.CurrentCultureIgnoreCase)
            && !op.IsDeleted).ToList();

            if (otherPeoples == null)
                return new ErrorDataResult<List<OtherPeople>>(OtherPeopleConstants.DataNotGet);

            return new SuccessDataResult<List<OtherPeople>>(otherPeoples, OtherPeopleConstants.DataGet);
        }

        public IDataResult<List<OtherPeople>> GetList()
        {
            return new SuccessDataResult<List<OtherPeople>>(_otherPeopleDal.GetAll(op => !op.IsDeleted).ToList(), OtherPeopleConstants.DataGet);
        }

        private IResult OtherPeopleExits(OtherPeople otherPeople)
        {
            bool res = _otherPeopleDal.GetAll(op =>
            op.Name.Contains(otherPeople.Name, StringComparison.CurrentCultureIgnoreCase)
            && op.SurName.Contains(otherPeople.SurName, StringComparison.CurrentCultureIgnoreCase)
            && op.Title.Contains(otherPeople.Title, StringComparison.CurrentCultureIgnoreCase)
            && op.NamePreAttachment.Contains(otherPeople.NamePreAttachment, StringComparison.CurrentCultureIgnoreCase)
            ).Any();

            if (res)
                return new ErrorResult(OtherPeopleConstants.OtherPAlreadyExists);

            return new SuccessResult();
        }
    }
}
