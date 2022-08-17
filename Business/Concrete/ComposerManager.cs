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

        public IDataResult<IList<Composer>> GetAllByFilter(Expression<Func<Composer, bool>>? filter = null)
        {
            return new SuccessDataResult<IList<Composer>>(_composerDal.GetAll(filter), ComposerConstants.DataGet);
        }

        public IDataResult<Composer> GetById(Guid id)
        {
            Composer composer = _composerDal.Get(c => c.Id == id);
            return composer == null
                ? new ErrorDataResult<Composer>(ComposerConstants.NotMatch)
                : new SuccessDataResult<Composer>(composer, ComposerConstants.DataGet);
        }

        public IDataResult<IList<Composer>> GetAllByIds(Guid[] ids)
        {
            IList<Composer> composers = _composerDal.GetAll(c => ids.Contains(c.Id) && !c.IsDeleted);
            return composers == null
               ? new ErrorDataResult<IList<Composer>>(ComposerConstants.DataNotGet)
               : new SuccessDataResult<IList<Composer>>(composers, ComposerConstants.DataGet);
        }

        public IDataResult<IList<Composer>> GetAllByName(string name)
        {
            IList<Composer> composers = _composerDal.GetAll(c => c.Name.Contains(name) && !c.IsDeleted);
            return composers == null
                ? new ErrorDataResult<IList<Composer>>(ComposerConstants.DataNotGet)
                : new SuccessDataResult<IList<Composer>>(composers, ComposerConstants.DataGet);
        }

        public IDataResult<IList<Composer>> GetAllBySurname(string surname)
        {
            IList<Composer> composers = _composerDal.GetAll(c => c.SurName.Contains(surname) && !c.IsDeleted);
            return composers == null
               ? new ErrorDataResult<IList<Composer>>(ComposerConstants.DataNotGet)
               : new SuccessDataResult<IList<Composer>>(composers, ComposerConstants.DataGet);
        }

        public IDataResult<IList<Composer>> GetAllByNamePreAttachment(string namePreAttachment)
        {
            return new SuccessDataResult<IList<Composer>>(_composerDal.GetAll(c => c.NamePreAttachment.Contains(namePreAttachment)
            && !c.IsDeleted), ComposerConstants.DataGet);
        }

        public IDataResult<IList<Composer>> GetAll()
        {
            return new SuccessDataResult<IList<Composer>>(_composerDal.GetAll(c => !c.IsDeleted), ComposerConstants.DataGet);
        }

        public IDataResult<IList<Composer>> GetAllByIsDeleted()
        {
            return new SuccessDataResult<IList<Composer>>(_composerDal.GetAll(c => c.IsDeleted), ComposerConstants.DataGet);
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