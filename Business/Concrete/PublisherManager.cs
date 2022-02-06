using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
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


        [ValidationAspect(typeof(PublisherValidator), Priority = 1)]
        public IResult Add(Publisher publisher)
        {
            IResult result = BusinessRules.Run(PublisherControl(publisher));
            if (result != null)
                return result;

            _publisherDal.Add(publisher);
            return new SuccessResult(PublisherConstants.AddSuccess);
        }

        public IResult Delete(Publisher publisher)
        {
            _publisherDal.Delete(publisher);
            return new SuccessResult(PublisherConstants.DeleteSuccess);
        }

        public IResult Update(Publisher publisher)
        {
            _publisherDal.Update(publisher);
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
                ? new ErrorDataResult<List<Publisher>>(PublisherConstants.DataNotGetWebSites+ ", " + PublisherConstants.AddressLengthLess)
                : new SuccessDataResult<List<Publisher>>(publishers, PublisherConstants.DataGetWebSites );
        }

        public IDataResult<List<Publisher>> GetList()
        {
            return new SuccessDataResult<List<Publisher>>((List<Publisher>)_publisherDal.GetAll(f => !f.IsDeleted), PublisherConstants.AllDataGet);
        }

        private IResult PublisherControl(Publisher publisher)
        {
            bool result = _publisherDal.GetAll(p =>
               p.Name.ToLowerInvariant().Equals(publisher.Name.ToLowerInvariant())
            && p.Address.ToLowerInvariant().Contains(publisher.Address.ToLowerInvariant())
            && p.PhoneNumber.Equals(publisher.PhoneNumber)
            && p.DateOfPublication.Equals(publisher.DateOfPublication)
            && p.WebSite.ToLower().Contains(publisher.WebSite.ToLower())).Any();

            return result
                ? new ErrorResult(PublisherConstants.PublisherEquals)
                : new SuccessResult(PublisherConstants.AllDataGet);
        }
    }
}
