using Business.Abstract;
using Business.Constants;
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
        private static int namelength = 3;
        private static int surnameNamelength = 2;

        public DirectorManager(IDirectorDal directorDal)
        {
            _directorDal = directorDal;
        }

        public IResult Add(Director entity)
        {
            IResult result = BusinessRules.Run(DirectorControl(entity));
            if (result != null)
                return result;

            entity.IsDeleted = false;
            _directorDal.Add(entity);
            return new SuccessResult(DirectorConstants.AddSucces);
        }

        public IResult Delete(Director entity)
        {
            IResult result = BusinessRules.Run(DirectorControl(entity));
            if (result != null)
                return result;

            entity.IsDeleted = true;
            _directorDal.Update(entity);
            return new SuccessResult(EditorConstants.EfDeletedSuccsess);
        }

        public IResult Update(Director entity)
        {
            IResult result = BusinessRules.Run(DirectorControl(entity), UpdateControl(entity));
            if (result != null)
                return result;

            _directorDal.Update(entity);
            return new SuccessResult(EditorConstants.EfDeletedSuccsess);
        }

        public IDataResult<List<Director>> GetByFilterList(Expression<Func<Director, bool>>? filter = null)
        {
            return new SuccessDataResult<List<Director>>(_directorDal.GetAll(filter).ToList());
        }

        public IDataResult<Director> GetById(int id)
        {
            Director director = _directorDal.Get(i => i.Id == id && !i.IsDeleted);
            return director == null ?
                new ErrorDataResult<Director>(DirectorConstants.DataNotGet) :
                new SuccessDataResult<Director>(director);
        }

        public IDataResult<Director> GetByName(string name)
        {
            Director director = _directorDal.Get(i => i.Name.Equals(name.ToLower().Contains(name.ToLower())) && !i.IsDeleted);
            return director == null ?
                new ErrorDataResult<Director>(DirectorConstants.DataNotGet) :
                new SuccessDataResult<Director>(director);
        }

        public IDataResult<Director> GetBySurname(string surname)
        {
            Director director = _directorDal.Get(i => i.SurName.Equals(surname.ToLower().Contains(surname.ToLower())) && !i.IsDeleted);
            return director == null ?
                new ErrorDataResult<Director>(DirectorConstants.DataNotGet) :
                new SuccessDataResult<Director>(director);
        }

        public IDataResult<List<Director>> GetList()
        {
            return new SuccessDataResult<List<Director>>(_directorDal.GetAll(n => !n.IsDeleted).ToList(), DirectorConstants.DataGet);
        }

        private static IResult DirectorControl(Director entity)
        {
            if (entity == null)
                return new ErrorResult(DirectorConstants.DirectorNull);
            if (entity.Name.Equals(null) || entity.Name.Equals(string.Empty) || entity.Name.Length >= namelength)
                return new ErrorResult(DirectorConstants.DirectorNameLengthNotEnough);
            if (entity.SurName.Equals(null) || entity.SurName.Equals(string.Empty) || entity.SurName.Length >= surnameNamelength)
                return new ErrorResult(DirectorConstants.DirectorNameLengthNotEnough);

            return new SuccessResult();
        }

        private IResult UpdateControl(Director entity)
        {
            Director updateDirector = _directorDal.Get(i => i == entity);

            if (updateDirector == null)
                return new ErrorResult(EditorConstants.EditorNull);
            if (entity.Name.Equals(updateDirector.Name) || entity.SurName.Equals(updateDirector.SurName)
                || entity.Name.Length >= namelength && entity.SurName.Length >= surnameNamelength)
                return new ErrorResult(EditorConstants.EditorEquals);

            return new SuccessResult();
        }
    }
}
