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
    public class EditionManager : IEditionService // todo rewrite
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

        public IDataResult<List<Edition>> GetByIds(Guid[] ids)
        {
            List<Edition> editions = _editionDal.GetAll(e => ids.Contains(e.Id) && !e.IsDeleted).ToList();

            return editions == null
                ? new ErrorDataResult<List<Edition>>(EditionConstants.AddressNotFound)
                : new SuccessDataResult<List<Edition>>(editions, AddressConstants.DataGet);
        }

        public IDataResult<Edition> GetByAdderssId(Guid addressId)
        {
            IDataResult<Address> address = _addressService.GetById(addressId);
            if (!address.Success)
                return new ErrorDataResult<Edition>(address.Message);

            Edition edition = _editionDal.Get(e => e.Publisher.Address == address && !e.IsDeleted);

            return edition == null
                ? new ErrorDataResult<Edition>(EditionConstants.AddressNotFound)
                : new SuccessDataResult<Edition>(edition, EditionConstants.AddressFound);
        }

        public IDataResult<List<Edition>> GetByEditionInCountryId(int countryId)
        {
            List<Edition> editions = _editionDal.GetAll(e => e.Publisher.Address.Country.Id == countryId && !e.IsDeleted).ToList();

            return editions == null
                ? new ErrorDataResult<List<Edition>>(EditionConstants.DataNotGet)
                : new SuccessDataResult<List<Edition>>(editions, EditionConstants.AllDataGet);
        }

        public IDataResult<List<Edition>> GetByAddressName(string addressName)
        {
            List<Edition> editions = _editionDal.GetAll(e => e.Publisher.Address.AddressName.Contains(addressName) && !e.IsDeleted).ToList();

            return editions == null
                ? new ErrorDataResult<List<Edition>>(EditionConstants.AddressNotFound)
                : new SuccessDataResult<List<Edition>>(editions, AddressConstants.DataGet);
        }

        public IDataResult<List<Edition>> GetByAddressLines(string addressLine)
        {
            List<Edition> editions = _editionDal.GetAll(e => (e.Publisher.Address.AddressLine1 + e.Publisher.Address.AddressLine2).Contains(addressLine) && !e.IsDeleted).ToList();
            return editions == null
                ? new ErrorDataResult<List<Edition>>(EditionConstants.AddressNotFound)
                : new SuccessDataResult<List<Edition>>(editions, EditionConstants.AddressFound);
        }

        public IDataResult<List<Edition>> GetByEditionInCountryName(string countryName)
        {
            IDataResult<List<Country>> country = _countryService.GetByNames(countryName);
            if (!country.Success)
                return new ErrorDataResult<List<Edition>>(country.Message);

            List<Edition> editions = _editionDal.GetAll(e => e.Publisher.Address.Country.CountryName.Contains(countryName) && !e.IsDeleted).ToList();
            return editions == null
                ? new ErrorDataResult<List<Edition>>(EditionConstants.AddressNotFound)
                : new SuccessDataResult<List<Edition>>(editions, EditionConstants.AddressFound);
        }

        public IDataResult<List<Edition>> GetByEditionInCountryCode(string countryCode)
        {
            IDataResult<List<Country>> country = _countryService.GetByCountryCodes(countryCode);
            if (!country.Success)
                return new ErrorDataResult<List<Edition>>(country.Message);

            List<Edition> editions = _editionDal.GetAll(e => e.Publisher.Address.Country.CountryCode.Contains(countryCode) && !e.IsDeleted).ToList();
            return editions == null
                ? new ErrorDataResult<List<Edition>>(EditionConstants.AddressNotFound)
                : new SuccessDataResult<List<Edition>>(editions, EditionConstants.AddressFound);
        }

        public IDataResult<List<Edition>> GetByEditionInCityId(int cityId)
        {
            IDataResult<City> result = _cityService.GetById(cityId);
            if (!result.Success)
                return new ErrorDataResult<List<Edition>>(result.Message);

            List<Edition> editions = _editionDal.GetAll(e => e.Publisher.Address.City.Id == cityId && !e.IsDeleted).ToList();
            return editions == null
                ? new ErrorDataResult<List<Edition>>(EditionConstants.AddressNotFound)
                : new SuccessDataResult<List<Edition>>(editions, EditionConstants.AddressFound);
        }

        public IDataResult<List<Edition>> GetByEditionInCityName(string cityName)
        {
            IDataResult<List<City>> result = _cityService.GetByNames(cityName);
            if (!result.Success)
                return new ErrorDataResult<List<Edition>>(result.Message);

            List<Edition> editions = _editionDal.GetAll(c => c.Publisher.Address.City.CityName.Contains(cityName) && !c.IsDeleted).ToList();

            return editions == null
                ? new ErrorDataResult<List<Edition>>(EditionConstants.AddressNotFound)
                : new SuccessDataResult<List<Edition>>(editions, EditionConstants.AddressFound);
        }

        public IDataResult<List<Edition>> GetByEditionInPostalCode(string postalCode)
        {
            List<Edition> editions = _editionDal.GetAll(e => e.Publisher.Address.PostalCode.Contains(postalCode) && !e.IsDeleted).ToList();

            return editions == null
                ? new ErrorDataResult<List<Edition>>(EditionConstants.AddressNotFound)
                : new SuccessDataResult<List<Edition>>(editions, EditionConstants.AddressFound);
        }

        public IDataResult<List<Edition>> GetByEditionInGeoLocation(string geoLoc)
        {
            List<Edition> editions = _editionDal.GetAll(e => e.Publisher.Address.PostalCode.Contains(geoLoc) && !e.IsDeleted).ToList();
            return editions == null
                ? new ErrorDataResult<List<Edition>>(EditionConstants.AddressNotFound)
                : new SuccessDataResult<List<Edition>>(editions, EditionConstants.AddressFound);
        }

        public IDataResult<Edition> GetByCommunicationId(Guid commId)
        {
            Edition edition = _editionDal.Get(c => c.Publisher.Communication.Id == commId && !c.IsDeleted);
            return edition == null
                ? new ErrorDataResult<Edition>(EditionConstants.DataNotGet)
                : new SuccessDataResult<Edition>(edition, EditorConstants.DataGet);
        }

        public IDataResult<List<Edition>> GetByCommunicationName(string commName)
        {
            List<Edition> editions = _editionDal.GetAll(c => c.Publisher.Communication.CommunicationName.Contains(commName) && !c.IsDeleted).ToList();
            return editions == null
                ? new ErrorDataResult<List<Edition>>(EditionConstants.DataNotGet)
                : new SuccessDataResult<List<Edition>>(editions, EditorConstants.DataGet);
        }

        public IDataResult<Edition> GetByCommunicationPhone(string commPhone)
        {
            Edition edition = _editionDal.Get(c => c.Publisher.Communication.PhoneNumber.Contains(commPhone) && !c.Publisher.IsDeleted);
            return edition == null
                ? new ErrorDataResult<Edition>(EditionConstants.PhoneNumberNotGet)
                : new SuccessDataResult<Edition>(edition, EditionConstants.PhoneNumberGet);
        }

        public IDataResult<Edition> GetByCommunicationFaxNumber(string commFaxNumber)
        {
            Edition edition = _editionDal.Get(c => c.Publisher.Communication.FaxNumber.Contains(commFaxNumber) && !c.IsDeleted);
            return edition == null
                ? new ErrorDataResult<Edition>(EditionConstants.PhoneNumberNotGet)
                : new SuccessDataResult<Edition>(edition, EditionConstants.PhoneNumberGet);
        }

        public IDataResult<Edition> GetByCommunicationEmail(string commEmail)
        {
            Edition edition = _editionDal.Get(c => c.Publisher.Communication.Email == commEmail && !c.IsDeleted);
            return edition == null
                ? new ErrorDataResult<Edition>(EditionConstants.DataNotGet)
                : new SuccessDataResult<Edition>(edition, EditionConstants.DataGet);
        }

        public IDataResult<Edition> GetByCommunicationWebSite(string commWebSite)
        {
            Edition edition = _editionDal.Get(c => c.Publisher.Communication.WebSite.Contains(commWebSite) && !c.IsDeleted);
            return edition == null
                ? new ErrorDataResult<Edition>(EditionConstants.DataNotGetWebSites)
                : new SuccessDataResult<Edition>(edition, EditionConstants.DataGetWebSites);
        }

        public IDataResult<Edition> GetByPublisherId(Guid publisherId)
        {
            Edition edition = _editionDal.Get(e => e.Publisher.Id == publisherId && !e.IsDeleted);
            return edition == null
                ? new ErrorDataResult<Edition>(EditionConstants.DataNotGet)
                : new SuccessDataResult<Edition>(edition, EditionConstants.DataGet);
        }

        public IDataResult<List<Edition>> GetByDateOfPublication(DateTime dateOfPublication)
        {
            List<Edition> editions = _editionDal.GetAll(e => e.Publisher.DateOfPublication == dateOfPublication).ToList();
            return editions == null
                ? new ErrorDataResult<List<Edition>>(EditionConstants.DataNotGet)
                : new ErrorDataResult<List<Edition>>(editions, EditionConstants.DataGet);
        }

        public IDataResult<List<Edition>> GetByDateOfPublicationMinMax(DateTime minDate, DateTime maxDate)
        {
            List<Edition> editions = _editionDal.GetAll(c => c.Publisher.DateOfPublication > minDate && c.Publisher.DateOfPublication < maxDate && !c.IsDeleted).ToList();
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
            List<Edition> editions = _editionDal.GetAll(e => e.Name.Contains(name) && !e.IsDeleted).ToList();

            return editions == null
                ? new ErrorDataResult<List<Edition>>(EditionConstants.DataNotGet)
                : new SuccessDataResult<List<Edition>>(editions, EditionConstants.DataGet);
        }

        public IDataResult<List<Edition>> GetAllByFilter(Expression<Func<Edition, bool>>? filter = null)
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
            bool result = _editionDal.GetAll(e =>
               e.Name.Equals(edition.Name)
            && e.Publisher.Address.Equals(edition.Publisher.Address)
            && e.Publisher.DateOfPublication.Equals(edition.Publisher.DateOfPublication)
            && e.EditionNumber.Equals(edition.EditionNumber)).Any();

            return result
                ? new ErrorResult(EditionConstants.EditionEquals)
                : new SuccessResult(PublisherConstants.AllDataGet);
        }
    }
}
