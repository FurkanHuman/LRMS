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
{
    public class ComposerManager : IComposerService
    {
        private readonly IComposerDal _composerDal;

        public ComposerManager(IComposerDal composerDal)
        {
            _composerDal = composerDal;
        }

        [ValidationAspect(typeof(ComposerValidator), Priority = 1)]
        public IResult Add(Composer entity)
        {
            IResult result = BusinessRules.Run(ComposerNameOrSurnameExist(entity));
            if (result != null)
                return result;

            _composerDal.Add(entity);
            return new SuccessResult(ComposerConstants.AddSuccess);
        }

        public IResult Delete(Composer entity)
        {
            _composerDal.Delete(entity);
            return new SuccessResult(ComposerConstants.DeleteSuccess);
        }

        public IResult Update(Composer entity)
        {
            _composerDal.Update(entity);
            return new SuccessResult(ComposerConstants.UpdateSuccess);
        }

        public IDataResult<List<Composer>> GetByFilterList(Expression<Func<Composer, bool>>? filter = null)
        {
            return new SuccessDataResult<List<Composer>>(_composerDal.GetAll(filter).ToList(), ComposerConstants.DataGet);
        }

        public IDataResult<Composer> GetById(int id)
        {
            return new SuccessDataResult<Composer>(_composerDal.Get(c => c.Id.Equals(id) && !c.IsDeleted), ComposerConstants.DataGet);
        }

        public IDataResult<List<Composer>> GetList()
        {
            return new SuccessDataResult<List<Composer>>(_composerDal.GetAll().ToList(), ComposerConstants.DataGet);
        }

        public IDataResult<Composer> GetByName(string name)
        {
            Composer composer = _composerDal.Get(c => c.Name.ToLowerInvariant().Equals(name.ToLowerInvariant()) && !c.IsDeleted);
            return composer == null
                ? new ErrorDataResult<Composer>(ComposerConstants.DataNotGet)
                : new SuccessDataResult<Composer>(composer, ComposerConstants.DataGet);
        }

        public IDataResult<Composer> GetBySurname(string surname)
        {
            Composer composer = _composerDal.Get(c => c.SurName.ToLowerInvariant().Equals(surname.ToLowerInvariant()) && !c.IsDeleted);
            return composer == null
               ? new ErrorDataResult<Composer>(ComposerConstants.DataNotGet)
               : new SuccessDataResult<Composer>(composer, ComposerConstants.DataGet);
        }

        public IDataResult<List<Composer>> GetNamePreAttachmentList(string namePreAttachment)
        {

            return new SuccessDataResult<List<Composer>>(_composerDal.GetAll(c => c.NamePreAttachment.ToLowerInvariant().Contains(namePreAttachment.ToLowerInvariant())
            && !c.IsDeleted).ToList(), ComposerConstants.DataGet);
        }

        private IResult ComposerNameOrSurnameExist(Composer entity)
        {
            bool result = _composerDal.GetAll(c => c.Name.ToUpperInvariant().Equals(entity.Name.ToUpperInvariant())
            && c.SurName.ToUpperInvariant().Equals(entity.SurName.ToUpperInvariant())
            && c.NamePreAttachment.Equals(null)
            && entity.NamePreAttachment != null).Any();
            return result
                ? new ErrorResult(ComposerConstants.NameOrSurnameExists)
                : new SuccessResult(ComposerConstants.DataGet);
        }
    }
}