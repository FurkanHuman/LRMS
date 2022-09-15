using Entities.Abstract;
using Entities.Concrete.Entities.Infos;

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

        [ValidationAspect(typeof(CommunicationValidator), Priority = 1)]
        public IDataResult<CommunicationAddDto> DtoAdd(CommunicationAddDto addDto)
        {
            Communication communication = new MapperConfiguration(cfg => cfg.CreateMap<CommunicationAddDto, Communication>()).CreateMapper().Map<Communication>(addDto);

            IResult result = BusinessRules.Run(CommunicationChecker(communication));
            if (result != null)
                return new ErrorDataResult<CommunicationAddDto>(result.Message);

            communication.IsDeleted = false;

            Communication comm = _communicationDal.Add(communication);

            return comm != null
                ? new SuccessDataResult<CommunicationAddDto>(addDto, CommunicationConstants.AddSuccess)
                : new ErrorDataResult<CommunicationAddDto>(addDto, CommunicationConstants.AddFailed);
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

        [ValidationAspect(typeof(CommunicationValidator), Priority = 1)]
        public IDataResult<CommunicationUpdateDto> DtoUpdate(CommunicationUpdateDto updateDto)
        {
            Communication communication = new MapperConfiguration(cfg => cfg.CreateMap<CommunicationUpdateDto, Communication>()).CreateMapper().Map<Communication>(updateDto);

            IResult result = BusinessRules.Run(CommunicationChecker(communication));
            if (result != null)
                return new ErrorDataResult<CommunicationUpdateDto>(result.Message);

            Communication comm = _communicationDal.Update(communication);
            return comm != null
                ? new SuccessDataResult<CommunicationUpdateDto>(updateDto, CommunicationConstants.UpdateSuccess)
                : new ErrorDataResult<CommunicationUpdateDto>(updateDto, CommunicationConstants.UpdateFailed);
        }

        public IDataResult<Communication> GetById(Guid id)
        {
            Communication communication = _communicationDal.Get(c => c.Id == id && !c.IsDeleted);

            return communication == null
                ? new ErrorDataResult<Communication>(CommunicationConstants.NotMatch)
                : new SuccessDataResult<Communication>(communication, CommunicationConstants.DataGet);
        }

        public IDataResult<CommunicationDto> DtoGetById(Guid id)
        {
            CommunicationDto communicationDto = _communicationDal.DtoGet(c => c.Id == id);
            return communicationDto == null
                ? new ErrorDataResult<CommunicationDto>(CommunicationConstants.DataNotGet)
                : new SuccessDataResult<CommunicationDto>(communicationDto, CommunicationConstants.DataNotGet);
        }

        public IDataResult<IList<Communication>> GetAllByIds(Guid[] ids)
        {
            IList<Communication> communications = _communicationDal.GetAll(c => ids.Contains(c.Id) && !c.IsDeleted);
            return communications == null
                ? new ErrorDataResult<IList<Communication>>(CommunicationConstants.NotMatch)
                : new SuccessDataResult<IList<Communication>>(communications, CommunicationConstants.DataGet);
        }
        public IDataResult<IList<CommunicationDto>> DtoGetAllByIds(Guid[] ids)
        {
            IList<CommunicationDto> communicationDto = _communicationDal.DtoGetAll(c => ids.Contains(c.Id) && !c.IsDeleted);
            return communicationDto == null
                 ? new ErrorDataResult<IList<CommunicationDto>>(CommunicationConstants.DataNotGet)
                 : new SuccessDataResult<IList<CommunicationDto>>(communicationDto, CommunicationConstants.DataGet);
        }

        public IDataResult<IList<Communication>> GetAllByFilter(Expression<Func<Communication, bool>>? filter = null)
        {
            return new SuccessDataResult<IList<Communication>>(_communicationDal.GetAll(filter), CommunicationConstants.DataGet);
        }

        public IDataResult<IList<CommunicationDto>> DtoGetAllByFilter(Expression<Func<Communication, bool>>? filter = null)
        {
            return new SuccessDataResult<IList<CommunicationDto>>(_communicationDal.DtoGetAll(filter), CommunicationConstants.DataGet);
        }

        public IDataResult<IList<Communication>> GetAllByName(string name)
        {
            IList<Communication> communications = _communicationDal.GetAll(c => c.Name.Contains(name) && !c.IsDeleted);
            return communications == null
                ? new ErrorDataResult<IList<Communication>>(CommunicationConstants.NotMatch)
                : new SuccessDataResult<IList<Communication>>(communications, CommunicationConstants.DataGet);
        }

        public IDataResult<IList<CommunicationDto>> DtoGetAllByName(string name)
        {
            IList<CommunicationDto> communicationDto = _communicationDal.DtoGetAll(c => c.Name.Contains(name) && !c.IsDeleted);
            return communicationDto == null
                 ? new ErrorDataResult<IList<CommunicationDto>>(CommunicationConstants.DataNotGet)
                 : new SuccessDataResult<IList<CommunicationDto>>(communicationDto, CommunicationConstants.DataGet);
        }

        public IDataResult<Communication> GetByEmail(string eMail)
        {
            Communication communication = _communicationDal.Get(c => c.Email == eMail && !c.IsDeleted);
            return communication == null
                ? new ErrorDataResult<Communication>(CommunicationConstants.NotMatch)
                : new SuccessDataResult<Communication>(communication, CommunicationConstants.DataGet);
        }

        public IDataResult<CommunicationDto> DtoGetByEmail(string eMail)
        {
            CommunicationDto communicationDto = _communicationDal.DtoGet(c => c.Email == eMail && !c.IsDeleted);
            return communicationDto == null
                ? new ErrorDataResult<CommunicationDto>(CommunicationConstants.NotMatch)
                : new SuccessDataResult<CommunicationDto>(communicationDto, CommunicationConstants.DataGet);
        }

        public IDataResult<Communication> GetByFaxNumber(string faxNumber)
        {
            Communication communication = _communicationDal.Get(c => c.FaxNumber == faxNumber && !c.IsDeleted);
            return communication == null
                ? new ErrorDataResult<Communication>(CommunicationConstants.NotMatch)
                : new SuccessDataResult<Communication>(communication, CommunicationConstants.DataGet);
        }

        public IDataResult<CommunicationDto> DtoGetByFaxNumber(string faxNumber)
        {
            CommunicationDto communicationDto = _communicationDal.DtoGet(c => c.FaxNumber == faxNumber && !c.IsDeleted);
            return communicationDto == null
                ? new ErrorDataResult<CommunicationDto>(CommunicationConstants.NotMatch)
                : new SuccessDataResult<CommunicationDto>(communicationDto, CommunicationConstants.DataGet);
        }

        public IDataResult<Communication> GetByPhoneNumber(string phoneNumber)
        {
            Communication communication = _communicationDal.Get(c => c.PhoneNumber == phoneNumber && !c.IsDeleted);
            return communication == null
                ? new ErrorDataResult<Communication>(CommunicationConstants.NotMatch)
                : new SuccessDataResult<Communication>(communication, CommunicationConstants.DataGet);
        }

        public IDataResult<CommunicationDto> DtoGetByPhoneNumber(string phoneNumber)
        {
            CommunicationDto communicationDto = _communicationDal.DtoGet(c => c.PhoneNumber == phoneNumber && !c.IsDeleted);
            return communicationDto == null
                ? new ErrorDataResult<CommunicationDto>(CommunicationConstants.NotMatch)
                : new SuccessDataResult<CommunicationDto>(communicationDto, CommunicationConstants.DataGet);
        }

        public IDataResult<Communication> GetByWebSite(string webSite)
        {
            Communication communication = _communicationDal.Get(c => c.WebSite == webSite && !c.IsDeleted);
            return communication == null
                ? new ErrorDataResult<Communication>(CommunicationConstants.NotMatch)
                : new SuccessDataResult<Communication>(communication, CommunicationConstants.DataGet);
        }

        public IDataResult<CommunicationDto> DtoGetByWebSite(string webSite)
        {
            CommunicationDto communicationDto = _communicationDal.DtoGet(c => c.WebSite == webSite && !c.IsDeleted);
            return communicationDto == null
                ? new ErrorDataResult<CommunicationDto>(CommunicationConstants.NotMatch)
                : new SuccessDataResult<CommunicationDto>(communicationDto, CommunicationConstants.DataGet);
        }

        public IDataResult<IList<Communication>> GetAll()
        {
            return new SuccessDataResult<IList<Communication>>(_communicationDal.GetAll(c => !c.IsDeleted), CommunicationConstants.DataGet);
        }

        public IDataResult<IList<CommunicationDto>> DtoGetAll()
        {
            return new SuccessDataResult<IList<CommunicationDto>>(_communicationDal.DtoGetAll(c => !c.IsDeleted), CommunicationConstants.DataGet);
        }

        public IDataResult<IList<Communication>> GetAllByIsDeleted()
        {
            return new SuccessDataResult<IList<Communication>>(_communicationDal.GetAll(c => c.IsDeleted), CommunicationConstants.DataGet);
        }

        public IDataResult<IList<CommunicationDto>> DtoGetAllByIsDeleted()
        {
            return new SuccessDataResult<IList<CommunicationDto>>(_communicationDal.DtoGetAll(c => c.IsDeleted), CommunicationConstants.DataGet);
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
