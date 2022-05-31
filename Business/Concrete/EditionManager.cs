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
    public class EditionManager : IEditionService
    {
        private readonly IEditionDal _editionDal;
        private readonly IAddressService _addressService;
        private readonly ICountryService _countryService;
        private readonly ICityService _cityService;

        public EditionManager(IEditionDal editionDal, IAddressService addressService, ICountryService countryService, ICityService cityService)
        {
            _editionDal = editionDal;
            _addressService = addressService;
            _countryService = countryService;
            _cityService = cityService;
        }

        [ValidationAspect(typeof(EditionValidator), Priority = 1)]
        public IResult Add(Edition edition)
        {
            IResult result = BusinessRules.Run(EditionControl(edition));
            if (result != null)
                return result;

            edition.IsDeleted = false;
            _editionDal.Add(edition);
            return new SuccessResult(EditionConstants.AddSuccess);
        }

        public IResult Delete(Guid id)
        {
            Edition edition = _editionDal.Get(u => u.Id == id);
            if (edition == null)
                return new ErrorResult(EditionConstants.NotMatch);

            _editionDal.Delete(edition);
            return new SuccessResult(EditionConstants.DeleteSuccess);
        }

        public IResult ShadowDelete(Guid id)
        {
            Edition edition = _editionDal.Get(u => u.Id == id && u.IsDeleted);
            if (edition == null)
                return new ErrorResult(EditionConstants.NotMatch);

            edition.IsDeleted = true;
            _editionDal.Update(edition);
            return new SuccessResult(EditionConstants.ShadowDeleteSuccess);
        }

        [ValidationAspect(typeof(EditionValidator), Priority = 1)]
        public IResult Update(Edition edition)
        {
            _editionDal.Update(edition);
            return new SuccessResult(EditionConstants.UpdateSuccess);
        }

        public IDataResult<Edition> GetById(Guid id)
        {
            Edition edition = _editionDal.Get(f => f.Id == id);
            return edition == null
                ? new ErrorDataResult<Edition>(EditionConstants.DataNotGet)
                : new SuccessDataResult<Edition>(edition, EditionConstants.DataGet);
        }

        public IDataResult<Edition> GetByAdderssId(Guid addressId)
        {
            IDataResult<Address> address = _addressService.GetById(addressId);
            if (!address.Success)
                return new ErrorDataResult<Edition>(address.Message);

            Edition edition = _editionDal.Get(e => e.Address == address && !e.IsDeleted);

            return edition == null
                ? new ErrorDataResult<Edition>(EditionConstants.AddressNotFound)
                : new SuccessDataResult<Edition>(edition, EditionConstants.AddressFound);
        }

        public IDataResult<List<Edition>> GetByEditionInCountryId(int countryId)
        {
            IDataResult<Country> country = _countryService.GetById(countryId);
            if (!country.Success)
                return new ErrorDataResult<List<Edition>>(country.Message);

            List<Edition> editions = _editionDal.GetAll(e => e.Address.Country == country && !e.IsDeleted).ToList();

            return editions == null
                ? new ErrorDataResult<List<Edition>>(EditionConstants.DataNotGet)
                : new SuccessDataResult<List<Edition>>(editions, EditionConstants.AllDataGet);
        }

        public IDataResult<List<Edition>> GetByAddressName(string addressName)
        {   //experimental first way methot todo
            List<Edition> editions = _editionDal.GetAll(e => e.Address.AddressName.Contains(addressName, StringComparison.CurrentCultureIgnoreCase) && !e.IsDeleted).ToList();

            return editions == null
                ? new ErrorDataResult<List<Edition>>(EditionConstants.AddressNotFound)
                : new SuccessDataResult<List<Edition>>(editions, AddressConstants.DataGet);
        }

        public IDataResult<List<Edition>> GetByAddressLines(string addressLine)
        {   //experimental second way methot todo
            IDataResult<List<Address>> addressList = _addressService.GetBySearchString(addressLine);
            if (!addressList.Success)
                return new ErrorDataResult<List<Edition>>(addressList.Message);
            List<Edition> editions = new();

            foreach (Address address in addressList.Data)
            {
                Edition edition = _editionDal.Get(e => e.Address == address && !e.IsDeleted);
                editions.Add(edition);
            }

            return editions == null
                ? new ErrorDataResult<List<Edition>>(EditionConstants.AddressNotFound)
                : new SuccessDataResult<List<Edition>>(editions, EditionConstants.AddressFound);
        }

        public IDataResult<List<Edition>> GetByEditionInCountryName(string countryName)
        {
            List<Edition> editions = _editionDal.GetAll(e => e.Address.Country.CountryName.Contains(countryName, StringComparison.CurrentCultureIgnoreCase) && !e.IsDeleted).ToList();

            return editions == null
                ? new ErrorDataResult<List<Edition>>(EditionConstants.AddressNotFound)
                : new SuccessDataResult<List<Edition>>(editions, EditionConstants.AddressFound);
        }

        public IDataResult<List<Edition>> GetByEditionInCountryCode(string countryCode)
        {
            List<Edition> editions = _editionDal.GetAll(e => e.Address.Country.CountryCode.Contains(countryCode, StringComparison.CurrentCultureIgnoreCase) && !e.IsDeleted).ToList();

            return editions == null
                ? new ErrorDataResult<List<Edition>>(EditionConstants.AddressNotFound)
                : new SuccessDataResult<List<Edition>>(editions, EditionConstants.AddressFound);
        }

        public IDataResult<List<Edition>> GetByEditionInCityId(int cityId)
        {

            List<Edition> editions = _editionDal.GetAll(e => e.Address.City.Id == cityId).ToList();

            return editions == null
                ? new ErrorDataResult<List<Edition>>(EditionConstants.AddressNotFound)
                : new SuccessDataResult<List<Edition>>(editions, EditionConstants.AddressFound);
        }

        public IDataResult<List<Edition>> GetByEditionInCityName(string cityName)
        {
            IDataResult<List<City>> cities = _cityService.GetByNames(cityName);
            if (!cities.Success) return new ErrorDataResult<List<Edition>>(cities.Message);

            List<Edition> editions = new();
            foreach (City city in cities.Data)
            {
                Edition edition = _editionDal.Get(c => c.Address.City.Id == city.Id && !c.IsDeleted);
                if (edition != null)
                    editions.Add(edition);
            }

            return editions == null
                ? new ErrorDataResult<List<Edition>>(EditionConstants.AddressNotFound)
                : new SuccessDataResult<List<Edition>>(editions, EditionConstants.AddressFound);
        }

        public IDataResult<List<Edition>> GetByEditionInPostalCode(string postalCode)
        {
            IDataResult<List<Address>> addresses = _addressService.GetByPostalCode(postalCode);
            if (!addresses.Success) return new ErrorDataResult<List<Edition>>(addresses.Message);

            List<Edition> editions = new();
            foreach (Address address in addresses.Data)
            {
                Edition edition = _editionDal.Get(e => e.Address == address && !e.IsDeleted);
                if (edition != null)
                    editions.Add(edition);
            }

            return editions == null
                ? new ErrorDataResult<List<Edition>>(EditionConstants.AddressNotFound)
                : new SuccessDataResult<List<Edition>>(editions, EditionConstants.AddressFound);
        }

        public IDataResult<List<Edition>> GetByEditionInGeoLocation(string geoLoc)
        {
            IDataResult<List<Address>> addresses = _addressService.GetByGeoLocation(geoLoc);
            if (!addresses.Success) return new ErrorDataResult<List<Edition>>(addresses.Message);

            List<Edition> editions = new();
            foreach (Address address in addresses.Data)
            {
                Edition edition = _editionDal.Get(e => e.Address == address && !e.IsDeleted);
                if (edition != null)
                    editions.Add(edition);
            }

            return editions == null
                ? new ErrorDataResult<List<Edition>>(EditionConstants.AddressNotFound)
                : new SuccessDataResult<List<Edition>>(editions, EditionConstants.AddressFound);
        }

        public IDataResult<Edition> GetByCommunicationId(Guid commId)
        {
            Edition edition = _editionDal.Get(c => c.Communication.Id == commId && !c.IsDeleted);
            return edition == null
                ? new ErrorDataResult<Edition>(EditionConstants.DataNotGet)
                : new SuccessDataResult<Edition>(edition, EditorConstants.DataGet);
        }

        public IDataResult<List<Edition>> GetByCommunicationName(string commName)
        {
            List<Edition> editions = _editionDal.GetAll(c => c.Communication.CommunicationName.Contains(commName, StringComparison.CurrentCultureIgnoreCase) && !c.IsDeleted).ToList();
            return editions == null
                ? new ErrorDataResult<List<Edition>>(EditionConstants.DataNotGet)
                : new SuccessDataResult<List<Edition>>(editions, EditorConstants.DataGet);
        }

        public IDataResult<Edition> GetByCommunicationPhone(string commPhone)
        {
            Edition edition = _editionDal.Get(e => e.Communication.PhoneNumber.Contains(commPhone, StringComparison.CurrentCultureIgnoreCase) && !e.IsDeleted);
            return edition == null
                ? new ErrorDataResult<Edition>(EditionConstants.PhoneNumberNotGet)
                : new SuccessDataResult<Edition>(edition, EditionConstants.PhoneNumberGet);
        }

        public IDataResult<Edition> GetByCommunicationFaxNumber(string commFaxNumber)
        {
            Edition edition = _editionDal.Get(e => e.Communication.FaxNumber.Contains(commFaxNumber, StringComparison.CurrentCultureIgnoreCase) && !e.IsDeleted);
            return edition == null
                ? new ErrorDataResult<Edition>(EditionConstants.PhoneNumberNotGet)
                : new SuccessDataResult<Edition>(edition, EditionConstants.PhoneNumberGet);
        }

        public IDataResult<Edition> GetByCommunicationEmail(string commEmail)
        {
            Edition edition = _editionDal.Get(e => e.Communication.Email == commEmail && !e.IsDeleted);
            return edition == null
                ? new ErrorDataResult<Edition>(EditionConstants.DataNotGet)
                : new SuccessDataResult<Edition>(edition, EditionConstants.DataGet);
        }

        public IDataResult<Edition> GetByCommunicationWebSite(string commWebSite)
        {
            Edition edition = _editionDal.Get(e => e.Communication.WebSite.Contains(commWebSite, StringComparison.CurrentCultureIgnoreCase) && !e.IsDeleted);
            return edition == null
                ? new ErrorDataResult<Edition>(EditionConstants.DataNotGetWebSites)
                : new SuccessDataResult<Edition>(edition, EditionConstants.DataGetWebSites);
        }

        public IDataResult<List<Edition>> GetByDateOfPublication(DateTime dateOfPublication)
        {
            List<Edition> editions = _editionDal.GetAll(e => e.DateOfPublication == dateOfPublication).ToList();
            return editions == null
                ? new ErrorDataResult<List<Edition>>(EditionConstants.DataNotGet)
                : new ErrorDataResult<List<Edition>>(editions, EditionConstants.DataGet);
        }

        public IDataResult<List<Edition>> GetByDateOfPublicationMinMax(DateTime minDate, DateTime maxDate)
        {
            List<Edition> editions = _editionDal.GetAll(c => c.DateOfPublication > minDate && c.DateOfPublication < maxDate && !c.IsDeleted).ToList();
            return editions == null
                ? new ErrorDataResult<List<Edition>>(EditionConstants.DataNotGet)
                : new SuccessDataResult<List<Edition>>(editions, EditionConstants.DataGet);
        }

        public IDataResult<List<Edition>> GetByEditionNumbers(int eNumber)
        {
            List<Edition> editions = _editionDal.GetAll(e => e.EditionNumber == eNumber && !e.IsDeleted).ToList();

            return editions == null
                ? new ErrorDataResult<List<Edition>>(EditionConstants.NotMatch)
                : new SuccessDataResult<List<Edition>>(editions, EditionConstants.DataGet);
        }

        public IDataResult<List<Edition>> GetByNames(string name)
        {
            List<Edition> editions = _editionDal.GetAll(e => e.Name.Contains(name, StringComparison.CurrentCultureIgnoreCase) && !e.IsDeleted).ToList();

            return editions == null
                ? new ErrorDataResult<List<Edition>>(EditionConstants.DataNotGet)
                : new SuccessDataResult<List<Edition>>(editions, EditionConstants.DataGet);

        }

        public IDataResult<List<Edition>> GetByFilterLists(Expression<Func<Edition, bool>>? filter = null)
        {
            return new SuccessDataResult<List<Edition>>(_editionDal.GetAll(filter).ToList(), EditionConstants.DataGet);
        }

        public IDataResult<List<Edition>> GetAllBySecrets()
        {
            return new SuccessDataResult<List<Edition>>(_editionDal.GetAll(f => f.IsDeleted).ToList(), EditionConstants.DataGet);
        }

        public IDataResult<List<Edition>> GetAll()
        {
            return new SuccessDataResult<List<Edition>>(_editionDal.GetAll(f => !f.IsDeleted).ToList(), EditionConstants.DataGet);
        }

        private IResult EditionControl(Edition edition)
        {
            // fix it Todo
            bool result = _editionDal.GetAll(e =>
               e.Name.ToLowerInvariant().Equals(edition.Name.ToLowerInvariant())
            && e.Address.Equals(edition.Address)
            && e.DateOfPublication.Equals(edition.DateOfPublication)
            && e.EditionNumber.Equals(edition.EditionNumber)).Any();

            return result
                ? new ErrorResult(EditionConstants.EditionEquals)
                : new SuccessResult(PublisherConstants.AllDataGet);
        }
    }
}
