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
            WriterDto dtoWriter = _writerDal.DtoGet(dw=>dw.Id==id);
            return dtoWriter==null
                ? new ErrorDataResult<WriterDto>(WriterConstants.DataNotGet)
                : new SuccessDataResult<WriterDto>(dtoWriter,WriterConstants.DataGet);
      
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
            IList<WriterDto> dtoWriters = _writerDal.DtoGetAll(n => ids.Contains(n.Id) && !n.IsDeleted);
            return dtoWriters == null
                ? new ErrorDataResult<IList<WriterDto>>(WriterConstants.DataNotGet)
                : new SuccessDataResult<IList<WriterDto>>(dtoWriters, WriterConstants.DataGet);
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
            IList<WriterDto> dtoWriters = _writerDal.DtoGetAll(n => n.Name.Contains(name) && !n.IsDeleted);
            return dtoWriters == null
                ? new ErrorDataResult<IList<WriterDto>>(WriterConstants.DataNotGet)
                : new SuccessDataResult<IList<WriterDto>>(dtoWriters, WriterConstants.DataGet);
        }

        public IDataResult<IList<Writer>> GetAllBySurname(string surname)
        {
            IList<Writer> writers = _writerDal.GetAll(n => n.SurName.Contains(surname) && !n.IsDeleted);
            return writers == null
                ? new ErrorDataResult<IList<Writer>>(WriterConstants.DataNotGet)
                : new SuccessDataResult<IList<Writer>>(writers, WriterConstants.DataGet);
        }

        public IDataResult<IList<WriterDto>> DtoGetAllBySurname(string surname)
        {
            IList<WriterDto> dtoWriters = _writerDal.DtoGetAll(n => n.SurName.Contains(surname) && !n.IsDeleted);
            return dtoWriters == null
                ? new ErrorDataResult<IList<WriterDto>>(WriterConstants.DataNotGet)
                : new SuccessDataResult<IList<WriterDto>>(dtoWriters, WriterConstants.DataGet);
        }

        public IDataResult<IList<Writer>> GetAllNamePreAttachment(string namePreAttachment)
        {
            IList<Writer> writers = _writerDal.GetAll(n => n.NamePreAttachment.Contains(namePreAttachment) && !n.IsDeleted);
            return writers == null
                ? new ErrorDataResult<IList<Writer>>(WriterConstants.DataNotGet)
                : new SuccessDataResult<IList<Writer>>(writers, WriterConstants.DataGet);
        }

        public IDataResult<IList<WriterDto>> DtoGetAllNamePreAttachment(string namePreAttachment)
        {
            IList<WriterDto> dtoWriters = _writerDal.DtoGetAll(n => n.NamePreAttachment.Contains(namePreAttachment) && !n.IsDeleted);
            return dtoWriters == null
                ? new ErrorDataResult<IList<WriterDto>>(WriterConstants.DataNotGet)
                : new SuccessDataResult<IList<WriterDto>>(dtoWriters, WriterConstants.DataGet);
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
            return new SuccessDataResult<IList<WriterDto>>(_writerDal.DtoGetAll(w => w.IsDeleted), WriterConstants.DataGet);
        }

        public IDataResult<IList<Writer>> GetAll()
        {
            return new SuccessDataResult<IList<Writer>>(_writerDal.GetAll(w => !w.IsDeleted), WriterConstants.DataGet);
        }

        public IDataResult<IList<WriterDto>> DtoGetAll()
        {
            return new SuccessDataResult<IList<WriterDto>>(_writerDal.DtoGetAll(w => !w.IsDeleted), WriterConstants.DataGet);
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
