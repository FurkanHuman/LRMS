using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Result.Abstract;
using Core.Utilities.Result.Concrete;
using DataAccess.Abstract;
using Entities.Concrete.Infos;

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

        public IResult Delete(Language language)
        {
            _languageDal.Delete(language);
            return new SuccessResult(LanguageConstants.DeleteSuccess);
        }

        public IResult Update(Language language)
        {
            _languageDal.Update(language);
            return new SuccessResult(LanguageConstants.UpdateSuccess);
        }

        public IDataResult<List<Language>> Getlist()
        {
            return new SuccessDataResult<List<Language>>(_languageDal.GetAll().ToList<Language>(), LanguageConstants.DataGet);
        }

        public IDataResult<Language> GetById(int id)
        {
            Language language = _languageDal.Get(l => l.Id == id && !l.IsDeleted);

            return language == null
                ? new ErrorDataResult<Language>(LanguageConstants.DataNotGet)
                : new SuccessDataResult<Language>(language, LanguageConstants.DataGet);
        }

        public IDataResult<Language> GetByLanguageName(string languageName)
        {
            Language language = _languageDal.Get(l => l.LanguageName.ToLowerInvariant().Equals(languageName.ToLowerInvariant()) && !l.IsDeleted);
            return language == null
                ? new ErrorDataResult<Language>(LanguageConstants.DataNotGet)
                : new SuccessDataResult<Language>(language, LanguageConstants.DataGet);
        }

        private IResult CheckLanguageByExists(Language language)
        {
            Language languageExist = _languageDal.Get(l => l.LanguageName.ToLowerInvariant().Contains(language.LanguageName.ToLowerInvariant()));
            return languageExist == null
                ? new SuccessResult()
                : new ErrorResult(LanguageConstants.LanguageExist);
        }
    }
}
