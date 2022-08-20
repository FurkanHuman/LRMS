namespace Business.Concrete
{
    public class CountryManager : ICountryService
    {
        private readonly ICountryDal _countryDal;

        public CountryManager(ICountryDal countryDal)
        {
            _countryDal = countryDal;
        }

        [ValidationAspect(typeof(CountryValidator), Priority = 1)]
        public IResult Add(Country country)
        {
            IResult result = BusinessRules.Run(CountryControl(country));
            if (result != null)
                return result;

            country.IsDeleted = false;
            _countryDal.Add(country);
            return new SuccessResult(CountryConstants.AddSuccess);
        }

        public IResult Delete(int id)
        {
            Country country = _countryDal.Get(c => c.Id == id);
            if (country == null)
                return new ErrorResult(CountryConstants.NotMatch);

            _countryDal.Delete(country);
            return new SuccessResult(CountryConstants.DeleteSuccess);
        }

        public IResult ShadowDelete(int id)
        {
            Country country = _countryDal.Get(c => c.Id.Equals(id) && !c.IsDeleted);
            if (country == null)
                return new ErrorResult(CountryConstants.NotMatch);

            country.IsDeleted = true;
            _countryDal.Update(country);
            return new SuccessResult(CountryConstants.ShadowDeleteSuccess);
        }

        [ValidationAspect(typeof(CountryValidator), Priority = 1)]
        public IResult Update(Country country)
        {
            IResult result = BusinessRules.Run(CountryControl(country));
            if (result != null)
                return result;

            _countryDal.Update(country);

            return new SuccessResult(CountryConstants.UpdateSuccess);
        }

        [ValidationAspect(typeof(CountryValidator), Priority = 1)]
        public IResult DtoUpdate(CountryDto entity)
        {
            return Update(new()
            {
                Id = entity.Id,
                CountryName = entity.CountryName,
                CountryCode = entity.CountryCode
            });
        }

        public IDataResult<Country> GetById(int id)
        {
            Country country = _countryDal.Get(c => c.Id == id);
            return country == null
                ? new ErrorDataResult<Country>(CountryConstants.DataNotGet)
                : new SuccessDataResult<Country>(country, CountryConstants.DataGet);
        }

        public IDataResult<CountryDto> DtoGetById(int id)
        {
            CountryDto countryDto = _countryDal.DtoGet(c => c.Id == id);
            return countryDto == null
                ? new ErrorDataResult<CountryDto>(CountryConstants.DataNotGet)
                : new SuccessDataResult<CountryDto>(countryDto, CountryConstants.DataGet);
        }

        public IDataResult<IList<Country>> GetAllByIds(int[] ids)
        {
            IList<Country> countries = _countryDal.GetAll(c => ids.Contains(c.Id));

            return countries == null
                ? new ErrorDataResult<IList<Country>>(CountryConstants.NotMatch)
                : new SuccessDataResult<IList<Country>>(countries, CountryConstants.NotMatch);
        }

        public IDataResult<IList<CountryDto>> DtoGetAllByIds(int[] ids)
        {
            IList<CountryDto> countryDtos = _countryDal.DtoGetAll(c => ids.Contains(c.Id) && !c.IsDeleted);
            return countryDtos == null
                ? new ErrorDataResult<IList<CountryDto>>(CountryConstants.DataNotGet)
                : new SuccessDataResult<IList<CountryDto>>(countryDtos, CountryConstants.DataGet);
        }

        public IDataResult<IList<Country>> GetAllByName(string name)
        {
            IList<Country> countries = _countryDal.GetAll(c => c.CountryName.Contains(name));

            return countries == null
                ? new ErrorDataResult<IList<Country>>(CountryConstants.NotMatch)
                : new SuccessDataResult<IList<Country>>(countries, CountryConstants.NotMatch);
        }

        public IDataResult<IList<CountryDto>> DtoGetAllByName(string name)
        {
            IList<CountryDto> countryDtos = _countryDal.DtoGetAll(c => c.CountryName.Contains(name) && !c.IsDeleted);
            return countryDtos == null
                ? new ErrorDataResult<IList<CountryDto>>(CountryConstants.DataNotGet)
                : new SuccessDataResult<IList<CountryDto>>(countryDtos, CountryConstants.DataGet);
        }

        public IDataResult<IList<Country>> GetAllByCountryCode(string countryCode)
        {
            IList<Country> countries = _countryDal.GetAll(c => c.CountryCode.Contains(countryCode));
            return countries == null
                ? new ErrorDataResult<IList<Country>>(CountryConstants.CountryNotFound)
                : new SuccessDataResult<IList<Country>>(countries, CountryConstants.DataGet);
        }
        public IDataResult<IList<CountryDto>> DtoGetAllByCountryCode(string countryCode)
        {
            IList<CountryDto> countryDtos = _countryDal.DtoGetAll(c => c.CountryCode.Contains(countryCode) && !c.IsDeleted);
            return countryDtos == null
                ? new ErrorDataResult<IList<CountryDto>>(CountryConstants.DataNotGet)
                : new SuccessDataResult<IList<CountryDto>>(countryDtos, CountryConstants.DataGet);
        }
        public IDataResult<IList<Country>> GetAllByFilter(Expression<Func<Country, bool>>? filter = null)
        {
            return new SuccessDataResult<IList<Country>>(_countryDal.GetAll(filter), CountryConstants.DataGet);
        }

        public IDataResult<IList<CountryDto>> DtoGetAllByFilter(Expression<Func<Country, bool>>? filter = null)
        {
            return new SuccessDataResult<IList<CountryDto>>(_countryDal.DtoGetAll(filter), CountryConstants.DataGet);
        }

        public IDataResult<IList<Country>> GetAllByIsDeleted()
        {
            return new SuccessDataResult<IList<Country>>(_countryDal.GetAll(C => C.IsDeleted), CountryConstants.DataGet);
        }

        public IDataResult<IList<CountryDto>> DtoGetAllByIsDeleted()
        {
            return new SuccessDataResult<IList<CountryDto>>(_countryDal.DtoGetAll(C => C.IsDeleted), CountryConstants.DataGet);
        }

        public IDataResult<IList<Country>> GetAll()
        {
            return new SuccessDataResult<IList<Country>>(_countryDal.GetAll(C => !C.IsDeleted), CountryConstants.DataGet);
        }

        public IDataResult<IList<CountryDto>> DtoGetAll()
        {
            return new SuccessDataResult<IList<CountryDto>>(_countryDal.DtoGetAll(C => !C.IsDeleted), CountryConstants.DataGet);
        }

        private IResult CountryControl(Country country)
        {
            //    int? countryNameId = _countryDal.Get(c => c.CountryName.Contains(country.CountryName) && !c.IsDeleted).Id;
            //    int? countryCodeId = _countryDal.Get(c => c.CountryCode.Contains(country.CountryCode) && !c.IsDeleted).Id;

            //    if (countryCodeId != countryNameId)
            //        return new ErrorResult(CountryConstants.CountryNameAndCodeNotMatch);

            return new SuccessResult();
        }
    }
}
