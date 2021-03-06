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
    public class LanguageManager : ILanguageService
    {
        private readonly ILanguageDal _languageDal;

        public LanguageManager(ILanguageDal languageDal)
        {
            _languageDal = languageDal;
        }

        [ValidationAspect(typeof(LanguageValidator), Priority = 1)]
        public IResult Add(Language language)
        {
            IResult result = BusinessRules.Run(CheckLanguageByExists(language));
            if (result != null)
                return result;

            _languageDal.Add(language);
            return new SuccessResult(LanguageConstants.AddSuccess);
        }

        public IResult Delete(int id)
        {
            Language language = _languageDal.Get(l => l.Id == id);
            if (language == null)
                return new SuccessResult(LanguageConstants.DataNotGet);

            _languageDal.Delete(language);
            return new SuccessResult(LanguageConstants.DeleteSuccess);
        }

        public IResult ShadowDelete(int id)
        {
            Language language = _languageDal.Get(l => l.Id == id && !l.IsDeleted);
            if (language == null)
                return new SuccessResult(LanguageConstants.DataNotGet);

            language.IsDeleted = true;
            _languageDal.Update(language);
            return new SuccessResult(LanguageConstants.DeleteSuccess);
        }

        [ValidationAspect(typeof(LanguageValidator), Priority = 1)]
        public IResult Update(Language language)
        {
            _languageDal.Update(language);
            return new SuccessResult(LanguageConstants.UpdateSuccess);
        }

        public IDataResult<Language> GetById(int id)
        {
            Language language = _languageDal.Get(l => l.Id == id);

            return language == null
                ? new ErrorDataResult<Language>(LanguageConstants.DataNotGet)
                : new SuccessDataResult<Language>(language, LanguageConstants.DataGet);
        }

        public IDataResult<List<Language>> GetAllByIds(int[] ids)
        {
            List<Language> languages = _languageDal.GetAll(l => ids.Contains(l.Id) && !l.IsDeleted).ToList();
            return languages == null
                ? new ErrorDataResult<List<Language>>(LanguageConstants.DataNotGet)
                : new SuccessDataResult<List<Language>>(languages, LanguageConstants.DataGet);
        }

        public IDataResult<List<Language>> GetAllByName(string name)
        {
            List<Language> languages = _languageDal.GetAll(l => l.LanguageName.Contains(name) && !l.IsDeleted).ToList();
            return languages == null
                ? new ErrorDataResult<List<Language>>(LanguageConstants.DataNotGet)
                : new SuccessDataResult<List<Language>>(languages, LanguageConstants.DataGet);
        }

        public IDataResult<List<Language>> GetAllByFilter(Expression<Func<Language, bool>>? filter = null)
        {
            return new SuccessDataResult<List<Language>>(_languageDal.GetAll(filter).ToList<Language>(), LanguageConstants.DataGet);
        }

        public IDataResult<List<Language>> GetAllBySecret()
        {
            return new SuccessDataResult<List<Language>>(_languageDal.GetAll(l => l.IsDeleted).ToList<Language>(), LanguageConstants.DataGet);
        }

        public IDataResult<List<Language>> GetAll()
        {
            return new SuccessDataResult<List<Language>>(_languageDal.GetAll(l => !l.IsDeleted).ToList<Language>(), LanguageConstants.DataGet);
        }

        private IResult CheckLanguageByExists(Language language)
        {
            Language languageExist = _languageDal.Get(l => l.LanguageName.Contains(language.LanguageName));
            return languageExist == null
                ? new SuccessResult()
                : new ErrorResult(LanguageConstants.LanguageExist);
        }
    }
}
