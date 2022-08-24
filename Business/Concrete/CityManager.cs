namespace Business.Concrete
{
    public class CityManager : ICityService
    {
        private readonly ICityDal _cityDal;
        private readonly ICityFacadeService _cityFacadeService;

        public CityManager(ICityDal cityDal, ICityFacadeService cityFacadeService)
        {
            _cityDal = cityDal;
            _cityFacadeService = cityFacadeService;
        }

        [ValidationAspect(typeof(CityValidator), Priority = 1)]
        public IResult Add(City city)
        {
            IDataResult<Country> country = _cityFacadeService.CountryService().GetById(city.CountryId);

            IResult result = BusinessRules.Run(CheckCityByExists(city.CityName), country);
            if (result != null)
                return result;

            city.Country = country.Data;
            city.IsDeleted = false;
            _cityDal.Add(city);
            return new SuccessResult(CityConstants.AddSuccess);
        }

        [ValidationAspect(typeof(CityValidator), Priority = 1)]
        public IDataResult<CityAddDto> DtoAdd(CityAddDto addDto)
        {
            City city = new MapperConfiguration(cfg => cfg.CreateMap<CityAddDto, City>()).CreateMapper().Map<City>(addDto);

            IDataResult<Country> country = _cityFacadeService.CountryService().GetById(city.CountryId);

            IResult result = BusinessRules.Run(CheckCityByExists(city.CityName), country);
            if (result != null)
                return new ErrorDataResult<CityAddDto>(result.Message);

            city.Country = country.Data;
            city.IsDeleted = false;

            City returnCity = _cityDal.Add(city);
            return returnCity != null
                ? new SuccessDataResult<CityAddDto>(addDto, CityConstants.AddSuccess)
                : new ErrorDataResult<CityAddDto>(addDto, CityConstants.AddFailed);
        }

        public IResult Delete(int id)
        {
            City city = _cityDal.Get(c => c.Id == id);

            if (city == null)
                return new ErrorResult(CityConstants.NotMatch);

            _cityDal.Delete(city);
            return new SuccessResult(CityConstants.DeleteSuccess);
        }

        public IResult ShadowDelete(int id)
        {
            City city = _cityDal.Get(c => c.Id == id && !c.IsDeleted);

            if (city == null)
                return new ErrorResult(CityConstants.NotMatch);

            _cityDal.Update(city);
            return new SuccessResult(CityConstants.ShadowDeleteSuccess);
        }

        [ValidationAspect(typeof(CityValidator), Priority = 1)]
        public IResult Update(City city)
        {
            IDataResult<Country> country = _cityFacadeService.CountryService().GetById(city.CountryId);

            IResult result = BusinessRules.Run(CheckCityIdAndNameByExists(city.CountryId, city.CityName), country);
            if (result != null)
                return result;

            city.Country = country.Data;
            _cityDal.Update(city);
            return new SuccessResult(CityConstants.UpdateSuccess);
        }

        [ValidationAspect(typeof(CityValidator), Priority = 1)]
        public IDataResult<CityUpdateDto> DtoUpdate(CityUpdateDto updateDto)
        {
            City city = new MapperConfiguration(cfg => cfg.CreateMap<CityAddDto, City>()).CreateMapper().Map<City>(updateDto);

            IDataResult<Country> country = _cityFacadeService.CountryService().GetById(city.CountryId);

            IResult result = BusinessRules.Run(CheckCityByExists(city.CityName), country);
            if (result != null)
                return new ErrorDataResult<CityUpdateDto>(result.Message);

            city.Country = country.Data;

            City returnCity = _cityDal.Add(city);
            return returnCity != null
                ? new SuccessDataResult<CityUpdateDto>(updateDto, CityConstants.UpdateSuccess)
                : new ErrorDataResult<CityUpdateDto>(updateDto, CityConstants.UpdateFailed);
        }

        public IDataResult<City> GetById(int id)
        {
            City city = _cityDal.Get(c => c.Id == id);

            return city != null
                ? new SuccessDataResult<City>(city, CityConstants.DataGet)
                : new ErrorDataResult<City>(CityConstants.CityNotFound);
        }

        public IDataResult<CityDto> DtoGetById(int id)
        {
            CityDto cityDto = _cityDal.DtoGet(c => c.Id == id);

            return cityDto != null
                ? new SuccessDataResult<CityDto>(cityDto, CityConstants.DataGet)
                : new ErrorDataResult<CityDto>(CityConstants.CityNotFound);
        }

        public IDataResult<IList<City>> GetAllByIds(int[] ids)
        {
            IList<City> cities = _cityDal.GetAll(c => ids.Contains(c.Id) && !c.IsDeleted);
            return cities == null
                 ? new ErrorDataResult<IList<City>>(CityConstants.NotMatch)
                 : new SuccessDataResult<IList<City>>(cities, CityConstants.DataGet);
        }

        public IDataResult<IList<CityDto>> DtoGetAllByIds(int[] ids)
        {
            IList<CityDto> cityDtos = _cityDal.DtoGetAll(c => ids.Contains(c.CountryId));
            return cityDtos == null
                ? new ErrorDataResult<IList<CityDto>>(CityConstants.NotMatch)
                : new SuccessDataResult<IList<CityDto>>(cityDtos, CityConstants.DataGet);
        }

        public IDataResult<IList<City>> GetAllByFilter(Expression<Func<City, bool>>? filter = null)
        {
            return new SuccessDataResult<IList<City>>(_cityDal.GetAll(filter), CityConstants.DataGet);
        }

        public IDataResult<IList<CityDto>> DtoGetAllByFilter(Expression<Func<City, bool>>? filter = null)
        {
            return new SuccessDataResult<IList<CityDto>>(_cityDal.DtoGetAll(filter), CityConstants.DataGet);
        }

        public IDataResult<IList<City>> GetAllByName(string name)
        {
            IList<City> cities = _cityDal.GetAll(c => c.CityName.Contains(name));

            return cities == null
                ? new ErrorDataResult<IList<City>>(CityConstants.NotMatch)
                : new SuccessDataResult<IList<City>>(cities, CityConstants.DataGet);
        }

        public IDataResult<IList<CityDto>> DtoGetAllByName(string name)
        {
            IList<CityDto> cityDtos = _cityDal.DtoGetAll(c => c.CityName.Contains(name));
            return cityDtos == null
                ? new ErrorDataResult<IList<CityDto>>(CityConstants.NotMatch)
                : new SuccessDataResult<IList<CityDto>>(cityDtos, CityConstants.DataGet);
        }

        public IDataResult<IList<City>> GetAllByIsDeleted()
        {
            return new SuccessDataResult<IList<City>>(_cityDal.GetAll(c => c.IsDeleted), CityConstants.DataGet);
        }

        public IDataResult<IList<CityDto>> DtoGetAllByIsDeleted()
        {
            return new SuccessDataResult<IList<CityDto>>(_cityDal.DtoGetAll(c => c.IsDeleted), CityConstants.DataGet);
        }

        public IDataResult<IList<City>> GetAll()
        {
            return new SuccessDataResult<IList<City>>(_cityDal.GetAll(c => !c.IsDeleted), CityConstants.DataGet);
        }

        public IDataResult<IList<CityDto>> DtoGetAll()
        {
            return new SuccessDataResult<IList<CityDto>>(_cityDal.DtoGetAll(c => !c.IsDeleted), CityConstants.DataGet);
        }

        private IResult CheckCityIdAndNameByExists(int cityId, string cityName)
        {
            bool cityExist = _cityDal.GetAll(c => c.CityName.Contains(cityName)
            && c.Id.Equals(cityId)).Any();
            return !cityExist
                ? new SuccessResult()
                : new ErrorResult(CityConstants.NotMatch);
        }

        private IResult CheckCityByExists(string cityName)
        {
            City cityExist = _cityDal.Get(c => c.CityName.Contains(cityName));
            return cityExist == null
                ? new SuccessResult()
                : new ErrorResult(CityConstants.CityExist);
        }
    }
}
