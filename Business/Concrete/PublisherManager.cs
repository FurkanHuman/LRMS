namespace Business.Concrete
{
    public class PublisherManager : IPublisherService // todo reWrite
    {
        private readonly IPublisherDal _publisherDal;
        private readonly IFacadeService _facadeService;

        public PublisherManager(IPublisherDal publisherDal)
        {
            _publisherDal = publisherDal;
        }

        // ı solve then   http://www.canertosuner.com/post/constructor-injection-hell-ioc     ınjection ile constructor injection yapılır.
        // https://www.linkedin.com/pulse/yaz%C4%B1l%C4%B1mc%C4%B1n%C4%B1n-gizli-kabusu-constructor-injection-cehennemi-kerem-varis/?originalSubdomain=tr - Kerem Varış


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

        public IDataResult<IList<Publisher>> GetAllByIds(Guid[] ids)
        {
            IList<Publisher> publishers = _publisherDal.GetAll(p => ids.Contains(p.Id) && !p.IsDeleted);
            return publishers == null
                 ? new ErrorDataResult<IList<Publisher>>(PublisherConstants.NotMatch)
                 : new SuccessDataResult<IList<Publisher>>(publishers, PublisherConstants.DataGet);
        }

        public IDataResult<IList<Publisher>> GetAllByName(string name)
        {
            IList<Publisher> publishers = _publisherDal.GetAll(p => p.Name.Contains(name));
            return publishers == null
                 ? new ErrorDataResult<IList<Publisher>>(PublisherConstants.NotMatch)
                 : new SuccessDataResult<IList<Publisher>>(publishers, PublisherConstants.DataGet);
        }

        public IDataResult<Publisher> GetByAddressId(Guid addressId)
        {
            IDataResult<Address> address = _facadeService.AddressService().GetById(addressId);
            if (!address.Success)
                return new ErrorDataResult<Publisher>(address.Message);

            Publisher publisher = _publisherDal.Get(p => p.Address == address && p.IsDeleted);
            return publisher == null
                ? new ErrorDataResult<Publisher>(PublisherConstants.DataNotGet)
                : new SuccessDataResult<Publisher>(publisher, PublisherConstants.DataGet);
        }

        public IDataResult<IList<Publisher>> GetAllByPublisherInCountryId(int countryId)
        {   // third way.todo
            IDataResult<Country> country = _facadeService.CountryService().GetById(countryId);
            if (!country.Success)
                return new ErrorDataResult<IList<Publisher>>(country.Message);

            IList<Publisher> publishers = _publisherDal.GetAll(p => p.Address.Country == country && !p.IsDeleted);
            return publishers == null
                ? new ErrorDataResult<IList<Publisher>>(PublisherConstants.AddressNotFound)
                : new SuccessDataResult<IList<Publisher>>(publishers, PublisherConstants.AddressFound);
        }

        public IDataResult<IList<Publisher>> GetAllByAddressName(string addressName)
        {
            IDataResult<IList<Address>> addresses = _facadeService.AddressService().GetAllByName(addressName);
            if (!addresses.Success)
                return new ErrorDataResult<IList<Publisher>>(addresses.Message);

            IList<Publisher> publishers = _publisherDal.GetAll(p => p.Address == addresses && p.IsDeleted);
            return publishers == null
                ? new ErrorDataResult<IList<Publisher>>(PublisherConstants.AddressNotFound)
                : new SuccessDataResult<IList<Publisher>>(publishers, PublisherConstants.AddressFound);
        }

        public IDataResult<IList<Publisher>> GetAllByAddressLine(string addressLine)
        {
            IDataResult<IList<Address>> addresses = _facadeService.AddressService().GetAllBySearchString(addressLine);
            if (!addresses.Success)
                return new ErrorDataResult<IList<Publisher>>(addresses.Message);

            IList<Publisher> publishers = _publisherDal.GetAll(p => p.Address == addresses && p.IsDeleted);
            return publishers == null
                ? new ErrorDataResult<IList<Publisher>>(PublisherConstants.AddressNotFound)
                : new SuccessDataResult<IList<Publisher>>(publishers, PublisherConstants.AddressFound);
        }

        public IDataResult<IList<Publisher>> GetAllByPublisherInCountryName(string countryName)
        {
            IDataResult<IList<Country>> countrys = _facadeService.CountryService().GetAllByName(countryName);
            if (!countrys.Success)
                return new ErrorDataResult<IList<Publisher>>(countrys.Message);

            IList<Publisher> publishers = _publisherDal.GetAll(p => p.Address.Country == countrys && p.IsDeleted);
            return publishers == null
                ? new ErrorDataResult<IList<Publisher>>(PublisherConstants.AddressNotFound)
                : new SuccessDataResult<IList<Publisher>>(publishers, PublisherConstants.AddressFound);
        }

        public IDataResult<IList<Publisher>> GetAllByPublisherInCountryCode(string countryCode)
        {
            IDataResult<IList<Country>> countrys = _facadeService.CountryService().GetAllByCountryCode(countryCode);
            if (!countrys.Success)
                return new ErrorDataResult<IList<Publisher>>(countrys.Message);

            IList<Publisher> publishers = _publisherDal.GetAll(p => p.Address.Country == countrys && p.IsDeleted);
            return publishers == null
                ? new ErrorDataResult<IList<Publisher>>(PublisherConstants.DataNotGet)
                : new SuccessDataResult<IList<Publisher>>(publishers, PublisherConstants.DataGet);
        }

        public IDataResult<IList<Publisher>> GetAllByPublisherInCityId(int cityId)
        {
            IDataResult<City> city = _facadeService.CityService().GetById(cityId);
            if (!city.Success)
                return new ErrorDataResult<IList<Publisher>>(city.Message);

            IList<Publisher> publishers = _publisherDal.GetAll(p => p.Address.City == city && p.IsDeleted);
            return publishers == null
                ? new ErrorDataResult<IList<Publisher>>(PublisherConstants.DataNotGet)
                : new SuccessDataResult<IList<Publisher>>(publishers, PublisherConstants.DataGet);
        }

        public IDataResult<IList<Publisher>> GetAllByPublisherInCityName(string cityName)
        {
            IDataResult<IList<City>> cities = _facadeService.CityService().GetAllByName(cityName);
            if (!cities.Success)
                return new ErrorDataResult<IList<Publisher>>(cities.Message);

            IList<Publisher> publishers = _publisherDal.GetAll(p => p.Address.City == cities && !p.IsDeleted);
            return publishers == null
                ? new ErrorDataResult<IList<Publisher>>(PublisherConstants.AddressNotFound)
                : new SuccessDataResult<IList<Publisher>>(publishers, PublisherConstants.AddressFound);
        }

        public IDataResult<IList<Publisher>> GetAllByPublisherInPostalCode(string postalCode)
        {   // run??
            IList<Publisher> publishers = _publisherDal.GetAll(p => p.Address.PostalCode.Contains(postalCode) && !p.IsDeleted);

            return publishers == null
                ? new ErrorDataResult<IList<Publisher>>(PublisherConstants.AddressNotFound)
                : new SuccessDataResult<IList<Publisher>>(publishers, PublisherConstants.AddressFound);
        }

        public IDataResult<IList<Publisher>> GetAllByPublisherInGeoLocation(string geoLoc)
        {
            IList<Publisher> publishers = _publisherDal.GetAll(p => p.Address.GeoLocation.Contains(geoLoc) && !p.IsDeleted);

            return publishers == null
                ? new ErrorDataResult<IList<Publisher>>(PublisherConstants.AddressNotFound)
                : new SuccessDataResult<IList<Publisher>>(publishers, PublisherConstants.AddressFound);
        }

        public IDataResult<Publisher> GetByCommunicationId(Guid commId)
        {
            IDataResult<Communication> comm = _facadeService.CommunicationService().GetById(commId);
            if (!comm.Success)
                return new ErrorDataResult<Publisher>(comm.Message);

            Publisher publisher = _publisherDal.Get(p => p.Communication == comm && p.IsDeleted);
            return publisher == null
                ? new ErrorDataResult<Publisher>(PublisherConstants.DataNotGet)
                : new SuccessDataResult<Publisher>(publisher, PublisherConstants.DataGet);

        }

        public IDataResult<IList<Publisher>> GetAllByCommunicationName(string commName)
        {
            IDataResult<IList<Communication>> commNames = _facadeService.CommunicationService().GetAllByName(commName);
            if (!commNames.Success)
                return new ErrorDataResult<IList<Publisher>>(commNames.Message);

            List<Publisher> publishers = new();

            foreach (Communication comm in commNames.Data)
            {
                Publisher publisher = _publisherDal.Get(p => p.Communication == comm && !p.IsDeleted);
                if (publisher != null)
                    publishers.Add(publisher);
            }

            return publishers == null
                ? new ErrorDataResult<IList<Publisher>>(CommunicationConstants.DataNotGet)
                : new SuccessDataResult<IList<Publisher>>(publishers, CommunicationConstants.DataGet);
        }

        public IDataResult<Publisher> GetByCommunicationPhone(string commPhone)
        {
            IDataResult<Communication> comm = _facadeService.CommunicationService().GetByPhoneNumber(commPhone);
            if (!comm.Success)
                return new ErrorDataResult<Publisher>(comm.Message);

            Publisher publisher = _publisherDal.Get(p => p.Communication == comm && p.IsDeleted);
            return publisher == null
                ? new ErrorDataResult<Publisher>(PublisherConstants.DataNotGet)
                : new SuccessDataResult<Publisher>(publisher, PublisherConstants.DataGet);
        }

        public IDataResult<Publisher> GetByCommunicationFaxNumber(string commFaxNumber)
        {
            IDataResult<Communication> comm = _facadeService.CommunicationService().GetByFaxNumber(commFaxNumber);
            if (!comm.Success)
                return new ErrorDataResult<Publisher>(comm.Message);

            Publisher publisher = _publisherDal.Get(p => p.Communication == comm && p.IsDeleted);
            return publisher == null
                ? new ErrorDataResult<Publisher>(PublisherConstants.DataNotGet)
                : new SuccessDataResult<Publisher>(publisher, PublisherConstants.DataGet);
        }

        public IDataResult<Publisher> GetByCommunicationEmail(string commEmail)
        {
            IDataResult<Communication> comm = _facadeService.CommunicationService().GetByEmail(commEmail);
            if (!comm.Success)
                return new ErrorDataResult<Publisher>(comm.Message);

            Publisher publisher = _publisherDal.Get(p => p.Communication == comm && p.IsDeleted);
            return publisher == null
                ? new ErrorDataResult<Publisher>(PublisherConstants.DataNotGet)
                : new SuccessDataResult<Publisher>(publisher, PublisherConstants.DataGet);
        }

        public IDataResult<Publisher> GetByCommunicationWebSite(string commWebSite)
        {
            IDataResult<Communication> comm = _facadeService.CommunicationService().GetByWebSite(commWebSite);
            if (!comm.Success)
                return new ErrorDataResult<Publisher>(comm.Message);

            Publisher publisher = _publisherDal.Get(p => p.Communication == comm && p.IsDeleted);
            return publisher == null
                ? new ErrorDataResult<Publisher>(PublisherConstants.DataNotGet)
                : new SuccessDataResult<Publisher>(publisher, PublisherConstants.DataGet);
        }

        public IDataResult<IList<Publisher>> GetAllByDateOfPublication(DateTime dateOfPublication)
        {
            IList<Publisher> publishers = _publisherDal.GetAll(p => p.DateOfPublication == dateOfPublication && !p.IsDeleted);

            return publishers == null
                ? new ErrorDataResult<IList<Publisher>>(PublisherConstants.DataNotGet)
                : new SuccessDataResult<IList<Publisher>>(publishers, PublisherConstants.DataGet);
        }

        public IDataResult<IList<Publisher>> GetAllByDateOfPublicationMinMax(DateTime minDate, DateTime maxDate)
        {
            IList<Publisher> publishers = _publisherDal.GetAll(p => p.DateOfPublication >= minDate && p.DateOfPublication <= maxDate && !p.IsDeleted);

            return publishers == null
                ? new ErrorDataResult<IList<Publisher>>(PublisherConstants.DataNotGet)
                : new SuccessDataResult<IList<Publisher>>(publishers, PublisherConstants.DataGet);
        }

        public IDataResult<IList<Publisher>> GetAllByFilter(Expression<Func<Publisher, bool>>? filter = null)
        {
            return new SuccessDataResult<IList<Publisher>>(_publisherDal.GetAll(filter), PublisherConstants.DataGet);
        }

        public IDataResult<IList<Publisher>> GetAll()
        {
            return new SuccessDataResult<IList<Publisher>>(_publisherDal.GetAll(p => !p.IsDeleted), PublisherConstants.DataGet);
        }

        public IDataResult<IList<Publisher>> GetAllByIsDeleted()
        {
            return new SuccessDataResult<IList<Publisher>>(_publisherDal.GetAll(p => p.IsDeleted), PublisherConstants.DataGet);
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
