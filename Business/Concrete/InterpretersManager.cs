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
    public class InterpretersManager : IInterpretersService
    {
        private readonly IInterpretersDal _interpretersDal;

        private static int namelength = 3;
        private static int surnameNamelength = 2;

        public InterpretersManager(IInterpretersDal interpretersDal)
        {
            _interpretersDal = interpretersDal;
        }

        public IResult Add(Interpreters entity)
        {
            IResult result = BusinessRules.Run(InterpretersControl(entity));
            if (result != null)
                return result;
            _interpretersDal.Add(entity);
            return new SuccessResult(InterpretersConstants.AddSucces);
        }

        public IResult Delete(Interpreters entity)
        {
            IResult result = BusinessRules.Run(InterpretersControl(entity));
            if (result != null)
                return result;
            entity.IsDeleted = true;
            _interpretersDal.Update(entity);
            return new SuccessResult(InterpretersConstants.AddSucces);
        }

        public IResult Update(Interpreters entity)
        {
            IResult result = BusinessRules.Run(InterpretersControl(entity), UpdateControl(entity));
            if (result != null)
                return result;
            _interpretersDal.Update(entity);
            return new SuccessResult(InterpretersConstants.AddSucces);
        }

        public IDataResult<Interpreters> GetById(int id)
        {
            return new SuccessDataResult<Interpreters>(_interpretersDal.Get(i => i.Id == id && !i.IsDeleted));
        }

        public IDataResult<Interpreters> GetByName(string name)
        {
            Interpreters Interpreters = _interpretersDal.Get(n => n.Name.ToLower().Contains(name.ToLower()) && !n.IsDeleted);
            return Interpreters == null
                ? new ErrorDataResult<Interpreters>(InterpretersConstants.DataNotGet)
                : new SuccessDataResult<Interpreters>(Interpreters, InterpretersConstants.DataGet);
        }

        public IDataResult<Interpreters> GetBySurname(string surname)
        {
            Interpreters Interpreters = _interpretersDal.Get(n => n.SurName.ToLower().Contains(surname.ToLower()) && !n.IsDeleted);
            return Interpreters == null
                ? new ErrorDataResult<Interpreters>(InterpretersConstants.DataNotGet)
                : new SuccessDataResult<Interpreters>(Interpreters, InterpretersConstants.DataGet);
        }

        public IDataResult<List<Interpreters>> GetByWhichToLanguageList(string LangName)
        {
            List<Interpreters> interpreterss = _interpretersDal.GetAll(l => l.WhichToLanguage.ToLower().Contains(LangName.ToLower()) && !l.IsDeleted).ToList();
            return interpreterss == null
            ? new ErrorDataResult<List<Interpreters>>(InterpretersConstants.DataNotGet)
            : new SuccessDataResult<List<Interpreters>>(interpreterss, InterpretersConstants.DataGet);
        }

        public IDataResult<List<Interpreters>> GetList()
        {
            return new SuccessDataResult<List<Interpreters>>(_interpretersDal.GetAll().ToList(), InterpretersConstants.DataGet);
        }

        public IDataResult<List<Interpreters>> GetByFilterList(Expression<Func<Interpreters, bool>>? filter = null)
        {
            return new SuccessDataResult<List<Interpreters>>(_interpretersDal.GetAll(filter).ToList(), InterpretersConstants.DataGet);
        }
        private static IResult InterpretersControl(Interpreters entity)
        {
            if (entity == null)
                return new ErrorResult(InterpretersConstants.InterpretersNull);
            if (entity.Name.Equals(null) || entity.Name.Equals(string.Empty) || entity.Name.Length >= namelength)
                return new ErrorResult(InterpretersConstants.InterpretersNameLengthNotEnough);
            if (entity.SurName.Equals(null) || entity.SurName.Equals(string.Empty) || entity.SurName.Length >= surnameNamelength)
                return new ErrorResult(InterpretersConstants.InterpretersNameLengthNotEnough);

            return new SuccessResult();
        }

        private IResult UpdateControl(Interpreters entity)
        {
            Interpreters updateInterpreters = _interpretersDal.Get(i => i == entity);

            if (updateInterpreters == null)
                return new ErrorResult(InterpretersConstants.InterpretersNull);
            if (entity.Name.Equals(updateInterpreters.Name) || entity.SurName.Equals(updateInterpreters.SurName)
                || entity.Name.Length >= namelength && entity.SurName.Length >= surnameNamelength)
                return new ErrorResult(InterpretersConstants.InterpretersEquals);

            return new SuccessResult();
        }
    }
}
