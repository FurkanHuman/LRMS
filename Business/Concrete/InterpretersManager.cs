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
    public class InterpretersManager : IInterpretersService
    {
        private readonly IInterpretersDal _interpretersDal;

        public InterpretersManager(IInterpretersDal interpretersDal)
        {
            _interpretersDal = interpretersDal;
        }


        [ValidationAspect(typeof(InterpretersValidator), Priority = 1)]
        public IResult Add(Interpreters entity)
        {
            IResult result = BusinessRules.Run(InterpretersNameOrSurnameExist(entity));
            if (result != null)
                return result;

            entity.IsDeleted = false;
            _interpretersDal.Add(entity);
            return new SuccessResult(InterpretersConstants.AddSuccess);
        }

        public IResult Delete(Interpreters entity)
        {
            _interpretersDal.Delete(entity);
            return new SuccessResult(InterpretersConstants.DeleteSuccess);
        }

        public IResult Update(Interpreters entity)
        {
            _interpretersDal.Update(entity);
            return new SuccessResult(InterpretersConstants.UpdateSuccess);
        }

        public IDataResult<Interpreters> GetById(int id)
        {
            return new SuccessDataResult<Interpreters>(_interpretersDal.Get(i => i.Id == id && !i.IsDeleted), InterpretersConstants.DataGet);
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

        private IResult InterpretersNameOrSurnameExist(Interpreters entity)
        {
            bool result = _interpretersDal.GetAll(w => w.Name.ToUpperInvariant().Equals(entity.Name.ToUpperInvariant())
            && w.SurName.ToUpperInvariant().Equals(entity.SurName.ToUpperInvariant())).Any();
            return result
                ? new ErrorResult(InterpretersConstants.NameOrSurnameExists)
                : new SuccessResult(InterpretersConstants.DataGet);
        }
    }
}
