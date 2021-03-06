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

        public IResult Delete(Guid id)
        {
            Interpreters interpreters = _interpretersDal.Get(p => p.Id == id);
            if (interpreters == null)
                return new SuccessResult(InterpretersConstants.DataNotGet);

            _interpretersDal.Delete(interpreters);
            return new SuccessResult(InterpretersConstants.DeleteSuccess);
        }

        public IResult ShadowDelete(Guid id)
        {
            Interpreters interpreters = _interpretersDal.Get(i => i.Id == id && !i.IsDeleted);
            if (interpreters == null)
                return new ErrorResult(InterpretersConstants.NotMatch);

            interpreters.IsDeleted = true;
            _interpretersDal.Update(interpreters);
            return new SuccessResult(InterpretersConstants.DataGet);
        }

        [ValidationAspect(typeof(InterpretersValidator), Priority = 1)]
        public IResult Update(Interpreters entity)
        {
            _interpretersDal.Update(entity);
            return new SuccessResult(InterpretersConstants.UpdateSuccess);
        }

        public IDataResult<Interpreters> GetById(Guid id)
        {
            Interpreters interpreters = _interpretersDal.Get(i => i.Id == id);
            return interpreters == null
                ? new ErrorDataResult<Interpreters>(InterpretersConstants.DataNotGet)
                : new SuccessDataResult<Interpreters>(interpreters, InterpretersConstants.DataGet);
        }

        public IDataResult<List<Interpreters>> GetAllByIds(Guid[] ids)
        {
            List<Interpreters> interpreters = _interpretersDal.GetAll(n => ids.Contains(n.Id) && !n.IsDeleted).ToList();
            return interpreters == null
                ? new ErrorDataResult<List<Interpreters>>(InterpretersConstants.DataNotGet)
                : new SuccessDataResult<List<Interpreters>>(interpreters, InterpretersConstants.DataGet);
        }

        public IDataResult<List<Interpreters>> GetAllByName(string name)
        {
            List<Interpreters> interpreters = _interpretersDal.GetAll(n => n.Name.Contains(name) && !n.IsDeleted).ToList();
            return interpreters == null
                ? new ErrorDataResult<List<Interpreters>>(InterpretersConstants.DataNotGet)
                : new SuccessDataResult<List<Interpreters>>(interpreters, InterpretersConstants.DataGet);
        }

        public IDataResult<List<Interpreters>> GetAllBySurname(string surname)
        {
            List<Interpreters> interpreters = _interpretersDal.GetAll(n => n.SurName.Contains(surname) && !n.IsDeleted).ToList();
            return interpreters == null
                ? new ErrorDataResult<List<Interpreters>>(InterpretersConstants.DataNotGet)
                : new SuccessDataResult<List<Interpreters>>(interpreters, InterpretersConstants.DataGet);
        }

        public IDataResult<List<Interpreters>> GetAllByWhichToLanguage(string langName)
        {
            List<Interpreters> interpreterss = _interpretersDal.GetAll(l => l.WhichToLanguage.Contains(langName, StringComparison.CurrentCultureIgnoreCase) && !l.IsDeleted).ToList();
            return interpreterss == null
            ? new ErrorDataResult<List<Interpreters>>(InterpretersConstants.DataNotGet)
            : new SuccessDataResult<List<Interpreters>>(interpreterss, InterpretersConstants.DataGet);
        }

        public IDataResult<List<Interpreters>> GetAllByFilter(Expression<Func<Interpreters, bool>>? filter = null)
        {
            return new SuccessDataResult<List<Interpreters>>(_interpretersDal.GetAll(filter).ToList(), InterpretersConstants.DataGet);
        }

        public IDataResult<List<Interpreters>> GetAllBySecret()
        {
            return new SuccessDataResult<List<Interpreters>>(_interpretersDal.GetAll(i => i.IsDeleted).ToList(), InterpretersConstants.DataGet);
        }

        public IDataResult<List<Interpreters>> GetAll()
        {
            return new SuccessDataResult<List<Interpreters>>(_interpretersDal.GetAll(i => i.IsDeleted).ToList(), InterpretersConstants.DataGet);
        }

        private IResult InterpretersNameOrSurnameExist(Interpreters entity)
        {
            bool result = _interpretersDal.GetAll(w => w.Name.Equals(entity.Name)
            && w.SurName.Equals(entity.SurName)).Any();
            return result
                ? new ErrorResult(InterpretersConstants.NameOrSurnameExists)
                : new SuccessResult(InterpretersConstants.DataGet);
        }
    }
}
