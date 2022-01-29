using Business.Abstract;
using Business.Constants;
using Core.Utilities.Business;
using Core.Utilities.Result.Abstract;
using Core.Utilities.Result.Concrete;
using DataAccess.Abstract;
using Entities.Concrete.Infos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            return new ErrorResult(PublisherConstants.DevNotes);
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
            List<Publisher> publishers = _publisherDal.GetAll(a => a.Address.ToLower().Contains(address.ToLower()) && a.Address.Length >= addressSearchLength).ToList();
            return publishers == null
                ? new ErrorDataResult<List<Publisher>>(PublisherConstants.AddressNotFound + ", " + PublisherConstants.AddressLengthLess)
                : new SuccessDataResult<List<Publisher>>(publishers, PublisherConstants.AddressFound);
        }

        public IDataResult<Publisher?> GetByFaxNumber(ulong faxNumber)
        {
            Publisher? publisher = _publisherDal.Get(a => a.FaxNumber == faxNumber);
            return publisher == null
                ? new ErrorDataResult<Publisher?>(PublisherConstants.FaxNotFound)
                : new SuccessDataResult<Publisher?>(publisher, PublisherConstants.FaxFound);
        }

        public IDataResult<Publisher> GetById(int id)
        {
            Publisher publisher = _publisherDal.Get(f => f.Id == id);
            return publisher == null
                ? new ErrorDataResult<Publisher>(PublisherConstants.IdNotFound)
                : new SuccessDataResult<Publisher>(publisher, PublisherConstants.IdFound);
        }

        public IDataResult<Publisher> GetByName(string name)
        {
            Publisher publisher = _publisherDal.Get(f => f.Name == name);
            return publisher == null
                ? new ErrorDataResult<Publisher>(PublisherConstants.NameNotGet)
                : new SuccessDataResult<Publisher>(publisher, PublisherConstants.NameDataGet);
        }

        public IDataResult<Publisher> GetByPhoneNumber(ulong phoneNumber)
        {
            Publisher publisher = _publisherDal.Get(f => f.PhoneNumber == phoneNumber);
            return publisher == null
                ? new ErrorDataResult<Publisher>(PublisherConstants.PhoneNumberNotGet)
                : new SuccessDataResult<Publisher>(publisher, PublisherConstants.PhoneNumberGet);
        }

        public IDataResult<List<Publisher>> GetByWebsitess(string webSite)
        {
            List<Publisher> publishers = _publisherDal.GetAll(f => f.WebSite.ToLower().Contains(webSite) && f.WebSite.ToLower().Length >= addressSearchLength).ToList();
            return publishers == null
                ? new ErrorDataResult<List<Publisher>>(PublisherConstants.DataNotGetWebSites)
                : new SuccessDataResult<List<Publisher>>(publishers, PublisherConstants.DataGetWebSites+", "+PublisherConstants.AddressLengthLess);
        }

        public IDataResult<List<Publisher>> GetList()
        {
            return new SuccessDataResult<List<Publisher>>((List<Publisher>)_publisherDal.GetAll(), PublisherConstants.AllDataGet);
        }

        private static IResult PublisherControl(Publisher publisher)
        {
           return new ErrorResult(PublisherConstants.DevNotes);
        }
        private static IResult PublisherUpdateControl(Publisher oldPublisher, Publisher newPublisher)
        {
            return new ErrorResult(PublisherConstants.DevNotes);
        }
    }
}
