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

        public IResult Add(WriterDto entity)
        {
            return Add(new Writer
            {
                Name = entity.Name,
                SurName = entity.SurName,
                NamePreAttachment = entity.NamePreAttachment
            });
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

        [ValidationAspect(typeof(WriterValidator), Priority = 1)]
        public IResult Update(Writer entity)
        {
            _writerDal.Update(entity);
            return new SuccessResult(WriterConstants.UpdateSuccess);
        }

        public IDataResult<List<Writer>> GetByFilterList(Expression<Func<Writer, bool>>? filter = null)
        {
            return new SuccessDataResult<List<Writer>>(_writerDal.GetAll(filter).ToList(), WriterConstants.DataGet);
        }

        public IDataResult<WriterDto> DtoGetById(Guid id)
        {
            IDataResult<WriterDto> writerDtoResult ;
            // devam todo 
            




        }

        public IDataResult<Writer> GetById(Guid id)
        {
            Writer writer = _writerDal.Get(w => w.Id == id);
            return writer == null
                ? new ErrorDataResult<Writer>(WriterConstants.NotMatch)
                : new SuccessDataResult<Writer>(writer, WriterConstants.DataGet);
        }

        public IDataResult<List<WriterDto>> DtoGetByNames(string name)
        {
            return (IDataResult<List<WriterDto>>)GetByNames(name);
        }

        public IDataResult<List<Writer>> GetByNames(string name)
        {
            List<Writer> writers = _writerDal.GetAll(n => n.Name.Contains(name) && !n.IsDeleted).ToList();
            return writers == null
                ? new ErrorDataResult<List<Writer>>(WriterConstants.DataNotGet)
                : new SuccessDataResult<List<Writer>>(writers, WriterConstants.DataGet);
        }

        public IDataResult<List<WriterDto>> DtoGetBySurnames(string surname)
        {
            return (IDataResult<List<WriterDto>>)GetBySurnames(surname);
        }

        public IDataResult<List<Writer>> GetBySurnames(string surname)
        {
            List<Writer> writers = _writerDal.GetAll(n => n.Name.Contains(surname) && !n.IsDeleted).ToList();
            return writers == null
                ? new ErrorDataResult<List<Writer>>(WriterConstants.DataNotGet)
                : new SuccessDataResult<List<Writer>>(writers, WriterConstants.DataGet);
        }

        public IDataResult<List<WriterDto>> DtoGetNamePreAttachmentList(string namePreAttachment)
        {
            return (IDataResult<List<WriterDto>>)GetNamePreAttachmentList(namePreAttachment);
        }

        public IDataResult<List<Writer>> GetNamePreAttachmentList(string namePreAttachment)
        {
            return new SuccessDataResult<List<Writer>>(_writerDal.GetAll(n => n.NamePreAttachment.Contains(namePreAttachment)
            && !n.IsDeleted).ToList(), WriterConstants.DataGet);
        }

        public IDataResult<List<Writer>> GetAllByFilter(Expression<Func<Writer, bool>>? filter = null)
        {
            return new SuccessDataResult<List<Writer>>(_writerDal.GetAll(filter).ToList(), WriterConstants.DataGet);
        }

        public IDataResult<List<WriterDto>> DtoGetAllBySecrets()
        {
            return (IDataResult<List<WriterDto>>)GetAllBySecrets();
        }

        public IDataResult<List<Writer>> GetAllBySecrets()
        {
            return new SuccessDataResult<List<Writer>>(_writerDal.GetAll(w => w.IsDeleted).ToList(), WriterConstants.DataGet);
        }

        public IDataResult<List<WriterDto>> DtoGetAll()
        {
            return (IDataResult<List<WriterDto>>)GetAll();
        }

        public IDataResult<List<Writer>> GetAll()
        {
            return new SuccessDataResult<List<Writer>>(_writerDal.GetAll(w => !w.IsDeleted).ToList(), WriterConstants.DataGet);
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
