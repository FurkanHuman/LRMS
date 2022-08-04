using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Result.Abstract;
using Core.Utilities.Result.Concrete;
using DataAccess.Abstract;
using Entities.Concrete.Infos;
using Entities.DTOs.Infos;
using System.Linq.Expressions;

namespace Business.Concrete
{
    public class WriterManager : IWriterService
    {
        private readonly IWriterDal _writerDal;

        public WriterManager(IWriterDal writerDal)
        {
            _writerDal = writerDal;
        }

        [ValidationAspect(typeof(WriterValidator), Priority = 1)]
        public IResult Add(Writer entity)
        {
            IResult result = BusinessRules.Run(WriterNameOrSurnameExist(entity));
            if (result != null)
                return result;

            entity.IsDeleted = false;
            _writerDal.Add(entity);
            return new SuccessResult(WriterConstants.AddSuccess);
        }

        public IResult Add(WriterDto entity)
        {
            return Add(new Writer
            {
                Name = entity.Name,
                SurName = entity.SurName,
                NamePreAttachment = entity.NamePreAttachment
            });
        }

        public IResult Delete(Guid id)
        {
            Writer writer = _writerDal.Get(w => w.Id == id && !w.IsDeleted);
            if (writer == null)
                return new ErrorResult(WriterConstants.NotMatch);

            _writerDal.Delete(writer);
            return new SuccessResult(WriterConstants.DeleteSuccess);
        }

        public IResult ShadowDelete(Guid id)
        {
            Writer writer = _writerDal.Get(w => w.Id == id && !w.IsDeleted);
            if (writer == null)
                return new ErrorResult(WriterConstants.NotMatch);

            writer.IsDeleted = true;
            _writerDal.Update(writer);
            return new SuccessResult(WriterConstants.ShadowDeleteSuccess);
        }

        [ValidationAspect(typeof(WriterValidator), Priority = 1)]
        public IResult Update(Writer entity)
        {
            IResult result = BusinessRules.Run(WriterNameOrSurnameExist(entity));
            if (result != null)
                return result;

            entity.IsDeleted = false;
            _writerDal.Update(entity);
            return new SuccessResult(WriterConstants.UpdateSuccess);
        }

        public IResult Update(WriterDto entity)
        {
            return Update(new Writer
            {
                Id = entity.Id,
                Name = entity.Name,
                SurName = entity.SurName,
                NamePreAttachment = entity.NamePreAttachment
            });
        }

        public IDataResult<Writer> GetById(Guid id)
        {
            Writer writer = _writerDal.Get(w => w.Id == id);
            return writer == null
                ? new ErrorDataResult<Writer>(WriterConstants.NotMatch)
                : new SuccessDataResult<Writer>(writer, WriterConstants.DataGet);
        }

        public IDataResult<WriterDto> DtoGetById(Guid id)
        {
            IDataResult<Writer> writerResult = GetById(id);
            return !writerResult.Success
                ? new ErrorDataResult<WriterDto>(writerResult.Message)
                : new SuccessDataResult<WriterDto>(new WriterDto
                {
                    Id = writerResult.Data.Id,
                    Name = writerResult.Data.Name,
                    SurName = writerResult.Data.SurName,
                    NamePreAttachment = writerResult.Data.NamePreAttachment
                }, writerResult.Message);
        }

        public IDataResult<IList<Writer>> GetAllByIds(Guid[] ids)
        {
            IList<Writer> writers = _writerDal.GetAll(n => ids.Contains(n.Id) && !n.IsDeleted);
            return writers == null
                ? new ErrorDataResult<IList<Writer>>(WriterConstants.DataNotGet)
                : new SuccessDataResult<IList<Writer>>(writers, WriterConstants.DataGet);
        }

        public IDataResult<IList<WriterDto>> DtoGetAllByIds(Guid[] ids)
        {
            return new ErrorDataResult<IList<WriterDto>>(WriterConstants.Disabled);
        }

        public IDataResult<IList<Writer>> GetAllByName(string name)
        {
            IList<Writer> writers = _writerDal.GetAll(n => n.Name.Contains(name) && !n.IsDeleted);
            return writers == null
                ? new ErrorDataResult<IList<Writer>>(WriterConstants.DataNotGet)
                : new SuccessDataResult<IList<Writer>>(writers, WriterConstants.DataGet);
        }

        public IDataResult<IList<WriterDto>> DtoGetAllByName(string name)
        {
            return new ErrorDataResult<IList<WriterDto>>(WriterConstants.Disabled);
        }

        public IDataResult<IList<Writer>> GetAllBySurname(string surname)
        {
            IList<Writer> writers = _writerDal.GetAll(n => n.Name.Contains(surname) && !n.IsDeleted);
            return writers == null
                ? new ErrorDataResult<IList<Writer>>(WriterConstants.DataNotGet)
                : new SuccessDataResult<IList<Writer>>(writers, WriterConstants.DataGet);
        }

        public IDataResult<IList<WriterDto>> DtoGetAllBySurname(string surname)
        {
            return new ErrorDataResult<IList<WriterDto>>(WriterConstants.Disabled);
        }

        public IDataResult<IList<Writer>> GetAllNamePreAttachment(string namePreAttachment)
        {
            return new SuccessDataResult<IList<Writer>>(_writerDal.GetAll(n => n.NamePreAttachment.Contains(namePreAttachment)
            && !n.IsDeleted), WriterConstants.DataGet);
        }

        public IDataResult<IList<WriterDto>> DtoGetAllNamePreAttachment(string namePreAttachment)
        {
            return new ErrorDataResult<IList<WriterDto>>(WriterConstants.Disabled);
        }

        public IDataResult<IList<Writer>> GetAllByFilter(Expression<Func<Writer, bool>>? filter = null)
        {
            return new SuccessDataResult<IList<Writer>>(_writerDal.GetAll(filter), WriterConstants.DataGet);
        }

        public IDataResult<IList<Writer>> GetAllByIsDeleted()
        {
            return new SuccessDataResult<IList<Writer>>(_writerDal.GetAll(w => w.IsDeleted), WriterConstants.DataGet);
        }

        public IDataResult<IList<WriterDto>> DtoGetAllByIsDeleted()
        {
            return new ErrorDataResult<IList<WriterDto>>(WriterConstants.Disabled);
        }

        public IDataResult<IList<Writer>> GetAll()
        {
            return new SuccessDataResult<IList<Writer>>(_writerDal.GetAll(w => !w.IsDeleted), WriterConstants.DataGet);
        }

        public IDataResult<IList<WriterDto>> DtoGetAll()
        {
            return new ErrorDataResult<IList<WriterDto>>(WriterConstants.Disabled);
        }

        private IResult WriterNameOrSurnameExist(Writer entity)
        {
            bool result = _writerDal.GetAll(w => w.Name.Equals(entity.Name)
            && w.SurName.Equals(entity.SurName)
            && w.NamePreAttachment.Equals(null)
            && entity.NamePreAttachment != null).Any();
            return result
                ? new ErrorResult(WriterConstants.WriterNameOrSurnameExist)
                : new SuccessResult(WriterConstants.DataGet);
        }
    }
}
