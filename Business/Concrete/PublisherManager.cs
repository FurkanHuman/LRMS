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
    public class PublisherManager : IPublisherService // todo reWrite
    {
        private readonly IPublisherDal _publisherDal;
    
        // ı solve then   http://www.canertosuner.com/post/constructor-injection-hell-ioc     ınjection ile constructor injection yapılır.
        // https://www.linkedin.com/pulse/yaz%C4%B1l%C4%B1mc%C4%B1n%C4%B1n-gizli-kabusu-constructor-injection-cehennemi-kerem-varis/?originalSubdomain=tr - Kerem Varış

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

        public IDataResult<List<Publisher>> GetAllByIds(Guid[] ids)
        {
            List<Publisher> publishers = _publisherDal.GetAll(p => ids.Contains(p.Id) && !p.IsDeleted).ToList();
            return publishers == null
                 ? new ErrorDataResult<List<Publisher>>(PublisherConstants.NotMatch)
                 : new SuccessDataResult<List<Publisher>>(publishers, PublisherConstants.DataGet);
        }

        public IDataResult<List<Publisher>> GetAllByName(string name)
        {
            List<Publisher> publishers = _publisherDal.GetAll(p => p.Name.Contains(name)).ToList();
            return publishers == null
                 ? new ErrorDataResult<List<Publisher>>(PublisherConstants.NotMatch)
                 : new SuccessDataResult<List<Publisher>>(publishers, PublisherConstants.DataGet);
        }

        public IDataResult<Publisher> GetByAddressId(Guid addressId)
        {
            IDataResult<Address> address = _addressService.GetById(addressId);
            if (!address.Success)
                return new ErrorDataResult<Publisher>(address.Message);

            Publisher publisher = _publisherDal.Get(p => p.Address == address && p.IsDeleted);
            return publisher == null
                ? new ErrorDataResult<Publisher>(PublisherConstants.DataNotGet)
                : new SuccessDataResult<Publisher>(publisher, PublisherConstants.DataGet);
        }

        public IDataResult<List<Publisher>> GetAllByPublisherInCountryId(int countryId)
        {   // third way.todo
            IDataResult<Country> country = _countryService.GetById(countryId);
            if (!country.Success)
                return new ErrorDataResult<List<Publisher>>(country.Message);

            List<Publisher> publishers = _publisherDal.GetAll(p => p.Address.Country == country && !p.IsDeleted).ToList();
            return publishers == null
                ? new ErrorDataResult<List<Publisher>>(PublisherConstants.AddressNotFound)
                : new SuccessDataResult<List<Publisher>>(publishers, PublisherConstants.AddressFound);
        }

        public IDataResult<List<Publisher>> GetAllByAddressName(string addressName)
        {
            IDataResult<List<Address>> addresses = _addressService.GetAllByName(addressName);
            if (!addresses.Success)
                return new ErrorDataResult<List<Publisher>>(addresses.Message);

            List<Publisher> publishers = _publisherDal.GetAll(p => p.Address == addresses && p.IsDeleted).ToList();
            return publishers == null
                ? new ErrorDataResult<List<Publisher>>(PublisherConstants.AddressNotFound)
                : new SuccessDataResult<List<Publisher>>(publishers, PublisherConstants.AddressFound);
        }

        public IDataResult<List<Publisher>> GetAllByAddressLine(string addressLine)
        {
            IDataResult<List<Address>> addresses = _addressService.GetAllBySearchString(addressLine);
            if (!addresses.Success)
                return new ErrorDataResult<List<Publisher>>(addresses.Message);

            List<Publisher> publishers = _publisherDal.GetAll(p => p.Address == addresses && p.IsDeleted).ToList();
            return publishers == null
                ? new ErrorDataResult<List<Publisher>>(PublisherConstants.AddressNotFound)
                : new SuccessDataResult<List<Publisher>>(publishers, PublisherConstants.AddressFound);
        }

        public IDataResult<List<Publisher>> GetAllByPublisherInCountryName(string countryName)
        {
            IDataResult<List<Country>> countrys = _countryService.GetAllByName(countryName);
            if (!countrys.Success)
                return new ErrorDataResult<List<Publisher>>(countrys.Message);

            List<Publisher> publishers = _publisherDal.GetAll(p => p.Address.Country == countrys && p.IsDeleted).ToList();
            return publishers == null
                ? new ErrorDataResult<List<Publisher>>(PublisherConstants.AddressNotFound)
                : new SuccessDataResult<List<Publisher>>(publishers, PublisherConstants.AddressFound);
        }

        public IDataResult<List<Publisher>> GetAllByPublisherInCountryCode(string countryCode)
        {
            IDataResult<List<Country>> countrys = _countryService.GetAllByCountryCode(countryCode);
            if (!countrys.Success)
                return new ErrorDataResult<List<Publisher>>(countrys.Message);

            List<Publisher> publishers = _publisherDal.GetAll(p => p.Address.Country == countrys && p.IsDeleted).ToList();
            return publishers == null
                ? new ErrorDataResult<List<Publisher>>(PublisherConstants.DataNotGet)
                : new SuccessDataResult<List<Publisher>>(publishers, PublisherConstants.DataGet);
        }

        public IDataResult<List<Publisher>> GetAllByPublisherInCityId(int cityId)
        {
            IDataResult<City> city = _cityService.GetById(cityId);
            if (!city.Success)
                return new ErrorDataResult<List<Publisher>>(city.Message);

            List<Publisher> publishers = _publisherDal.GetAll(p => p.Address.City == city && p.IsDeleted).ToList();
            return publishers == null
                ? new ErrorDataResult<List<Publisher>>(PublisherConstants.DataNotGet)
                : new SuccessDataResult<List<Publisher>>(publishers, PublisherConstants.DataGet);
        }

        public IDataResult<List<Publisher>> GetAllByPublisherInCityName(string cityName)
        {
            IDataResult<List<City>> cities = _cityService.GetAllByName(cityName);
            if (!cities.Success)
                return new ErrorDataResult<List<Publisher>>(cities.Message);

            List<Publisher> publishers = _publisherDal.GetAll(p => p.Address.City == cities && !p.IsDeleted).ToList();
            return publishers == null
                ? new ErrorDataResult<List<Publisher>>(PublisherConstants.AddressNotFound)
                : new SuccessDataResult<List<Publisher>>(publishers, PublisherConstants.AddressFound);
        }

        public IDataResult<List<Publisher>> GetAllByPublisherInPostalCode(string postalCode)
        {   // run??
            List<Publisher> publishers = _publisherDal.GetAll(p => p.Address.PostalCode.Contains(postalCode) && !p.IsDeleted).ToList();

            return publishers == null
                ? new ErrorDataResult<List<Publisher>>(PublisherConstants.AddressNotFound)
                : new SuccessDataResult<List<Publisher>>(publishers, PublisherConstants.AddressFound);
        }

        public IDataResult<List<Publisher>> GetAllByPublisherInGeoLocation(string geoLoc)
        {
            List<Publisher> publishers = _publisherDal.GetAll(p => p.Address.GeoLocation.Contains(geoLoc) && !p.IsDeleted).ToList();

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

        public IDataResult<List<Publisher>> GetAllByCommunicationName(string commName)
        {
            IDataResult<List<Communication>> commNames = _communicationService.GetAllByName(commName);
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
            IDataResult<Communication> comm = _communicationService.GetByFaxNumber(commFaxNumber);
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

        public IDataResult<List<Publisher>> GetAllByDateOfPublication(DateTime dateOfPublication)
        {
            List<Publisher> publishers = _publisherDal.GetAll(p => p.DateOfPublication == dateOfPublication && !p.IsDeleted).ToList();

            return publishers == null
                ? new ErrorDataResult<List<Publisher>>(PublisherConstants.DataNotGet)
                : new SuccessDataResult<List<Publisher>>(publishers, PublisherConstants.DataGet);
        }

        public IDataResult<List<Publisher>> GetAllByDateOfPublicationMinMax(DateTime minDate, DateTime maxDate)
        {
            List<Publisher> publishers = _publisherDal.GetAll(p => p.DateOfPublication >= minDate && p.DateOfPublication <= maxDate && !p.IsDeleted).ToList();

            return publishers == null
                ? new ErrorDataResult<List<Publisher>>(PublisherConstants.DataNotGet)
                : new SuccessDataResult<List<Publisher>>(publishers, PublisherConstants.DataGet);
        }

        public IDataResult<List<Publisher>> GetAllByFilter(Expression<Func<Publisher, bool>>? filter = null)
        {
            return new SuccessDataResult<List<Publisher>>(_publisherDal.GetAll(filter).ToList(), PublisherConstants.DataGet);
        }

        public IDataResult<List<Publisher>> GetAll()
        {
            return new SuccessDataResult<List<Publisher>>(_publisherDal.GetAll(p => !p.IsDeleted).ToList(), PublisherConstants.DataGet);
        }

        public IDataResult<List<Publisher>> GetAllBySecret()
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
