using Business.Abstract;
using Business.Constants;
using Core.Utilities.Business;
using Core.Utilities.Result.Abstract;
using Core.Utilities.Result.Concrete;
using DataAccess.Abstract;
using Entities.Concrete.Infos;

namespace Business.Concrete
{
    public class PublisherManager : IPublisherService
    {
        private const byte addressSearchLength = 5;
        private readonly IPublisherDal _publisherDal;

        public PublisherManager(IPublisherDal publisherDal)
        {
            _publisherDal = publisherDal;
        }

        public IResult Add(Publisher publisher)
        {
            IResult result = BusinessRules.Run(PublisherControl(publisher));
            if (result != null)
                return result;

            _publisherDal.Add(publisher);
            return new SuccessResult(PublisherConstants.AddSucces);
        }

        public IResult Delete(Publisher publisher)
        {
            IResult result = BusinessRules.Run(PublisherControl(publisher));
            if (result != null)
                return result;

            Publisher delPublisher = _publisherDal.Get(u => u.IsDeleted);
            _publisherDal.Delete(delPublisher);
            return new SuccessResult(PublisherConstants.DeleteSuccess);
        }

        public IResult Update(Publisher oldPublisher, Publisher newPublisher)
        {
            IResult result = BusinessRules.Run(PublisherUpdateControl(oldPublisher, newPublisher));
            if (result != null)
                return result;

            oldPublisher = newPublisher;
            _publisherDal.Update(oldPublisher);
            return new SuccessResult(PublisherConstants.UpdateSuccess);
        }

        public IDataResult<List<Publisher>> GetByAddress(string address)
        {
            List<Publisher> publishers = _publisherDal.GetAll(a => a.Address.ToLower().Contains(address.ToLower()) && a.Address.Length >= addressSearchLength && !a.IsDeleted).ToList();
            return publishers == null
                ? new ErrorDataResult<List<Publisher>>(PublisherConstants.AddressNotFound + ", " + PublisherConstants.AddressLengthLess)
                : new SuccessDataResult<List<Publisher>>(publishers, PublisherConstants.AddressFound);
        }

        public IDataResult<Publisher?> GetByFaxNumber(ulong faxNumber)
        {
            Publisher? publisher = _publisherDal.Get(a => a.FaxNumber == faxNumber && !a.IsDeleted);
            return publisher == null
                ? new ErrorDataResult<Publisher?>(PublisherConstants.FaxNotFound)
                : new SuccessDataResult<Publisher?>(publisher, PublisherConstants.FaxFound);
        }

        public IDataResult<Publisher> GetById(int id)
        {
            Publisher publisher = _publisherDal.Get(f => f.Id == id && !f.IsDeleted);
            return publisher == null
                ? new ErrorDataResult<Publisher>(PublisherConstants.IdNotFound)
                : new SuccessDataResult<Publisher>(publisher, PublisherConstants.IdFound);
        }

        public IDataResult<Publisher> GetByName(string name)
        {
            Publisher publisher = _publisherDal.Get(f => f.Name.ToLower() == name.ToLower() && !f.IsDeleted);
            return publisher == null
                ? new ErrorDataResult<Publisher>(PublisherConstants.NameNotGet)
                : new SuccessDataResult<Publisher>(publisher, PublisherConstants.NameDataGet);
        }

        public IDataResult<Publisher> GetByPhoneNumber(ulong phoneNumber)
        {
            Publisher publisher = _publisherDal.Get(f => f.PhoneNumber == phoneNumber && !f.IsDeleted);
            return publisher == null
                ? new ErrorDataResult<Publisher>(PublisherConstants.PhoneNumberNotGet)
                : new SuccessDataResult<Publisher>(publisher, PublisherConstants.PhoneNumberGet);
        }

        public IDataResult<List<Publisher>> GetByWebsitess(string webSite)
        {
            List<Publisher> publishers = _publisherDal.GetAll(f => f.WebSite.ToLower().Contains(webSite)
            && f.WebSite.ToLower().Length >= addressSearchLength && !f.IsDeleted).ToList();
            return publishers == null
                ? new ErrorDataResult<List<Publisher>>(PublisherConstants.DataNotGetWebSites)
                : new SuccessDataResult<List<Publisher>>(publishers, PublisherConstants.DataGetWebSites + ", " + PublisherConstants.AddressLengthLess);
        }

        public IDataResult<List<Publisher>> GetList()
        {
            return new SuccessDataResult<List<Publisher>>((List<Publisher>)_publisherDal.GetAll(f => !f.IsDeleted), PublisherConstants.AllDataGet);
        }

        private static IResult PublisherControl(Publisher publisher)
        {
            if (publisher == null)
                return new ErrorResult(PublisherConstants.PublisherNotNull);
            if (publisher.Name.Equals(null) || publisher.Name.Equals(string.Empty))
                return new ErrorResult(PublisherConstants.PublisherNameNotNull);
            if (publisher.Address.Equals(null) || publisher.Address.Equals(string.Empty))
                return new ErrorResult(PublisherConstants.PublisherAddressNotNull);
            if (publisher.WebSite.Equals(null) || publisher.WebSite.Equals(string.Empty))
                return new ErrorResult(PublisherConstants.PublisherWebAddressNotNull);
            if (((char)publisher.PhoneNumber).Equals(null) || ((char)publisher.PhoneNumber).Equals(string.Empty))
                return new ErrorResult(PublisherConstants.PublisherPhoneNotNull);

            return new SuccessResult();
        }

        private static IResult PublisherUpdateControl(Publisher oldPublisher, Publisher newPublisher)
        {
            return oldPublisher == newPublisher
                ? new ErrorResult(PublisherConstants.PublisherEquals)
                : new SuccessResult();
        }
    }
}
