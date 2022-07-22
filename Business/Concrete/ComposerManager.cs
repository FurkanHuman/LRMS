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
                return new ErrorResult(ComposerConstants.NotMatch);

            _composerDal.Delete(composer);
            return new SuccessResult(ComposerConstants.DeleteSuccess);
        }

        public IResult ShadowDelete(Guid id)
        {
            Composer composer = _composerDal.Get(g => g.Id == id && !g.IsDeleted);
            if (composer == null)
                return new ErrorResult(ComposerConstants.NotMatch);

            composer.IsDeleted = true;
            _composerDal.Update(composer);
            return new SuccessResult(ComposerConstants.ShadowDeleteSuccess);
        }

        [ValidationAspect(typeof(ComposerValidator), Priority = 1)]
        public IResult Update(Composer entity)
        {
            _composerDal.Update(entity);
            return new SuccessResult(ComposerConstants.UpdateSuccess);
        }

        public IDataResult<List<Composer>> GetAllByFilter(Expression<Func<Composer, bool>>? filter = null)
        {
            return new SuccessDataResult<List<Composer>>(_composerDal.GetAll(filter).ToList(), ComposerConstants.DataGet);
        }

        public IDataResult<Composer> GetById(Guid id)
        {
            Composer composer = _composerDal.Get(c => c.Id == id);
            return composer == null
                ? new ErrorDataResult<Composer>(ComposerConstants.NotMatch)
                : new SuccessDataResult<Composer>(composer, ComposerConstants.DataGet);
        }

        public IDataResult<List<Composer>> GetAllByIds(Guid[] ids)
        {
            List<Composer> composers = _composerDal.GetAll(c => ids.Contains(c.Id) && !c.IsDeleted).ToList();
            return composers == null
               ? new ErrorDataResult<List<Composer>>(ComposerConstants.DataNotGet)
               : new SuccessDataResult<List<Composer>>(composers, ComposerConstants.DataGet);
        }

        public IDataResult<List<Composer>> GetAllByName(string name)
        {
            List<Composer> composers = _composerDal.GetAll(c => c.Name.Contains(name) && !c.IsDeleted).ToList();
            return composers == null
                ? new ErrorDataResult<List<Composer>>(ComposerConstants.DataNotGet)
                : new SuccessDataResult<List<Composer>>(composers, ComposerConstants.DataGet);
        }

        public IDataResult<List<Composer>> GetAllBySurname(string surname)
        {
            List<Composer> composers = _composerDal.GetAll(c => c.SurName.Contains(surname) && !c.IsDeleted).ToList();
            return composers == null
               ? new ErrorDataResult<List<Composer>>(ComposerConstants.DataNotGet)
               : new SuccessDataResult<List<Composer>>(composers, ComposerConstants.DataGet);
        }

        public IDataResult<List<Composer>> GetAllByNamePreAttachment(string namePreAttachment)
        {
            return new SuccessDataResult<List<Composer>>(_composerDal.GetAll(c => c.NamePreAttachment.Contains(namePreAttachment)
            && !c.IsDeleted).ToList(), ComposerConstants.DataGet);
        }

        public IDataResult<List<Composer>> GetAll()
        {
            return new SuccessDataResult<List<Composer>>(_composerDal.GetAll(c => !c.IsDeleted).ToList(), ComposerConstants.DataGet);
        }

        public IDataResult<List<Composer>> GetAllBySecret()
        {
            return new SuccessDataResult<List<Composer>>(_composerDal.GetAll(c => c.IsDeleted).ToList(), ComposerConstants.DataGet);
        }

        private IResult ComposerNameOrSurnameExist(Composer entity)
        {
            bool result = _composerDal.GetAll(c => c.Name.Equals(entity.Name)
            && c.SurName.ToUpperInvariant().Equals(entity.SurName.ToUpperInvariant())
            && c.NamePreAttachment.Equals(null)
            && entity.NamePreAttachment != null).Any();
            return result
                ? new ErrorResult(ComposerConstants.NameOrSurnameExists)
                : new SuccessResult(ComposerConstants.DataGet);
        }
    }
}