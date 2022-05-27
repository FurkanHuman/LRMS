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

        public IResult ShadowDelete(Guid guid)
        {
            Interpreters interpreters = _interpretersDal.Get(i => i.Id == guid && !i.IsDeleted);
            if (interpreters == null)
                return new ErrorResult(InterpretersConstants.NotMatch);

            interpreters.IsDeleted = true;
            _interpretersDal.Update(interpreters);
            return new SuccessResult(InterpretersConstants.DataGet);
        }

        public IResult Update(Interpreters entity)
        {
            _interpretersDal.Update(entity);
            return new SuccessResult(InterpretersConstants.UpdateSuccess);
        }

        public IDataResult<Interpreters> GetById(Guid guid)
        {
            return new SuccessDataResult<Interpreters>(_interpretersDal.Get(i => i.Id == guid && !i.IsDeleted), InterpretersConstants.DataGet);
        }

        public IDataResult<List<Interpreters>> GetByNames(string name)
        {
            List<Interpreters> interpreters = _interpretersDal.GetAll(n => n.Name.ToLower().Contains(name.ToLower()) && !n.IsDeleted).ToList();
            return interpreters == null
                ? new ErrorDataResult<List<Interpreters>>(InterpretersConstants.DataNotGet)
                : new SuccessDataResult<List<Interpreters>>(interpreters, InterpretersConstants.DataGet);
        }

        public IDataResult<List<Interpreters>> GetBySurnames(string surname)
        {
            List<Interpreters> interpreters = _interpretersDal.GetAll(n => n.SurName.ToLower().Contains(surname.ToLower()) && !n.IsDeleted).ToList();
            return interpreters == null
                ? new ErrorDataResult<List<Interpreters>>(InterpretersConstants.DataNotGet)
                : new SuccessDataResult<List<Interpreters>>(interpreters, InterpretersConstants.DataGet);
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
