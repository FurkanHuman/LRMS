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
                return new ErrorResult(GraphicDesignConstants.NotMatch);


            _directorDal.Delete(director);
            return new SuccessResult(DirectorConstants.DeleteSuccess);
        }

        public IResult ShadowDelete(Guid id)
        {
            Director director = _directorDal.Get(g => g.Id == id && !g.IsDeleted);
            if (director == null)
                return new ErrorResult(GraphicDesignConstants.NotMatch);

            director.IsDeleted = true;
            _directorDal.Update(director);
            return new SuccessResult(GraphicDesignConstants.ShadowDeleteSuccess);
        }

        [ValidationAspect(typeof(DirectorValidator), Priority = 1)]
        public IResult Update(Director entity)
        {
            _directorDal.Update(entity);
            return new SuccessResult(EditorConstants.UpdateSuccess);
        }

        public IDataResult<List<Director>> GetByFilterList(Expression<Func<Director, bool>>? filter = null)
        {
            return new SuccessDataResult<List<Director>>(_directorDal.GetAll(filter).ToList(), DirectorConstants.DataGet);
        }

        public IDataResult<Director> GetById(Guid id)
        {
            Director director = _directorDal.Get(i => i.Id == id);
            return director == null ?
                new ErrorDataResult<Director>(DirectorConstants.DataNotGet) :
                new SuccessDataResult<Director>(director, DirectorConstants.DataGet);
        }

        public IDataResult<List<Director>> GetByNames(string name)
        {
            List<Director> directors = _directorDal.GetAll(i => i.Name.Equals(name.ToLowerInvariant().Contains(name.ToLowerInvariant())) && !i.IsDeleted).ToList();
            return directors == null ?
                new ErrorDataResult<List<Director>>(DirectorConstants.DataNotGet) :
                new SuccessDataResult<List<Director>>(directors, DirectorConstants.DataGet);
        }

        public IDataResult<List<Director>> GetBySurnames(string surname)
        {
            List<Director> directors = _directorDal.GetAll(i => i.SurName.Equals(surname.ToLowerInvariant().Contains(surname.ToLowerInvariant())) && !i.IsDeleted).ToList();
            return directors == null ?
                new ErrorDataResult<List<Director>>(DirectorConstants.DataNotGet) :
                new SuccessDataResult<List<Director>>(directors, DirectorConstants.DataGet);
        }

        public IDataResult<List<Director>> GetByFilterLists(Expression<Func<Director, bool>>? filter = null)
        {
            return new SuccessDataResult<List<Director>>(_directorDal.GetAll(filter).ToList(), DirectorConstants.DataGet);
        }

        public IDataResult<List<Director>> GetAllBySecrets()
        {
            return new SuccessDataResult<List<Director>>(_directorDal.GetAll(n => n.IsDeleted).ToList(), DirectorConstants.DataGet);
        }

        public IDataResult<List<Director>> GetAll()
        {
            return new SuccessDataResult<List<Director>>(_directorDal.GetAll(n => !n.IsDeleted).ToList(), DirectorConstants.DataGet);
        }

        private IResult DirectorNameOrSurnameExist(Director entity)
        {
            bool result = _directorDal.GetAll(w => w.Name.ToUpperInvariant().Equals(entity.Name.ToUpperInvariant())
            && w.SurName.ToUpperInvariant().Equals(entity.SurName.ToUpperInvariant())).Any();
            return result
                ? new ErrorResult(DirectorConstants.NameOrSurnameExists)
                : new SuccessResult(DirectorConstants.DataGet);
        }
    }
}
