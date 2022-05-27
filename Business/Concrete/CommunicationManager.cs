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
    public class CommunicationManager : ICommunicationService
    {
        private readonly ICommunicationDal _communicationDal;
        private readonly IAddressService _addressService;

        public CommunicationManager(ICommunicationDal communicationDal, IAddressService addressService)
        {
            _communicationDal = communicationDal;
            _addressService = addressService;
        }

        [ValidationAspect(typeof(CommunicationValidator), Priority = 1)]
        public IResult Add(Communication communication)
        {
            IResult result = BusinessRules.Run(CommunicationChecker(communication), _addressService.GetById(communication.Address.Id));
            if (result != null)
                return result;

            communication.IsDeleted = false;
            _communicationDal.Add(communication);
            return new SuccessResult();
        }

        public IResult Delete(Guid gId)
        {
            Communication communication = _communicationDal.Get(c => c.Id == gId && !c.IsDeleted);
            if (communication == null)
                return new ErrorResult(CommunicationConstants.NotMatch);

            _communicationDal.Delete(communication);
            return new SuccessResult(CommunicationConstants.DeleteSuccess);
        }

        public IResult ShadowDelete(Guid gId)
        {
            Communication communication = _communicationDal.Get(c => c.Id == gId && !c.IsDeleted);
            if (communication == null)
                return new ErrorResult(CommunicationConstants.NotMatch);

            communication.IsDeleted = true;

            _communicationDal.Update(communication);
            return new SuccessResult(CommunicationConstants.ShadowDeleteSuccess);
        }

        [ValidationAspect(typeof(CommunicationValidator), Priority = 1)]
        public IResult Update(Communication communication)
        {
            IResult result = BusinessRules.Run(CommunicationChecker(communication), _addressService.GetById(communication.Address.Id));
            if (result != null)
                return result;

            _communicationDal.Update(communication);
            return new SuccessResult(CommunicationConstants.UpdateSuccess);
        }

        public IDataResult<Communication> Get(Guid gId)
        {
            Communication communication = _communicationDal.Get(c => c.Id == gId && !c.IsDeleted);

            return communication == null
                ? new ErrorDataResult<Communication>(CommunicationConstants.NotMatch)
                : new SuccessDataResult<Communication>(communication, CommunicationConstants.DataGet);
        }

        public IDataResult<List<Communication>> GetAll()
        {
            return new SuccessDataResult<List<Communication>>(_communicationDal.GetAll(c => !c.IsDeleted).ToList(), CommunicationConstants.DataGet);
        }

        public IDataResult<List<Communication>> GetAllByFilterLists(Expression<Func<Communication, bool>>? filter = null)
        {
            return new SuccessDataResult<List<Communication>>(_communicationDal.GetAll(filter).ToList(), CommunicationConstants.DataGet);
        }

        public IDataResult<Communication> GetByAddressGId(Guid addressgId)
        {
            Communication communication = _communicationDal.Get(c => c.Address.Id == addressgId && !c.IsDeleted);

            return communication == null
                ? new ErrorDataResult<Communication>(CommunicationConstants.NotMatch)
                : new SuccessDataResult<Communication>(communication, CommunicationConstants.DataGet);
        }

        public IDataResult<List<Communication>> GetByCName(string CName)
        {

            List<Communication> communications = _communicationDal.GetAll(c => c.CommunicationName.ToLowerInvariant() == CName.ToLowerInvariant() && !c.IsDeleted).ToList();

            return communications == null
                ? new ErrorDataResult<List<Communication>>(CommunicationConstants.NotMatch)
                : new SuccessDataResult<List<Communication>>(communications, CommunicationConstants.DataGet);
        }

        public IDataResult<Communication> GetByEmail(string eMail)
        {
            Communication communication = _communicationDal.Get(c => c.Email == eMail && !c.IsDeleted);

            return communication == null
                ? new ErrorDataResult<Communication>(CommunicationConstants.NotMatch)
                : new SuccessDataResult<Communication>(communication, CommunicationConstants.DataGet);
        }

        public IDataResult<Communication>? GetbyFaxNumber(string faxNumber)
        {
            Communication communication = _communicationDal.Get(c => c.FaxNumber == faxNumber && !c.IsDeleted);

            return communication == null
                ? new ErrorDataResult<Communication>(CommunicationConstants.NotMatch)
                : new SuccessDataResult<Communication>(communication, CommunicationConstants.DataGet);
        }

        public IDataResult<Communication> GetByPhoneNumber(string phoneNumber)
        {
            Communication communication = _communicationDal.Get(c => c.PhoneNumber == phoneNumber && !c.IsDeleted);

            return communication == null
                ? new ErrorDataResult<Communication>(CommunicationConstants.NotMatch)
                : new SuccessDataResult<Communication>(communication, CommunicationConstants.DataGet);
        }

        public IDataResult<Communication> GetByWebSite(string webSite)
        {
            Communication communication = _communicationDal.Get(c => c.WebSite == webSite && !c.IsDeleted);

            return communication == null
                ? new ErrorDataResult<Communication>(CommunicationConstants.NotMatch)
                : new SuccessDataResult<Communication>(communication, CommunicationConstants.DataGet);
        }

        private IResult CommunicationChecker(Communication communication)
        {
            bool comControl = _communicationDal.GetAll(c => c.Email == communication.Email
            && c.WebSite == communication.WebSite
            && c.PhoneNumber == communication.PhoneNumber
            && !c.IsDeleted).Any();

            return comControl
                ? new ErrorResult(CommunicationConstants.commExist)
                : new SuccessResult();
        }
    }
}
