using Business.Abstract;
using Business.Constants;
using Business.DependencyResolvers.Facade;
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
        private readonly IFacadeService _facadeService;

        public LibraryManager(ILibraryDal libraryDal)
        {
            _libraryDal = libraryDal;
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
            _libraryDal.Update(library);
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
            Library library = _libraryDal.Get(l => l.Id == id);

            return library != null
                ? new SuccessDataResult<Library>(library, LibraryConstants.DataGet)
                : new ErrorDataResult<Library>(LibraryConstants.NotMatch);
        }

        public IDataResult<IList<Library>> GetAllByIds(Guid[] ids)
        {
            IList<Library> libraries = _libraryDal.GetAll(l => ids.Contains(l.Id) && !l.IsDestroyed);
            return libraries == null
                ? new ErrorDataResult<IList<Library>>(LibraryConstants.DataNotGet)
                : new SuccessDataResult<IList<Library>>(libraries, LibraryConstants.DataGet);
        }

        public IDataResult<IList<Library>> GetAllByName(string name)
        {
            IList<Library> libraries = _libraryDal.GetAll(l => l.LibraryName.Contains(name) && !l.IsDestroyed);
            return libraries == null
                ? new ErrorDataResult<IList<Library>>(LibraryConstants.DataNotGet)
                : new SuccessDataResult<IList<Library>>(libraries, LibraryConstants.DataGet);
        }

        public IDataResult<IList<Library>> GetAllByFilter(Expression<Func<Library, bool>>? filter = null)
        {
            return new SuccessDataResult<IList<Library>>(_libraryDal.GetAll(filter), LibraryConstants.DataGet);
        }

        public IDataResult<IList<Library>> GetAllByLibraryType(byte libType)
        {
            return new SuccessDataResult<IList<Library>>(_libraryDal.GetAll(l => l.LibraryType == libType && !l.IsDestroyed), LibraryConstants.DataGet);
        }

        public IDataResult<Library> GetByAddressId(Guid addressId)
        {
            IDataResult<Address> address = _facadeService.AddressService().GetById(addressId);
            if (!address.Success)
                return new ErrorDataResult<Library>(address.Message);

            Library library = _libraryDal.Get(l => l.Address == address.Data && !l.IsDestroyed);

            return library == null
                ? new ErrorDataResult<Library>(LibraryConstants.NotMatch)
                : new SuccessDataResult<Library>(library, LibraryConstants.DataGet);
        }

        public IDataResult<IList<Library>> GetAllByLibraryInCountryId(int countryId)
        {
            IDataResult<Country> country = _facadeService.CountryService().GetById(countryId);
            if (!country.Success)
                return new ErrorDataResult<IList<Library>>(country.Message);

            IList<Library> libraries = _libraryDal.GetAll(l => l.Address.Country == country && !l.IsDestroyed);

            return libraries == null
                ? new ErrorDataResult<IList<Library>>(LibraryConstants.NotMatch)
                : new SuccessDataResult<IList<Library>>(libraries, LibraryConstants.DataGet);
        }

        public IDataResult<IList<Library>> GetAllByAddressName(string addressName)
        {
            IDataResult<IList<Address>> addresses = _facadeService.AddressService().GetAllByName(addressName);
            if (!addresses.Success)
                return new ErrorDataResult<IList<Library>>(addresses.Message);

            List<Library> libraries = new();
            foreach (Address address in addresses.Data)
            {
                Library library = _libraryDal.Get(l => l.Address == address && l.IsDestroyed);
                if (library != null)
                    libraries.Add(library);
            }

            return libraries == null
                ? new ErrorDataResult<IList<Library>>(LibraryConstants.DataNotGet)
                : new SuccessDataResult<IList<Library>>(libraries, LibraryConstants.DataGet);
        }

        public IDataResult<IList<Library>> GetAllByAddressLine(string addressLine)
        {
            IDataResult<IList<Address>> addresses = _facadeService.AddressService().GetAllBySearchString(addressLine);
            if (!addresses.Success)
                return new ErrorDataResult<IList<Library>>(addresses.Message);

            List<Library> libraries = new();
            foreach (Address address in addresses.Data)
            {
                Library library = _libraryDal.Get(l => l.Address == address && !l.IsDestroyed);
                if (library != null)
                    libraries.Add(library);
            }

            return libraries == null
                ? new ErrorDataResult<IList<Library>>(LibraryConstants.DataNotGet)
                : new SuccessDataResult<IList<Library>>(libraries, LibraryConstants.DataGet);
        }

        public IDataResult<IList<Library>> GetAllByLibraryInCountryName(string countryName)
        {
            IDataResult<IList<Country>> countyries = _facadeService.CountryService().GetAllByName(countryName);
            if (!countyries.Success)
                return new ErrorDataResult<IList<Library>>(countyries.Message);

            List<Library> libraries = new();
            foreach (Country country in countyries.Data)
            {
                Library library = _libraryDal.Get(l => l.Address.Country == country && !l.IsDestroyed);
                if (library != null)
                    libraries.Add(library);
            }

            return libraries == null
                ? new ErrorDataResult<IList<Library>>(LibraryConstants.DataNotGet)
                : new SuccessDataResult<IList<Library>>(libraries, LibraryConstants.DataGet);
        }

        public IDataResult<IList<Library>> GetAllByLibraryInCountryCode(string countryCode)
        {
            IDataResult<IList<Country>> countyries = _facadeService.CountryService().GetAllByCountryCode(countryCode);
            if (!countyries.Success)
                return new ErrorDataResult<IList<Library>>(countyries.Message);

            List<Library> libraries = new();
            foreach (Country country in countyries.Data)
            {
                Library library = _libraryDal.Get(l => l.Address.Country == country && !l.IsDestroyed);
                if (library != null)
                    libraries.Add(library);
            }

            return libraries == null
                ? new ErrorDataResult<IList<Library>>(LibraryConstants.DataNotGet)
                : new SuccessDataResult<IList<Library>>(libraries, LibraryConstants.DataGet);
        }

        public IDataResult<IList<Library>> GetAllByLibraryInCityId(int cityId)
        {
            IDataResult<City> city = _facadeService.CityService().GetById(cityId);
            if (!city.Success)
                return new ErrorDataResult<IList<Library>>(city.Message);
            IList<Library> libraries = _libraryDal.GetAll(l => l.Address.City == city && !l.IsDestroyed);
            return libraries == null
                ? new ErrorDataResult<IList<Library>>(LibraryConstants.DataNotGet)
                : new SuccessDataResult<IList<Library>>(libraries, LibraryConstants.DataGet);
        }

        public IDataResult<IList<Library>> GetAllByLibraryInCityName(string cityName)
        {
            IDataResult<IList<City>> cities = _facadeService.CityService().GetAllByName(cityName);
            if (!cities.Success)
                return new ErrorDataResult<IList<Library>>(cities.Message);

            List<Library> libraries = new();
            foreach (City city in cities.Data)
            {
                Library library = _libraryDal.Get(l => l.Address.City == city && !l.IsDestroyed);
                if (library != null)
                    libraries.Add(library);
            }

            return libraries == null
                ? new ErrorDataResult<IList<Library>>(LibraryConstants.DataNotGet)
                : new SuccessDataResult<IList<Library>>(libraries, LibraryConstants.DataGet);
        }

        public IDataResult<IList<Library>> GetAllByLibraryInPostalCode(string postalCode)
        {
            IDataResult<IList<Address>> addresses = _facadeService.AddressService().GetAllByPostalCode(postalCode);
            if (!addresses.Success)
                return new ErrorDataResult<IList<Library>>(addresses.Message);
            List<Library> libraries = new();
            foreach (Address address in addresses.Data)
            {
                Library library = _libraryDal.Get(l => l.Address == address && !l.IsDestroyed);
                if (library != null)
                    libraries.Add(library);
            }

            return libraries == null
                ? new ErrorDataResult<IList<Library>>(LibraryConstants.DataNotGet)
                : new SuccessDataResult<IList<Library>>(libraries, LibraryConstants.DataGet);
        }

        public IDataResult<IList<Library>> GetAllByLibraryInGeoLocation(string geoLoc)
        {
            IDataResult<IList<Address>> addresses = _facadeService.AddressService().GetAllByGeoLocation(geoLoc);
            if (!addresses.Success)
                return new ErrorDataResult<IList<Library>>(addresses.Message);
            List<Library> libraries = new();
            foreach (Address address in addresses.Data)
            {
                Library library = _libraryDal.Get(l => l.Address == address && !l.IsDestroyed);
                if (library != null)
                    libraries.Add(library);
            }

            return libraries == null
                ? new ErrorDataResult<IList<Library>>(LibraryConstants.DataNotGet)
                : new SuccessDataResult<IList<Library>>(libraries, LibraryConstants.DataGet);
        }

        public IDataResult<Library> GetByCommunicationId(Guid commId)
        {
            IDataResult<Communication> comm = _facadeService.CommunicationService().GetById(commId);
            if (!comm.Success)
                return new ErrorDataResult<Library>(comm.Message);

            Library library = _libraryDal.Get(l => l.Communication == comm && !l.IsDestroyed);
            return library == null
                ? new ErrorDataResult<Library>(LibraryConstants.DataNotGet)
                : new SuccessDataResult<Library>(library, LibraryConstants.DataGet);
        }

        public IDataResult<IList<Library>> GetAllByCommunicationName(string commName)
        {
            IDataResult<IList<Communication>> comms = _facadeService.CommunicationService().GetAllByName(commName);
            if (!comms.Success)
                return new ErrorDataResult<IList<Library>>(comms.Message);
            List<Library> libraries = new();

            foreach (Communication comm in comms.Data)
            {
                Library library = _libraryDal.Get(l => l.Communication == comm && !l.IsDestroyed);
                if (library != null)
                    libraries.Add(library);
            }
            return libraries == null
                ? new ErrorDataResult<IList<Library>>(LibraryConstants.DataNotGet)
                : new SuccessDataResult<IList<Library>>(libraries, LibraryConstants.DataGet);
        }

        public IDataResult<Library> GetByCommunicationPhone(string commPhone)
        {
            IDataResult<Communication> comm = _facadeService.CommunicationService().GetByPhoneNumber(commPhone);
            if (!comm.Success)
                return new ErrorDataResult<Library>(comm.Message);

            Library library = _libraryDal.Get(l => l.Communication == comm && !l.IsDestroyed);
            return library == null
                ? new ErrorDataResult<Library>(LibraryConstants.DataNotGet)
                : new SuccessDataResult<Library>(library, LibraryConstants.DataGet);
        }

        public IDataResult<Library> GetByCommunicationFaxNumber(string commFaxNumber)
        {
            IDataResult<Communication> comm = _facadeService.CommunicationService().GetByFaxNumber(commFaxNumber);
            if (!comm.Success)
                return new ErrorDataResult<Library>(comm.Message);

            Library library = _libraryDal.Get(l => l.Communication == comm && !l.IsDestroyed);
            return library == null
                ? new ErrorDataResult<Library>(LibraryConstants.DataNotGet)
                : new SuccessDataResult<Library>(library, LibraryConstants.DataGet);
        }

        public IDataResult<Library> GetByCommunicationEmail(string commEmail)
        {
            IDataResult<Communication> comm = _facadeService.CommunicationService().GetByEmail(commEmail);
            if (!comm.Success)
                return new ErrorDataResult<Library>(comm.Message);

            Library library = _libraryDal.Get(l => l.Communication == comm && !l.IsDestroyed);
            return library == null
                ? new ErrorDataResult<Library>(LibraryConstants.DataNotGet)
                : new SuccessDataResult<Library>(library, LibraryConstants.DataGet);
        }

        public IDataResult<Library> GetByCommunicationWebSite(string commWebSite)
        {
            IDataResult<Communication> comm = _facadeService.CommunicationService().GetByPhoneNumber(commWebSite);
            if (!comm.Success)
                return new ErrorDataResult<Library>(comm.Message);

            Library library = _libraryDal.Get(l => l.Communication == comm && !l.IsDestroyed);
            return library == null
                ? new ErrorDataResult<Library>(LibraryConstants.DataNotGet)
                : new SuccessDataResult<Library>(library, LibraryConstants.DataGet);
        }

        public IDataResult<Dictionary<byte, string>> GetAllEnumToDictionaryLibraryType()
        {
            Dictionary<byte, string> LibTypes = Enum.GetValues(typeof(LibraryConstants.LibraryTypes)).Cast<LibraryConstants.LibraryTypes>().ToDictionary(l => (byte)l, l => l.ToString());
            return new SuccessDataResult<Dictionary<byte, string>>(LibTypes, LibraryConstants.Disabled);
        }

        public IDataResult<IList<Library>> GetAllByIsDeleted()
        {
            return new SuccessDataResult<IList<Library>>(_libraryDal.GetAll(l => l.IsDestroyed), LibraryConstants.DataGet);
        }

        public IDataResult<IList<Library>> GetAll()
        {
            return new SuccessDataResult<IList<Library>>(_libraryDal.GetAll(l => !l.IsDestroyed), LibraryConstants.DataGet);
        }

        private IResult LibraryExistControl(Library library)
        {
            // fixme
            bool resul = _libraryDal.GetAll(l =>
            l.LibraryName.Contains(library.LibraryName)
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