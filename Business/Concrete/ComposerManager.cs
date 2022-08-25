using Entities.Abstract;
using Entities.Concrete.Entities.Infos;
using System.Xml.Linq;

namespace Business.Concrete
{
    public class ComposerManager : IComposerService
    {
        private readonly IComposerDal _composerDal;

        public ComposerManager(IComposerDal composerDal)
        {
            _composerDal = composerDal;
        }

        [ValidationAspect(typeof(ComposerValidator), Priority = 1)]
        public IResult Add(Composer entity)
        {
            IResult result = BusinessRules.Run(ComposerNameOrSurnameExist(entity));
            if (result != null)
                return result;

            entity.IsDeleted = false;
            _composerDal.Add(entity);
            return new SuccessResult(ComposerConstants.AddSuccess);
        }

        [ValidationAspect(typeof(ComposerValidator), Priority = 1)]
        public IDataResult<ComposerAddDto> DtoAdd(ComposerAddDto addDto)
        {
            Composer composer = new MapperConfiguration(cfg => cfg.CreateMap<ComposerAddDto, Composer>()).CreateMapper().Map<Composer>(addDto);

            IResult result = BusinessRules.Run(ComposerNameOrSurnameExist(composer));
            if (result != null)
                return new ErrorDataResult<ComposerAddDto>(result.Message);

            composer.IsDeleted = false;

            Composer composerUpdate = _composerDal.Add(composer);
            return composerUpdate != null
                ? new SuccessDataResult<ComposerAddDto>(addDto, ComposerConstants.AddSuccess)
                : new ErrorDataResult<ComposerAddDto>(addDto, ComposerConstants.AddFailed);
        }

        public IResult Delete(Guid id)
        {
            Composer composer = _composerDal.Get(g => g.Id == id);
            if (composer == null)
                return new ErrorResult(ComposerConstants.NotMatch);

            _composerDal.Delete(composer);
            return new SuccessResult(ComposerConstants.DeleteSuccess);
        }

        public IResult ShadowDelete(Guid id)
        {
            Composer composer = _composerDal.Get(g => g.Id == id && !g.IsDeleted);
            if (composer == null)
                return new ErrorResult(ComposerConstants.NotMatch);

            composer.IsDeleted = true;
            _composerDal.Update(composer);
            return new SuccessResult(ComposerConstants.ShadowDeleteSuccess);
        }

        [ValidationAspect(typeof(ComposerValidator), Priority = 1)]
        public IResult Update(Composer entity)
        {
            _composerDal.Update(entity);
            return new SuccessResult(ComposerConstants.UpdateSuccess);
        }

        [ValidationAspect(typeof(ComposerValidator), Priority = 1)]
        public IDataResult<ComposerUpdateDto> DtoUpdate(ComposerUpdateDto updateDto)
        {
            Composer composer = new MapperConfiguration(cfg => cfg.CreateMap<ComposerUpdateDto, Composer>()).CreateMapper().Map<Composer>(updateDto);

            Composer composerUpdate = _composerDal.Update(composer);
            return composerUpdate != null
                ? new SuccessDataResult<ComposerUpdateDto>(updateDto, ComposerConstants.UpdateSuccess)
                : new ErrorDataResult<ComposerUpdateDto>(updateDto, ComposerConstants.UpdateFailed);
        }

        public IDataResult<IList<Composer>> GetAllByFilter(Expression<Func<Composer, bool>>? filter = null)
        {
            return new SuccessDataResult<IList<Composer>>(_composerDal.GetAll(filter), ComposerConstants.DataGet);
        }

        public IDataResult<IList<ComposerDto>> DtoGetAllByFilter(Expression<Func<Composer, bool>>? filter = null)
        {
            return new SuccessDataResult<IList<ComposerDto>>(_composerDal.DtoGetAll(filter), ComposerConstants.DataGet);
        }

        public IDataResult<Composer> GetById(Guid id)
        {
            Composer composer = _composerDal.Get(c => c.Id == id);
            return composer == null
                ? new ErrorDataResult<Composer>(ComposerConstants.NotMatch)
                : new SuccessDataResult<Composer>(composer, ComposerConstants.DataGet);
        }

        public IDataResult<ComposerDto> DtoGetById(Guid id)
        {
            ComposerDto composerDto = _composerDal.DtoGet(c => c.Id == id && !c.IsDeleted);
            return composerDto != null
                ? new SuccessDataResult<ComposerDto>(composerDto, ComposerConstants.DataGet)
                : new ErrorDataResult<ComposerDto>(ComposerConstants.DataNotGet);
        }

        public IDataResult<IList<Composer>> GetAllByIds(Guid[] ids)
        {
            IList<Composer> composers = _composerDal.GetAll(c => ids.Contains(c.Id) && !c.IsDeleted);
            return composers == null
               ? new ErrorDataResult<IList<Composer>>(ComposerConstants.DataNotGet)
               : new SuccessDataResult<IList<Composer>>(composers, ComposerConstants.DataGet);
        }

