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
    public class LibraryManager : ILibraryService
    {
        private readonly ILibraryDal _libraryDal;
        private readonly IAddressService _addressService;
        private readonly ICommunicationService _communicationService;
        private readonly ICountryService _countryService;
        private readonly ICityService _cityService;

        public LibraryManager(ILibraryDal libraryDal, IAddressService addressService, ICommunicationService communicationService, ICountryService countryService, ICityService cityService)
        {
            _libraryDal = libraryDal;
            _addressService = addressService;
            _communicationService = communicationService;
            _countryService = countryService;
            _cityService = cityService;
        }

        [ValidationAspect(typeof(LibraryValidator), Priority = 1)]
        public IResult Add(Library library)
        {
            IResult result = BusinessRules.Run(LibraryExistControl(library));
            if (result != null)
                return result;
            _libraryDal.Add(library);
            return new SuccessResult(LibraryConstants.AddSuccess);
        }

        public IResult Delete(Guid id)
        {
            Library library = _libraryDal.Get(l => l.Id == id);
            if (library == null)
                return new SuccessResult(LibraryConstants.NotMatch);

            _libraryDal.Delete(library);
            return new SuccessResult(LibraryConstants.DeleteSuccess);
        }

        public IResult ShadowDelete(Guid id)
        {
            Library library = _libraryDal.Get(l => l.Id == id && !l.IsDestroyed);
            if (library == null)
                return new SuccessResult(LibraryConstants.NotMatch);

            library.IsDestroyed = true;
            _libraryDal.Delete(library);
            return new SuccessResult(LibraryConstants.DeleteSuccess);
        }

        [ValidationAspect(typeof(LibraryValidator), Priority = 1)]
        public IResult Update(Library library)
        {
            IResult result = BusinessRules.Run(LibraryExistControl(library));
            if (result != null)
                return result;

            _libraryDal.Update(library);
            return new SuccessResult(LibraryConstants.UpdateSuccess);
        }

        public IDataResult<Library> GetById(Guid id)
        {
            return new SuccessDataResult<Library>(_libraryDal.Get(l => l.Id == id), LibraryConstants.DataGet);
        }

        public IDataResult<List<Library>> GetByNames(string name)
        {
            List<Library> libraries = _libraryDal.GetAll(l => l.LibraryName.Contains(name, StringComparison.CurrentCultureIgnoreCase) && !l.IsDestroyed).ToList();
            return libraries == null
                ? new ErrorDataResult<List<Library>>(LibraryConstants.DataNotGet)
                : new SuccessDataResult<List<Library>>(libraries, LibraryConstants.DataGet);
        }

        public IDataResult<List<Library>> GetByFilterLists(Expression<Func<Library, bool>>? filter = null)
        {
            return new SuccessDataResult<List<Library>>(_libraryDal.GetAll(filter).ToList(), LibraryConstants.DataGet);
        }

        public IDataResult<List<Library>> GetLibraryTypes(byte libType)
        {
            return new SuccessDataResult<List<Library>>(_libraryDal.GetAll(l => l.LibraryType == libType && !l.IsDestroyed).ToList(), LibraryConstants.DataGet);
        }

        public IDataResult<Library> GetByAdderssId(Guid addressId)
        {
            IDataResult<Address> address = _addressService.GetById(addressId);
            if (!address.Success)
                return new ErrorDataResult<Library>(address.Message);

            Library library = _libraryDal.Get(l => l.Address == address.Data && !l.IsDestroyed);

            return library == null
                ? new ErrorDataResult<Library>(LibraryConstants.NotMatch)
                : new SuccessDataResult<Library>(library, LibraryConstants.DataGet);
        }

        public IDataResult<List<Library>> GetByLibraryInCountryId(int countryId)
        {
            IDataResult<Country> country = _countryService.GetById(countryId);
            if (!country.Success)
                return new ErrorDataResult<List<Library>>(country.Message);

            List<Library> libraries = _libraryDal.GetAll(l => l.Address.Country == country && !l.IsDestroyed).ToList();

            return libraries == null
                ? new ErrorDataResult<List<Library>>(LibraryConstants.NotMatch)
                : new SuccessDataResult<List<Library>>(libraries, LibraryConstants.DataGet);
        }

        public IDataResult<List<Library>> GetByAddressName(string addressName)
        {
            IDataResult<List<Address>> addresses = _addressService.GetByNames(addressName);
            if (!addresses.Success)
                return new ErrorDataResult<List<Library>>(addresses.Message);

            List<Library> libraries = new();
            foreach (Address address in addresses.Data)
            {
                Library library = _libraryDal.Get(l => l.Address == address && l.IsDestroyed);
                if (library != null)
                    libraries.Add(library);
            }

            return libraries == null
                ? new ErrorDataResult<List<Library>>(LibraryConstants.DataNotGet)
                : new SuccessDataResult<List<Library>>(libraries, LibraryConstants.DataGet);
        }

        public IDataResult<List<Library>> GetByAddressLines(string addressLine)
        {
            IDataResult<List<Address>> addresses = _addressService.GetBySearchString(addressLine);
            if (!addresses.Success)
                return new ErrorDataResult<List<Library>>(addresses.Message);

            List<Library> libraries = new();
            foreach (Address address in addresses.Data)
            {
                Library library = _libraryDal.Get(l => l.Address == address && !l.IsDestroyed);
                if (library != null)
                    libraries.Add(library);
            }

            return libraries == null
                ? new ErrorDataResult<List<Library>>(LibraryConstants.DataNotGet)
                : new SuccessDataResult<List<Library>>(libraries, LibraryConstants.DataGet);
        }

        public IDataResult<List<Library>> GetByLibraryInCountryName(string countryName)
        {
            IDataResult<List<Country>> countyries = _countryService.GetByNames(countryName);
            if (!countyries.Success)
                return new ErrorDataResult<List<Library>>(countyries.Message);

            List<Library> libraries = new();
            foreach (Country country in countyries.Data)
            {
                Library library = _libraryDal.Get(l => l.Address.Country == country && !l.IsDestroyed);
                if (library != null)
                    libraries.Add(library);
            }

            return libraries == null
                ? new ErrorDataResult<List<Library>>(LibraryConstants.DataNotGet)
                : new SuccessDataResult<List<Library>>(libraries, LibraryConstants.DataGet);
        }

        public IDataResult<List<Library>> GetByLibraryInCountryCode(string countryCode)
        {
            IDataResult<List<Country>> countyries = _countryService.GetByCountryCodes(countryCode);
            if (!countyries.Success)
                return new ErrorDataResult<List<Library>>(countyries.Message);

            List<Library> libraries = new();
            foreach (Country country in countyries.Data)
            {
                Library library = _libraryDal.Get(l => l.Address.Country == country && !l.IsDestroyed);
                if (library != null)
                    libraries.Add(library);
            }

            return libraries == null
                ? new ErrorDataResult<List<Library>>(LibraryConstants.DataNotGet)
                : new SuccessDataResult<List<Library>>(libraries, LibraryConstants.DataGet);
        }

        public IDataResult<List<Library>> GetByLibraryInCityId(int cityId)
        {
            IDataResult<City> city = _cityService.GetById(cityId);
            if (!city.Success)
                return new ErrorDataResult<List<Library>>(city.Message);
            List<Library> libraries = _libraryDal.GetAll(l => l.Address.City == city && !l.IsDestroyed).ToList();
            return libraries == null
                ? new ErrorDataResult<List<Library>>(LibraryConstants.DataNotGet)
                : new SuccessDataResult<List<Library>>(libraries, LibraryConstants.DataGet);
        }

        public IDataResult<List<Library>> GetByLibraryInCityName(string cityName)
        {
            IDataResult<List<City>> cities = _cityService.GetByNames(cityName);
            if (!cities.Success)
                return new ErrorDataResult<List<Library>>(cities.Message);

            List<Library> libraries = new();
            foreach (City city in cities.Data)
            {
                Library library = _libraryDal.Get(l => l.Address.City == city && !l.IsDestroyed);
                if (library != null)
                    libraries.Add(library);
            }

            return libraries == null
                ? new ErrorDataResult<List<Library>>(LibraryConstants.DataNotGet)
                : new SuccessDataResult<List<Library>>(libraries, LibraryConstants.DataGet);
        }

        public IDataResult<List<Library>> GetByLibraryInPostalCode(string postalCode)
        {
            IDataResult<List<Address>> addresses = _addressService.GetByPostalCode(postalCode);
            if (!addresses.Success)
                return new ErrorDataResult<List<Library>>(addresses.Message);
            List<Library> libraries = new();
            foreach (Address address in addresses.Data)
            {
                Library library = _libraryDal.Get(l => l.Address == address && !l.IsDestroyed);
                if (library != null)
                    libraries.Add(library);
            }

            return libraries == null
                ? new ErrorDataResult<List<Library>>(LibraryConstants.DataNotGet)
                : new SuccessDataResult<List<Library>>(libraries, LibraryConstants.DataGet);
        }

        public IDataResult<List<Library>> GetByLibraryInGeoLocation(string geoLoc)
        {
            IDataResult<List<Address>> addresses = _addressService.GetByGeoLocation(geoLoc);
            if (!addresses.Success)
                return new ErrorDataResult<List<Library>>(addresses.Message);
            List<Library> libraries = new();
            foreach (Address address in addresses.Data)
            {
                Library library = _libraryDal.Get(l => l.Address == address && !l.IsDestroyed);
                if (library != null)
                    libraries.Add(library);
            }

            return libraries == null
                ? new ErrorDataResult<List<Library>>(LibraryConstants.DataNotGet)
                : new SuccessDataResult<List<Library>>(libraries, LibraryConstants.DataGet);
        }

        public IDataResult<Library> GetByCommunicationId(Guid commId)
        {
            IDataResult<Communication> comm = _communicationService.GetById(commId);
            if (!comm.Success)
                return new ErrorDataResult<Library>(comm.Message);

            Library library = _libraryDal.Get(l => l.Communication == comm && !l.IsDestroyed);
            return library == null
                ? new ErrorDataResult<Library>(LibraryConstants.DataNotGet)
                : new SuccessDataResult<Library>(library, LibraryConstants.DataGet);
        }

        public IDataResult<List<Library>> GetByCommunicationName(string commName)
        {
            IDataResult<List<Communication>> comms = _communicationService.GetByNames(commName);
            if (!comms.Success)
                return new ErrorDataResult<List<Library>>(comms.Message);
            List<Library> libraries = new();

            foreach (Communication comm in comms.Data)
            {
                Library library = _libraryDal.Get(l => l.Communication == comm && !l.IsDestroyed);
                if (library != null)
                    libraries.Add(library);
            }
            return libraries == null
                ? new ErrorDataResult<List<Library>>(LibraryConstants.DataNotGet)
                : new SuccessDataResult<List<Library>>(libraries, LibraryConstants.DataGet);
        }

        public IDataResult<Library> GetByCommunicationPhone(string commPhone)
        {
            IDataResult<Communication> comm = _communicationService.GetByPhoneNumber(commPhone);
            if (!comm.Success)
                return new ErrorDataResult<Library>(comm.Message);

            Library library = _libraryDal.Get(l => l.Communication == comm && !l.IsDestroyed);
            return library == null
                ? new ErrorDataResult<Library>(LibraryConstants.DataNotGet)
                : new SuccessDataResult<Library>(library, LibraryConstants.DataGet);
        }

        public IDataResult<Library> GetByCommunicationFaxNumber(string commFaxNumber)
        {
            IDataResult<Communication> comm = _communicationService.GetbyFaxNumber(commFaxNumber);
            if (!comm.Success)
                return new ErrorDataResult<Library>(comm.Message);

            Library library = _libraryDal.Get(l => l.Communication == comm && !l.IsDestroyed);
            return library == null
                ? new ErrorDataResult<Library>(LibraryConstants.DataNotGet)
                : new SuccessDataResult<Library>(library, LibraryConstants.DataGet);
        }

        public IDataResult<Library> GetByCommunicationEmail(string commEmail)
        {
            IDataResult<Communication> comm = _communicationService.GetByEmail(commEmail);
            if (!comm.Success)
                return new ErrorDataResult<Library>(comm.Message);

            Library library = _libraryDal.Get(l => l.Communication == comm && !l.IsDestroyed);
            return library == null
                ? new ErrorDataResult<Library>(LibraryConstants.DataNotGet)
                : new SuccessDataResult<Library>(library, LibraryConstants.DataGet);
        }

        public IDataResult<Library> GetByCommunicationWebSite(string commWebSite)
        {
            IDataResult<Communication> comm = _communicationService.GetByPhoneNumber(commWebSite);
            if (!comm.Success)
                return new ErrorDataResult<Library>(comm.Message);

            Library library = _libraryDal.Get(l => l.Communication == comm && !l.IsDestroyed);
            return library == null
                ? new ErrorDataResult<Library>(LibraryConstants.DataNotGet)
                : new SuccessDataResult<Library>(library, LibraryConstants.DataGet);
        }

        public IDataResult<Dictionary<byte, string>> GetAllEnumToDictionaryLibraryTypes()
        {
            Dictionary<byte, string> LibTypes = Enum.GetValues(typeof(LibraryConstants.LibraryTypes)).Cast<LibraryConstants.LibraryTypes>().ToDictionary(l => (byte)l, l => l.ToString());
            return new SuccessDataResult<Dictionary<byte, string>>(LibTypes, LibraryConstants.Disabled);
        }

        public IDataResult<List<Library>> GetAllBySecrets()
        {
            return new SuccessDataResult<List<Library>>(_libraryDal.GetAll(l => l.IsDestroyed).ToList(), LibraryConstants.DataGet);
        }

        public IDataResult<List<Library>> GetAll()
        {
            return new SuccessDataResult<List<Library>>(_libraryDal.GetAll(l => !l.IsDestroyed).ToList(), LibraryConstants.DataGet);
        }

        private IResult LibraryExistControl(Library library)
        {
            // fixme
            bool resul = _libraryDal.GetAll(l =>
            l.LibraryName.ToLowerInvariant().Contains(library.LibraryName, StringComparison.CurrentCultureIgnoreCase)
            && l.LibraryType == library.LibraryType
            && l.Address == library.Address
            && l.Communication == library.Communication
            && l.Address == library.Address).Any();

            return !resul
                ? new SuccessResult()
                : new ErrorResult(LibraryConstants.LibraryExist);
        }
    }
}