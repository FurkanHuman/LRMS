namespace Business.Concrete
{
    public class CommunicationManager : ICommunicationService
    {
        private readonly ICommunicationDal _communicationDal;

        public CommunicationManager(ICommunicationDal communicationDal)
        {
            _communicationDal = communicationDal;
        }

        [ValidationAspect(typeof(CommunicationValidator), Priority = 1)]
        public IResult Add(Communication communication)
        {
            IResult result = BusinessRules.Run(CommunicationChecker(communication));
            if (result != null)
                return result;

            communication.IsDeleted = false;
            _communicationDal.Add(communication);
            return new SuccessResult();
        }

        public IResult Delete(Guid id)
        {
            Communication communication = _communicationDal.Get(c => c.Id == id);
            if (communication == null)
                return new ErrorResult(CommunicationConstants.NotMatch);

            _communicationDal.Delete(communication);
            return new SuccessResult(CommunicationConstants.DeleteSuccess);
        }

        public IResult ShadowDelete(Guid id)
        {
            Communication communication = _communicationDal.Get(c => c.Id == id && !c.IsDeleted);
            if (communication == null)
                return new ErrorResult(CommunicationConstants.NotMatch);

            communication.IsDeleted = true;
            _communicationDal.Update(communication);
            return new SuccessResult(CommunicationConstants.ShadowDeleteSuccess);
        }

        [ValidationAspect(typeof(CommunicationValidator), Priority = 1)]
        public IResult Update(Communication communication)
        {
            IResult result = BusinessRules.Run(CommunicationChecker(communication));
            if (result != null)
                return result;

            _communicationDal.Update(communication);
            return new SuccessResult(CommunicationConstants.UpdateSuccess);
        }

        public IDataResult<Communication> GetById(Guid id)
        {
            Communication communication = _communicationDal.Get(c => c.Id == id && !c.IsDeleted);

            return communication == null
                ? new ErrorDataResult<Communication>(CommunicationConstants.NotMatch)
                : new SuccessDataResult<Communication>(communication, CommunicationConstants.DataGet);
        }

        public IDataResult<IList<Communication>> GetAllByIds(Guid[] ids)
        {
            IList<Communication> communications = _communicationDal.GetAll(c => ids.Contains(c.Id) && !c.IsDeleted);
            return communications == null
                ? new ErrorDataResult<IList<Communication>>(CommunicationConstants.NotMatch)
                : new SuccessDataResult<IList<Communication>>(communications, CommunicationConstants.DataGet);
        }

        public IDataResult<IList<Communication>> GetAllByFilter(Expression<Func<Communication, bool>>? filter = null)
        {
            return new SuccessDataResult<IList<Communication>>(_communicationDal.GetAll(filter), CommunicationConstants.DataGet);
        }

        public IDataResult<IList<Communication>> GetAllByName(string name)
        {
            IList<Communication> communications = _communicationDal.GetAll(c => c.CommunicationName.Contains(name) && !c.IsDeleted);
            return communications == null
                ? new ErrorDataResult<IList<Communication>>(CommunicationConstants.NotMatch)
                : new SuccessDataResult<IList<Communication>>(communications, CommunicationConstants.DataGet);
        }

        public IDataResult<Communication> GetByEmail(string eMail)
        {
            Communication communication = _communicationDal.Get(c => c.Email == eMail && !c.IsDeleted);
            return communication == null
                ? new ErrorDataResult<Communication>(CommunicationConstants.NotMatch)
                : new SuccessDataResult<Communication>(communication, CommunicationConstants.DataGet);
        }

        public IDataResult<Communication> GetByFaxNumber(string faxNumber)
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

        public IDataResult<IList<Communication>> GetAll()
        {
            return new SuccessDataResult<IList<Communication>>(_communicationDal.GetAll(c => !c.IsDeleted), CommunicationConstants.DataGet);
        }

        public IDataResult<IList<Communication>> GetAllByIsDeleted()
        {
            return new SuccessDataResult<IList<Communication>>(_communicationDal.GetAll(c => c.IsDeleted), CommunicationConstants.DataGet);
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