        public IDataResult<IList<ComposerDto>> DtoGetAllByIds(Guid[] ids)
        {
            IList<ComposerDto> composerDtos = _composerDal.DtoGetAll(c => ids.Contains(c.Id) && !c.IsDeleted);
            return composerDtos != null
                ? new SuccessDataResult<IList<ComposerDto>>(composerDtos, ComposerConstants.DataGet)
                : new ErrorDataResult<IList<ComposerDto>>(ComposerConstants.DataNotGet);
        }

        public IDataResult<IList<Composer>> GetAllByName(string name)
        {
            IList<Composer> composers = _composerDal.GetAll(c => c.Name.Contains(name) && !c.IsDeleted);
            return composers == null
                ? new ErrorDataResult<IList<Composer>>(ComposerConstants.DataNotGet)
                : new SuccessDataResult<IList<Composer>>(composers, ComposerConstants.DataGet);
        }

        public IDataResult<IList<ComposerDto>> DtoGetAllByName(string name)
        {
            IList<ComposerDto> composerDtos = _composerDal.DtoGetAll(c => c.Name.Contains(name) && !c.IsDeleted);
            return composerDtos != null
                ? new SuccessDataResult<IList<ComposerDto>>(composerDtos, ComposerConstants.DataGet)
                : new ErrorDataResult<IList<ComposerDto>>(ComposerConstants.DataNotGet);
        }

        public IDataResult<IList<Composer>> GetAllBySurname(string surname)
        {
            IList<Composer> composers = _composerDal.GetAll(c => c.SurName.Contains(surname) && !c.IsDeleted);
            return composers == null
               ? new ErrorDataResult<IList<Composer>>(ComposerConstants.DataNotGet)
               : new SuccessDataResult<IList<Composer>>(composers, ComposerConstants.DataGet);
        }

        public IDataResult<IList<ComposerDto>> DtoGetAllBySurname(string surname)
        {
            IList<ComposerDto> composerDtos = _composerDal.DtoGetAll(c => c.SurName.Contains(surname) && !c.IsDeleted);
            return composerDtos != null
                ? new SuccessDataResult<IList<ComposerDto>>(composerDtos, ComposerConstants.DataGet)
                : new ErrorDataResult<IList<ComposerDto>>(ComposerConstants.DataNotGet);
        }

        public IDataResult<IList<Composer>> GetAllByNamePreAttachment(string namePreAttachment)
        {
            IList<Composer> composers = _composerDal.GetAll(c => c.NamePreAttachment.Contains(namePreAttachment) && !c.IsDeleted);
            return composers != null
                ? new SuccessDataResult<IList<Composer>>(composers, ComposerConstants.DataGet)
                : new ErrorDataResult<IList<Composer>>(ComposerConstants.DataNotGet);
        }

        public IDataResult<IList<ComposerDto>> DtoGetAllByNamePreAttachment(string namePreAttachment)
        {
            IList<ComposerDto> composerDtos = _composerDal.DtoGetAll(c => c.NamePreAttachment.Contains(namePreAttachment) && !c.IsDeleted);
            return composerDtos != null
                ? new SuccessDataResult<IList<ComposerDto>>(composerDtos, ComposerConstants.DataGet)
                : new ErrorDataResult<IList<ComposerDto>>(ComposerConstants.DataNotGet);
        }

        public IDataResult<IList<Composer>> GetAll()
        {
            return new SuccessDataResult<IList<Composer>>(_composerDal.GetAll(c => !c.IsDeleted), ComposerConstants.DataGet);
        }

        public IDataResult<IList<ComposerDto>> DtoGetAll()
        {

            return new SuccessDataResult<IList<ComposerDto>>(_composerDal.DtoGetAll(c => !c.IsDeleted), ComposerConstants.DataGet);
        }

        public IDataResult<IList<Composer>> GetAllByIsDeleted()
        {
            return new SuccessDataResult<IList<Composer>>(_composerDal.GetAll(c => c.IsDeleted), ComposerConstants.DataGet);
        }

        public IDataResult<IList<ComposerDto>> DtoGetAllByIsDeleted()
        {
            return new SuccessDataResult<IList<ComposerDto>>(_composerDal.DtoGetAll(c => c.IsDeleted), ComposerConstants.DataGet);
        }

        private IResult ComposerNameOrSurnameExist(Composer entity)
        {
            bool result = _composerDal.GetAll(c => c.Name.Equals(entity.Name)
            && c.SurName.ToUpperInvariant().Equals(entity.SurName.ToUpperInvariant())
            && c.NamePreAttachment.Equals(null)
            && entity.NamePreAttachment != null).Any();
            return result
                ? new ErrorResult(ComposerConstants.NameOrSurnameExists)
                : new SuccessResult(ComposerConstants.DataGet);
        }
    }
}