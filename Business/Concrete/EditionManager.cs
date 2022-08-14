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
    public class EditionManager : IEditionService // todo rewrite
    {
        private readonly IEditionDal _editionDal;
        private readonly IFacadeService _facadeService;

        public EditionManager(IEditionDal editionDal)
        {
            _editionDal = editionDal;
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

        public IDataResult<IList<Edition>> GetAllByIds(Guid[] ids)
        {
            IList<Edition> editions = _editionDal.GetAll(e => ids.Contains(e.Id) && !e.IsDeleted);

            return editions == null
                ? new ErrorDataResult<IList<Edition>>(EditionConstants.AddressNotFound)
                : new SuccessDataResult<IList<Edition>>(editions, AddressConstants.DataGet);
        }

        public IDataResult<Edition> GetByAdderssId(Guid addressId)
        {
            IDataResult<Address> address = _facadeService.AddressService().GetById(addressId);
            if (!address.Success)
                return new ErrorDataResult<Edition>(address.Message);

            Edition edition = _editionDal.Get(e => e.Publisher.Address == address && !e.IsDeleted);

            return edition == null
                ? new ErrorDataResult<Edition>(EditionConstants.AddressNotFound)
                : new SuccessDataResult<Edition>(edition, EditionConstants.AddressFound);
        }

        public IDataResult<IList<Edition>> GetAllByEditionInCountryId(int countryId)
        {
            IList<Edition> editions = _editionDal.GetAll(e => e.Publisher.Address.Country.Id == countryId && !e.IsDeleted);

            return editions == null
                ? new ErrorDataResult<IList<Edition>>(EditionConstants.DataNotGet)
                : new SuccessDataResult<IList<Edition>>(editions, EditionConstants.AllDataGet);
        }

        public IDataResult<IList<Edition>> GetAllByAddressName(string addressName)
        {
            IList<Edition> editions = _editionDal.GetAll(e => e.Publisher.Address.AddressName.Contains(addressName) && !e.IsDeleted);

            return editions == null
                ? new ErrorDataResult<IList<Edition>>(EditionConstants.AddressNotFound)
                : new SuccessDataResult<IList<Edition>>(editions, AddressConstants.DataGet);
        }

        public IDataResult<IList<Edition>> GetAllByAddressLine(string addressLine)
        {
            IList<Edition> editions = _editionDal.GetAll(e => (e.Publisher.Address.AddressLine1 + e.Publisher.Address.AddressLine2).Contains(addressLine) && !e.IsDeleted);
            return editions == null
                ? new ErrorDataResult<IList<Edition>>(EditionConstants.AddressNotFound)
                : new SuccessDataResult<IList<Edition>>(editions, EditionConstants.AddressFound);
        }

        public IDataResult<IList<Edition>> GetAllByEditionInCountryName(string countryName)
        {
            IDataResult<IList<Country>> country = _facadeService.CountryService().GetAllByName(countryName);
            if (!country.Success)
                return new ErrorDataResult<IList<Edition>>(country.Message);

            IList<Edition> editions = _editionDal.GetAll(e => e.Publisher.Address.Country.CountryName.Contains(countryName) && !e.IsDeleted);
            return editions == null
                ? new ErrorDataResult<IList<Edition>>(EditionConstants.AddressNotFound)
                : new SuccessDataResult<IList<Edition>>(editions, EditionConstants.AddressFound);
        }

        public IDataResult<IList<Edition>> GetAllByEditionInCountryCode(string countryCode)
        {
            IDataResult<IList<Country>> country = _facadeService.CountryService().GetAllByCountryCode(countryCode);
            if (!country.Success)
                return new ErrorDataResult<IList<Edition>>(country.Message);

            IList<Edition> editions = _editionDal.GetAll(e => e.Publisher.Address.Country.CountryCode.Contains(countryCode) && !e.IsDeleted);
            return editions == null
                ? new ErrorDataResult<IList<Edition>>(EditionConstants.AddressNotFound)
                : new SuccessDataResult<IList<Edition>>(editions, EditionConstants.AddressFound);
        }

        public IDataResult<IList<Edition>> GetAllByEditionInCityId(int cityId)
        {
            IDataResult<City> result = _facadeService.CityService().GetById(cityId);
            if (!result.Success)
                return new ErrorDataResult<IList<Edition>>(result.Message);

            IList<Edition> editions = _editionDal.GetAll(e => e.Publisher.Address.City.Id == cityId && !e.IsDeleted);
            return editions == null
                ? new ErrorDataResult<IList<Edition>>(EditionConstants.AddressNotFound)
                : new SuccessDataResult<IList<Edition>>(editions, EditionConstants.AddressFound);
        }

        public IDataResult<IList<Edition>> GetAllByEditionInCityName(string cityName)
        {
            IDataResult<IList<City>> result = _facadeService.CityService().GetAllByName(cityName);
            if (!result.Success)
                return new ErrorDataResult<IList<Edition>>(result.Message);

            IList<Edition> editions = _editionDal.GetAll(c => c.Publisher.Address.City.CityName.Contains(cityName) && !c.IsDeleted);

            return editions == null
                ? new ErrorDataResult<IList<Edition>>(EditionConstants.AddressNotFound)
                : new SuccessDataResult<IList<Edition>>(editions, EditionConstants.AddressFound);
        }

        public IDataResult<IList<Edition>> GetAllByEditionInPostalCode(string postalCode)
        {
            IList<Edition> editions = _editionDal.GetAll(e => e.Publisher.Address.PostalCode.Contains(postalCode) && !e.IsDeleted);

            return editions == null
                ? new ErrorDataResult<IList<Edition>>(EditionConstants.AddressNotFound)
                : new SuccessDataResult<IList<Edition>>(editions, EditionConstants.AddressFound);
        }

        public IDataResult<IList<Edition>> GetAllByEditionInGeoLocation(string geoLoc)
        {
            IList<Edition> editions = _editionDal.GetAll(e => e.Publisher.Address.PostalCode.Contains(geoLoc) && !e.IsDeleted);
            return editions == null
                ? new ErrorDataResult<IList<Edition>>(EditionConstants.AddressNotFound)
                : new SuccessDataResult<IList<Edition>>(editions, EditionConstants.AddressFound);
        }

        public IDataResult<Edition> GetByCommunicationId(Guid commId)
        {
            Edition edition = _editionDal.Get(c => c.Publisher.Communication.Id == commId && !c.IsDeleted);
            return edition == null
                ? new ErrorDataResult<Edition>(EditionConstants.DataNotGet)
                : new SuccessDataResult<Edition>(edition, EditorConstants.DataGet);
        }

        public IDataResult<IList<Edition>> GetAllByCommunicationName(string commName)
        {
            IList<Edition> editions = _editionDal.GetAll(c => c.Publisher.Communication.CommunicationName.Contains(commName) && !c.IsDeleted);
            return editions == null
                ? new ErrorDataResult<IList<Edition>>(EditionConstants.DataNotGet)
                : new SuccessDataResult<IList<Edition>>(editions, EditorConstants.DataGet);
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

        public IDataResult<IList<Edition>> GetAllByDateOfPublication(DateTime dateOfPublication)
        {
            IList<Edition> editions = _editionDal.GetAll(e => e.Publisher.DateOfPublication == dateOfPublication);
            return editions == null
                ? new ErrorDataResult<IList<Edition>>(EditionConstants.DataNotGet)
                : new ErrorDataResult<IList<Edition>>(editions, EditionConstants.DataGet);
        }

        public IDataResult<IList<Edition>> GetAllByDateOfPublicationMinMax(DateTime minDate, DateTime maxDate)
        {
            IList<Edition> editions = _editionDal.GetAll(c => c.Publisher.DateOfPublication > minDate && c.Publisher.DateOfPublication < maxDate && !c.IsDeleted);
            return editions == null
                ? new ErrorDataResult<IList<Edition>>(EditionConstants.DataNotGet)
                : new SuccessDataResult<IList<Edition>>(editions, EditionConstants.DataGet);
        }

        public IDataResult<IList<Edition>> GetAllByEditionNumber(int eNumber)
        {
            IList<Edition> editions = _editionDal.GetAll(e => e.EditionNumber == eNumber && !e.IsDeleted);

            return editions == null
                ? new ErrorDataResult<IList<Edition>>(EditionConstants.NotMatch)
                : new SuccessDataResult<IList<Edition>>(editions, EditionConstants.DataGet);
        }

        public IDataResult<IList<Edition>> GetAllByName(string name)
        {
            IList<Edition> editions = _editionDal.GetAll(e => e.Name.Contains(name) && !e.IsDeleted);

            return editions == null
                ? new ErrorDataResult<IList<Edition>>(EditionConstants.DataNotGet)
                : new SuccessDataResult<IList<Edition>>(editions, EditionConstants.DataGet);
        }

        public IDataResult<IList<Edition>> GetAllByFilter(Expression<Func<Edition, bool>>? filter = null)
        {
            return new SuccessDataResult<IList<Edition>>(_editionDal.GetAll(filter), EditionConstants.DataGet);
        }

        public IDataResult<IList<Edition>> GetAllByIsDeleted()
        {
            return new SuccessDataResult<IList<Edition>>(_editionDal.GetAll(f => f.IsDeleted), EditionConstants.DataGet);
        }

        public IDataResult<IList<Edition>> GetAll()
        {
            return new SuccessDataResult<IList<Edition>>(_editionDal.GetAll(f => !f.IsDeleted), EditionConstants.DataGet);
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
