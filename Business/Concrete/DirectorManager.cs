﻿namespace Business.Concrete
{
    public class DirectorManager : IDirectorService
    {
        private readonly IDirectorDal _directorDal;

        public DirectorManager(IDirectorDal directorDal)
        {
            _directorDal = directorDal;
        }

        [ValidationAspect(typeof(DirectorValidator), Priority = 1)]
        public IResult Add(Director entity)
        {
            IResult result = BusinessRules.Run(DirectorNameOrSurnameExist(entity));
            if (result != null)
                return result;

            entity.IsDeleted = false;
            _directorDal.Add(entity);
            return new SuccessResult(DirectorConstants.AddSuccess);
        }

        public IResult Delete(Guid id)
        {
            Director director = _directorDal.Get(g => g.Id == id);
            if (director == null)
                return new ErrorResult(DirectorConstants.NotMatch);


            _directorDal.Delete(director);
            return new SuccessResult(DirectorConstants.DeleteSuccess);
        }

        public IResult ShadowDelete(Guid id)
        {
            Director director = _directorDal.Get(g => g.Id == id && !g.IsDeleted);
            if (director == null)
                return new ErrorResult(DirectorConstants.NotMatch);

            director.IsDeleted = true;
            _directorDal.Update(director);
            return new SuccessResult(DirectorConstants.ShadowDeleteSuccess);
        }

        [ValidationAspect(typeof(DirectorValidator), Priority = 1)]
        public IResult Update(Director entity)
        {
            _directorDal.Update(entity);
            return new SuccessResult(DirectorConstants.UpdateSuccess);
        }

        public IDataResult<IList<Director>> GetByFilterIList(Expression<Func<Director, bool>>? filter = null)
        {
            return new SuccessDataResult<IList<Director>>(_directorDal.GetAll(filter), DirectorConstants.DataGet);
        }

        public IDataResult<Director> GetById(Guid id)
        {
            Director director = _directorDal.Get(i => i.Id == id);
            return director == null ?
                new ErrorDataResult<Director>(DirectorConstants.DataNotGet) :
                new SuccessDataResult<Director>(director, DirectorConstants.DataGet);
        }

        public IDataResult<IList<Director>> GetAllByIds(Guid[] ids)
        {
            IList<Director> directors = _directorDal.GetAll(i => ids.Contains(i.Id) && !i.IsDeleted);
            return directors == null ?
                new ErrorDataResult<IList<Director>>(DirectorConstants.DataNotGet) :
                new SuccessDataResult<IList<Director>>(directors, DirectorConstants.DataGet);
        }

        public IDataResult<IList<Director>> GetAllByName(string name)
        {
            IList<Director> directors = _directorDal.GetAll(i => i.Name.Equals(name.Contains(name)) && !i.IsDeleted);
            return directors == null ?
                new ErrorDataResult<IList<Director>>(DirectorConstants.DataNotGet) :
                new SuccessDataResult<IList<Director>>(directors, DirectorConstants.DataGet);
        }

        public IDataResult<IList<Director>> GetAllBySurname(string surname)
        {
            IList<Director> directors = _directorDal.GetAll(i => i.SurName.Equals(surname.Contains(surname)) && !i.IsDeleted);
            return directors == null ?
                new ErrorDataResult<IList<Director>>(DirectorConstants.DataNotGet) :
                new SuccessDataResult<IList<Director>>(directors, DirectorConstants.DataGet);
        }

        public IDataResult<IList<Director>> GetAllByFilter(Expression<Func<Director, bool>>? filter = null)
        {
            return new SuccessDataResult<IList<Director>>(_directorDal.GetAll(filter), DirectorConstants.DataGet);
        }

        public IDataResult<IList<Director>> GetAllByIsDeleted()
        {
            return new SuccessDataResult<IList<Director>>(_directorDal.GetAll(n => n.IsDeleted), DirectorConstants.DataGet);
        }

        public IDataResult<IList<Director>> GetAll()
        {
            return new SuccessDataResult<IList<Director>>(_directorDal.GetAll(n => !n.IsDeleted), DirectorConstants.DataGet);
        }

        private IResult DirectorNameOrSurnameExist(Director entity)
        {
            bool result = _directorDal.GetAll(w => w.Name.Equals(entity.Name)
            && w.SurName.Equals(entity.SurName)).Any();
            return result
                ? new ErrorResult(DirectorConstants.NameOrSurnameExists)
                : new SuccessResult(DirectorConstants.DataGet);
        }
    }
}
