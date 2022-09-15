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

        public IDataResult<IList<Language>> GetAllByIds(int[] ids)
        {
            IList<Language> languages = _languageDal.GetAll(l => ids.Contains(l.Id) && !l.IsDeleted);
            return languages == null
                ? new ErrorDataResult<IList<Language>>(LanguageConstants.DataNotGet)
                : new SuccessDataResult<IList<Language>>(languages, LanguageConstants.DataGet);
        }

        public IDataResult<IList<Language>> GetAllByName(string name)
        {
            IList<Language> languages = _languageDal.GetAll(l => l.Name.Contains(name) && !l.IsDeleted);
            return languages == null
                ? new ErrorDataResult<IList<Language>>(LanguageConstants.DataNotGet)
                : new SuccessDataResult<IList<Language>>(languages, LanguageConstants.DataGet);
        }

        public IDataResult<IList<Language>> GetAllByFilter(Expression<Func<Language, bool>>? filter = null)
        {
            return new SuccessDataResult<IList<Language>>(_languageDal.GetAll(filter), LanguageConstants.DataGet);
        }

        public IDataResult<IList<Language>> GetAllByIsDeleted()
        {
            return new SuccessDataResult<IList<Language>>(_languageDal.GetAll(l => l.IsDeleted), LanguageConstants.DataGet);
        }

        public IDataResult<IList<Language>> GetAll()
        {
            return new SuccessDataResult<IList<Language>>(_languageDal.GetAll(l => !l.IsDeleted), LanguageConstants.DataGet);
        }

        private IResult CheckLanguageByExists(Language language)
        {
            Language languageExist = _languageDal.Get(l => l.Name.Contains(language.Name));
            return languageExist == null
                ? new SuccessResult()
                : new ErrorResult(LanguageConstants.LanguageExist);
        }
    }
}
