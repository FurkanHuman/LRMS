using Business.Abstract;
using Business.Constants;
using Business.ServiceCollection.Abstract;
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
    public class PublisherManager : IPublisherService // todo Write
    {
        private readonly IPublisherDal _publisherDal;
        private readonly IEditionServiceCollection _editionServiceCollection; // ı solve then
        
        private readonly IAddressService _addressService;
        private readonly ICountryService _countryService;
        private readonly ICityService _cityService;
        private readonly ICommunicationService _communicationService;
        
        
        public PublisherManager(IPublisherDal publisherDal, IAddressService addressService, ICountryService countryService, ICityService cityService, ICommunicationService communicationService)
        {
            _publisherDal = publisherDal;
            _addressService = addressService;
            _countryService = countryService;
            _cityService = cityService;
            _communicationService = communicationService;
        }

        public PublisherManager(IPublisherDal publisherDal, IEditionServiceCollection editionServiceCollection)
        {
            _publisherDal = publisherDal;
            _editionServiceCollection = editionServiceCollection;
        }

        [ValidationAspect(typeof(PublisherValidator), Priority = 1)]
        public IResult Add(Publisher publisher)
        {
            IResult result = BusinessRules.Run(PublisherControl(publisher));
            if (result != null)
                return result;

            publisher.IsDeleted = false;
            _publisherDal.Add(publisher);
            return new SuccessResult(PublisherConstants.AddSuccess);
        }

        public IResult Delete(Guid id)
        {
            Publisher publisher = _publisherDal.Get(p => p.Id == id);
            if (publisher == null)
                return new ErrorResult(PublisherConstants.NotMatch);

            _publisherDal.Delete(publisher);
            return new SuccessResult(PublisherConstants.DeleteSuccess);
        }
        public IResult ShadowDelete(Guid id)
        {
            Publisher publisher = _publisherDal.Get(p => p.Id == id);
            if (publisher == null)
                return new ErrorResult(PublisherConstants.NotMatch);

            publisher.IsDeleted = true;
            _publisherDal.Update(publisher);
            return new SuccessResult(PublisherConstants.ShadowDeleteSuccess);
        }

        public IResult Update(Publisher publisher)
        {
            _publisherDal.Update(publisher);
            return new SuccessResult(PublisherConstants.UpdateSuccess);
        }

        public IDataResult<Publisher> GetById(Guid id)
        {
            Publisher publisher = _publisherDal.Get(f => f.Id == id && !f.IsDeleted);
            return publisher == null
                ? new ErrorDataResult<Publisher>(PublisherConstants.IdNotFound)
                : new SuccessDataResult<Publisher>(publisher, PublisherConstants.IdFound);
        }

        public IDataResult<List<Publisher>> GetByNames(string name)
        {
            List<Publisher> publishers = _publisherDal.GetAll(p => p.Name.Contains(name )).ToList();
            return publishers == null
                 ? new ErrorDataResult<List<Publisher>>(PublisherConstants.NotMatch)
                 : new SuccessDataResult<List<Publisher>>(publishers, PublisherConstants.DataGet);
        }

        public IDataResult<Publisher> GetByAdderssId(Guid addressId)
        {
            IDataResult<Address> address = _addressService.GetById(addressId);
            if (!address.Success)
                return new ErrorDataResult<Publisher>(address.Message);

            Publisher publisher = _publisherDal.Get(p => p.Address == address && p.IsDeleted);
            return publisher == null
                ? new ErrorDataResult<Publisher>(PublisherConstants.DataNotGet)
                : new SuccessDataResult<Publisher>(publisher, PublisherConstants.DataGet);
        }

        public IDataResult<List<Publisher>> GetByPublisherInCountryId(int countryId)
        {   // third way.todo
            IDataResult<Country> country = _countryService.GetById(countryId);
            if (!country.Success)
                return new ErrorDataResult<List<Publisher>>(country.Message);

            List<Publisher> publishers = _publisherDal.GetAll(p => p.Address.Country == country && !p.IsDeleted).ToList();
            return publishers == null
                ? new ErrorDataResult<List<Publisher>>(PublisherConstants.AddressNotFound)
                : new SuccessDataResult<List<Publisher>>(publishers, PublisherConstants.AddressFound);
        }

        public IDataResult<List<Publisher>> GetByAddressName(string addressName)
        {
            IDataResult<List<Address>> addresses = _addressService.GetByNames(addressName);
            if (!addresses.Success)
                return new ErrorDataResult<List<Publisher>>(addresses.Message);

            List<Publisher> publishers = _publisherDal.GetAll(p => p.Address == addresses && p.IsDeleted).ToList();
            return publishers == null
                ? new ErrorDataResult<List<Publisher>>(PublisherConstants.AddressNotFound)
                : new SuccessDataResult<List<Publisher>>(publishers, PublisherConstants.AddressFound);
        }

        public IDataResult<List<Publisher>> GetByAddressLines(string addressLine)
        {
            IDataResult<List<Address>> addresses = _addressService.GetBySearchString(addressLine);
            if (!addresses.Success)
                return new ErrorDataResult<List<Publisher>>(addresses.Message);

            List<Publisher> publishers = _publisherDal.GetAll(p => p.Address == addresses && p.IsDeleted).ToList();
            return publishers == null
                ? new ErrorDataResult<List<Publisher>>(PublisherConstants.AddressNotFound)
                : new SuccessDataResult<List<Publisher>>(publishers, PublisherConstants.AddressFound);
        }

        public IDataResult<List<Publisher>> GetByPublisherInCountryName(string countryName)
        {
            IDataResult<List<Country>> countrys = _countryService.GetByNames(countryName);
            if (!countrys.Success)
                return new ErrorDataResult<List<Publisher>>(countrys.Message);

            List<Publisher> publishers = _publisherDal.GetAll(p => p.Address.Country == countrys && p.IsDeleted).ToList();
            return publishers == null
                ? new ErrorDataResult<List<Publisher>>(PublisherConstants.AddressNotFound)
                : new SuccessDataResult<List<Publisher>>(publishers, PublisherConstants.AddressFound);
        }

        public IDataResult<List<Publisher>> GetByPublisherInCountryCode(string countryCode)
        {
            IDataResult<List<Country>> countrys = _countryService.GetByCountryCodes(countryCode);
            if (!countrys.Success)
                return new ErrorDataResult<List<Publisher>>(countrys.Message);

            List<Publisher> publishers = _publisherDal.GetAll(p => p.Address.Country == countrys && p.IsDeleted).ToList();
            return publishers == null
                ? new ErrorDataResult<List<Publisher>>(PublisherConstants.DataNotGet)
                : new SuccessDataResult<List<Publisher>>(publishers, PublisherConstants.DataGet);
        }

        public IDataResult<List<Publisher>> GetByPublisherInCityId(int cityId)
        {
            IDataResult<City> city = _cityService.GetById(cityId);
            if (!city.Success)
                return new ErrorDataResult<List<Publisher>>(city.Message);

            List<Publisher> publishers = _publisherDal.GetAll(p => p.Address.City == city && p.IsDeleted).ToList();
            return publishers == null
                ? new ErrorDataResult<List<Publisher>>(PublisherConstants.DataNotGet)
                : new SuccessDataResult<List<Publisher>>(publishers, PublisherConstants.DataGet);
        }

        public IDataResult<List<Publisher>> GetByPublisherInCityName(string cityName)
        {
            IDataResult<List<City>> cities = _cityService.GetByNames(cityName);
            if (!cities.Success)
                return new ErrorDataResult<List<Publisher>>(cities.Message);

            List<Publisher> publishers = _publisherDal.GetAll(p => p.Address.City == cities && !p.IsDeleted).ToList();
            return publishers == null
                ? new ErrorDataResult<List<Publisher>>(PublisherConstants.AddressNotFound)
                : new SuccessDataResult<List<Publisher>>(publishers, PublisherConstants.AddressFound);
        }

        public IDataResult<List<Publisher>> GetByPublisherInPostalCode(string postalCode)
        {   // run??
            List<Publisher> publishers = _publisherDal.GetAll(p => p.Address.PostalCode.Contains(postalCode)  && !p.IsDeleted).ToList();

            return publishers == null
                ? new ErrorDataResult<List<Publisher>>(PublisherConstants.AddressNotFound)
                : new SuccessDataResult<List<Publisher>>(publishers, PublisherConstants.AddressFound);
        }

        public IDataResult<List<Publisher>> GetByPublisherInGeoLocation(string geoLoc)
        {
            List<Publisher> publishers = _publisherDal.GetAll(p => p.Address.GeoLocation.Contains(geoLoc)  && !p.IsDeleted).ToList();

            return publishers == null
                ? new ErrorDataResult<List<Publisher>>(PublisherConstants.AddressNotFound)
                : new SuccessDataResult<List<Publisher>>(publishers, PublisherConstants.AddressFound);
        }

        public IDataResult<Publisher> GetByCommunicationId(Guid commId)
        {
            IDataResult<Communication> comm = _communicationService.GetById(commId);
            if (!comm.Success)
                return new ErrorDataResult<Publisher>(comm.Message);

            Publisher publisher = _publisherDal.Get(p => p.Communication == comm && p.IsDeleted);
            return publisher == null
                ? new ErrorDataResult<Publisher>(PublisherConstants.DataNotGet)
                : new SuccessDataResult<Publisher>(publisher, PublisherConstants.DataGet);

        }

        public IDataResult<List<Publisher>> GetByCommunicationName(string commName)
        {
            IDataResult<List<Communication>> commNames = _communicationService.GetByNames(commName);
            if (!commNames.Success)
                return new ErrorDataResult<List<Publisher>>(commNames.Message);

            List<Publisher> publishers = new();

            foreach (Communication comm in commNames.Data)
            {
                Publisher publisher = _publisherDal.Get(p => p.Communication == comm && !p.IsDeleted);
                if (publisher != null)
                    publishers.Add(publisher);
            }

            return publishers == null
                ? new ErrorDataResult<List<Publisher>>(CommunicationConstants.DataNotGet)
                : new SuccessDataResult<List<Publisher>>(publishers, CommunicationConstants.DataGet);
        }

        public IDataResult<Publisher> GetByCommunicationPhone(string commPhone)
        {
            IDataResult<Communication> comm = _communicationService.GetByPhoneNumber(commPhone);
            if (!comm.Success)
                return new ErrorDataResult<Publisher>(comm.Message);

            Publisher publisher = _publisherDal.Get(p => p.Communication == comm && p.IsDeleted);
            return publisher == null
                ? new ErrorDataResult<Publisher>(PublisherConstants.DataNotGet)
                : new SuccessDataResult<Publisher>(publisher, PublisherConstants.DataGet);
        }

        public IDataResult<Publisher> GetByCommunicationFaxNumber(string commFaxNumber)
        {
            IDataResult<Communication> comm = _communicationService.GetbyFaxNumber(commFaxNumber);
            if (!comm.Success)
                return new ErrorDataResult<Publisher>(comm.Message);

            Publisher publisher = _publisherDal.Get(p => p.Communication == comm && p.IsDeleted);
            return publisher == null
                ? new ErrorDataResult<Publisher>(PublisherConstants.DataNotGet)
                : new SuccessDataResult<Publisher>(publisher, PublisherConstants.DataGet);
        }

        public IDataResult<Publisher> GetByCommunicationEmail(string commEmail)
        {
            IDataResult<Communication> comm = _communicationService.GetByEmail(commEmail);
            if (!comm.Success)
                return new ErrorDataResult<Publisher>(comm.Message);

            Publisher publisher = _publisherDal.Get(p => p.Communication == comm && p.IsDeleted);
            return publisher == null
                ? new ErrorDataResult<Publisher>(PublisherConstants.DataNotGet)
                : new SuccessDataResult<Publisher>(publisher, PublisherConstants.DataGet);
        }

        public IDataResult<Publisher> GetByCommunicationWebSite(string commWebSite)
        {
            IDataResult<Communication> comm = _communicationService.GetByWebSite(commWebSite);
            if (!comm.Success)
                return new ErrorDataResult<Publisher>(comm.Message);

            Publisher publisher = _publisherDal.Get(p => p.Communication == comm && p.IsDeleted);
            return publisher == null
                ? new ErrorDataResult<Publisher>(PublisherConstants.DataNotGet)
                : new SuccessDataResult<Publisher>(publisher, PublisherConstants.DataGet);
        }

        public IDataResult<List<Publisher>> GetByDateOfPublication(DateTime dateOfPublication)
        {
            List<Publisher> publishers = _publisherDal.GetAll(p => p.DateOfPublication == dateOfPublication && !p.IsDeleted).ToList();

            return publishers == null
                ? new ErrorDataResult<List<Publisher>>(PublisherConstants.DataNotGet)
                : new SuccessDataResult<List<Publisher>>(publishers, PublisherConstants.DataGet);
        }

        public IDataResult<List<Publisher>> GetByDateOfPublicationMinMax(DateTime minDate, DateTime maxDate)
        {
            List<Publisher> publishers = _publisherDal.GetAll(p => p.DateOfPublication >= minDate && p.DateOfPublication <= maxDate && !p.IsDeleted).ToList();

            return publishers == null
                ? new ErrorDataResult<List<Publisher>>(PublisherConstants.DataNotGet)
                : new SuccessDataResult<List<Publisher>>(publishers, PublisherConstants.DataGet);
        }

        public IDataResult<List<Publisher>> GetByFilterLists(Expression<Func<Publisher, bool>>? filter = null)
        {
            return new SuccessDataResult<List<Publisher>>(_publisherDal.GetAll(filter).ToList(), PublisherConstants.DataGet);
        }

        public IDataResult<List<Publisher>> GetAll()
        {
            return new SuccessDataResult<List<Publisher>>(_publisherDal.GetAll(p => !p.IsDeleted).ToList(), PublisherConstants.DataGet);
        }

        public IDataResult<List<Publisher>> GetAllBySecrets()
        {
            return new SuccessDataResult<List<Publisher>>(_publisherDal.GetAll(p => p.IsDeleted).ToList(), PublisherConstants.DataGet);
        }

        private IResult PublisherControl(Publisher publisher)
        {
            // fix it Todo
            bool result = _publisherDal.GetAll(p =>
               p.Name.Contains(publisher.Name) 
            && p.DateOfPublication.Equals(publisher.DateOfPublication)).Any();

            return result
                ? new ErrorResult(PublisherConstants.PublisherEquals)
                : new SuccessResult(PublisherConstants.AllDataGet);
        }
    }
}
