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
            entity.IsDeleted = false;
            _composerDal.Add(entity);
            return new SuccessResult(ComposerConstants.AddSuccess);
        }

        public IResult Delete(Guid id)
        {
            Composer composer = _composerDal.Get(g => g.Id == id);
            if (composer == null)
                return new ErrorResult(GraphicDesignConstants.NotMatch);

            _composerDal.Delete(composer);
            return new SuccessResult(GraphicDesignConstants.DeleteSuccess);
        }

        public IResult ShadowDelete(Guid id)
        {
            Composer composer = _composerDal.Get(g => g.Id == id && !g.IsDeleted);
            if (composer == null)
                return new ErrorResult(GraphicDesignConstants.NotMatch);

            composer.IsDeleted = true;
            _composerDal.Update(composer);
            return new SuccessResult(GraphicDesignConstants.ShadowDeleteSuccess);
        }

        [ValidationAspect(typeof(ComposerValidator), Priority = 1)]
        public IResult Update(Composer entity)
        {
            _composerDal.Update(entity);
            return new SuccessResult(ComposerConstants.UpdateSuccess);
        }

        public IDataResult<List<Composer>> GetByFilterLists(Expression<Func<Composer, bool>>? filter = null)
        {
            return new SuccessDataResult<List<Composer>>(_composerDal.GetAll(filter).ToList(), ComposerConstants.DataGet);
        }

        public IDataResult<Composer> GetById(Guid id)
        {
            Composer composer= _composerDal.Get(c => c.Id == id);
            return composer == null
                ? new ErrorDataResult<Composer>(ComposerConstants.NotMatch)
                : new SuccessDataResult<Composer>(composer,ComposerConstants.DataGet);
        }

        public IDataResult<List<Composer>> GetByNames(string name)
        {
            List<Composer> composers = _composerDal.GetAll(c => c.Name.Contains(name,StringComparison.CurrentCultureIgnoreCase) && !c.IsDeleted).ToList();
            return composers == null
                ? new ErrorDataResult<List<Composer>>(ComposerConstants.DataNotGet)
                : new SuccessDataResult<List<Composer>>(composers, ComposerConstants.DataGet);
        }

        public IDataResult<List<Composer>> GetBySurnames(string surname)
        {
            List<Composer> composers = _composerDal.GetAll(c => c.SurName.Contains(surname,StringComparison.CurrentCultureIgnoreCase) && !c.IsDeleted).ToList();
            return composers == null
               ? new ErrorDataResult<List<Composer>>(ComposerConstants.DataNotGet)
               : new SuccessDataResult<List<Composer>>(composers, ComposerConstants.DataGet);
        }

        public IDataResult<List<Composer>> GetNamePreAttachmentLists(string namePreAttachment)
        {
            return new SuccessDataResult<List<Composer>>(_composerDal.GetAll(c => c.NamePreAttachment.Contains(namePreAttachment, StringComparison.CurrentCultureIgnoreCase)
            && !c.IsDeleted).ToList(), ComposerConstants.DataGet);
        }

        public IDataResult<List<Composer>> GetAll()
        {
            return new SuccessDataResult<List<Composer>>(_composerDal.GetAll(c => !c.IsDeleted).ToList(), ComposerConstants.DataGet);
        }

        public IDataResult<List<Composer>> GetAllBySecrets()
        {
            return new SuccessDataResult<List<Composer>>(_composerDal.GetAll(c => c.IsDeleted).ToList(), ComposerConstants.DataGet);
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