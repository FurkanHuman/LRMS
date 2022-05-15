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

        public IResult Delete(Director entity)
        {
            _directorDal.Delete(entity);
            return new SuccessResult(DirectorConstants.DeleteSuccess);
        }

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
            Director director = _directorDal.Get(i => i.Id == id && !i.IsDeleted);
            return director == null ?
                new ErrorDataResult<Director>(DirectorConstants.DataNotGet) :
                new SuccessDataResult<Director>(director, DirectorConstants.DataGet);
        }

        public IDataResult<Director> GetByName(string name)
        {
            Director director = _directorDal.Get(i => i.Name.Equals(name.ToLowerInvariant().Contains(name.ToLowerInvariant())) && !i.IsDeleted);
            return director == null ?
                new ErrorDataResult<Director>(DirectorConstants.DataNotGet) :
                new SuccessDataResult<Director>(director, DirectorConstants.DataGet);
        }

        public IDataResult<Director> GetBySurname(string surname)
        {
            Director director = _directorDal.Get(i => i.SurName.Equals(surname.ToLowerInvariant().Contains(surname.ToLowerInvariant())) && !i.IsDeleted);
            return director == null ?
                new ErrorDataResult<Director>(DirectorConstants.DataNotGet) :
                new SuccessDataResult<Director>(director, DirectorConstants.DataGet);
        }

        public IDataResult<List<Director>> GetList()
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
