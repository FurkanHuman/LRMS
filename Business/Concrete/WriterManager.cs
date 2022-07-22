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

        public IDataResult<List<Writer>> GetAllByIds(Guid[] ids)
        {
            List<Writer> writers = _writerDal.GetAll(n => ids.Contains(n.Id) && !n.IsDeleted).ToList();
            return writers == null
                ? new ErrorDataResult<List<Writer>>(WriterConstants.DataNotGet)
                : new SuccessDataResult<List<Writer>>(writers, WriterConstants.DataGet);
        }

        public IDataResult<List<WriterDto>> DtoGetAllByIds(Guid[] ids)
        {
            IDataResult<List<Writer>> writersResult = GetAllByIds(ids);
            return !writersResult.Success
                ? new ErrorDataResult<List<WriterDto>>(writersResult.Message)
                : new SuccessDataResult<List<WriterDto>>(writersResult.Data.Select(w => new WriterDto
                {
                    Id = w.Id,
                    Name = w.Name,
                    SurName = w.SurName,
                    NamePreAttachment = w.NamePreAttachment
                }).ToList(), writersResult.Message);
        }

        public IDataResult<List<Writer>> GetAllByName(string name)
        {
            List<Writer> writers = _writerDal.GetAll(n => n.Name.Contains(name) && !n.IsDeleted).ToList();
            return writers == null
                ? new ErrorDataResult<List<Writer>>(WriterConstants.DataNotGet)
                : new SuccessDataResult<List<Writer>>(writers, WriterConstants.DataGet);
        }

        public IDataResult<List<WriterDto>> DtoGetAllByName(string name)
        {
            IDataResult<List<Writer>> writersResult = GetAllByName(name);
            return !writersResult.Success
                ? new ErrorDataResult<List<WriterDto>>(writersResult.Message)
                : new SuccessDataResult<List<WriterDto>>(writersResult.Data.Select(w => new WriterDto
                {
                    Id = w.Id,
                    Name = w.Name,
                    SurName = w.SurName,
                    NamePreAttachment = w.NamePreAttachment
                }).ToList(), writersResult.Message);
        }

        public IDataResult<List<Writer>> GetAllBySurname(string surname)
        {
            List<Writer> writers = _writerDal.GetAll(n => n.Name.Contains(surname) && !n.IsDeleted).ToList();
            return writers == null
                ? new ErrorDataResult<List<Writer>>(WriterConstants.DataNotGet)
                : new SuccessDataResult<List<Writer>>(writers, WriterConstants.DataGet);
        }

        public IDataResult<List<WriterDto>> DtoGetAllBySurname(string surname)
        {
            IDataResult<List<Writer>> writersResult = GetAllBySurname(surname);
            return !writersResult.Success
                ? new ErrorDataResult<List<WriterDto>>(writersResult.Message)
                : new SuccessDataResult<List<WriterDto>>(writersResult.Data.Select(w => new WriterDto
                {
                    Id = w.Id,
                    Name = w.Name,
                    SurName = w.SurName,
                    NamePreAttachment = w.NamePreAttachment
                }).ToList(), writersResult.Message);
        }

        public IDataResult<List<Writer>> GetAllNamePreAttachment(string namePreAttachment)
        {
            return new SuccessDataResult<List<Writer>>(_writerDal.GetAll(n => n.NamePreAttachment.Contains(namePreAttachment)
            && !n.IsDeleted).ToList(), WriterConstants.DataGet);
        }

        public IDataResult<List<WriterDto>> DtoGetAllNamePreAttachment(string namePreAttachment)
        {
            IDataResult<List<Writer>> writersResult = GetAllNamePreAttachment(namePreAttachment);
            return !writersResult.Success
                ? new ErrorDataResult<List<WriterDto>>(writersResult.Message)
                : new SuccessDataResult<List<WriterDto>>(writersResult.Data.Select(w => new WriterDto
                {
                    Id = w.Id,
                    Name = w.Name,
                    SurName = w.SurName,
                    NamePreAttachment = w.NamePreAttachment
                }).ToList(), writersResult.Message);
        }

        public IDataResult<List<Writer>> GetAllByFilter(Expression<Func<Writer, bool>>? filter = null)
        {
            return new SuccessDataResult<List<Writer>>(_writerDal.GetAll(filter).ToList(), WriterConstants.DataGet);
        }

        public IDataResult<List<Writer>> GetAllBySecret()
        {
            return new SuccessDataResult<List<Writer>>(_writerDal.GetAll(w => w.IsDeleted).ToList(), WriterConstants.DataGet);
        }

        public IDataResult<List<WriterDto>> DtoGetAllBySecret()
        {
            IDataResult<List<Writer>> writersResult = GetAllBySecret();
            return !writersResult.Success
                ? new ErrorDataResult<List<WriterDto>>(writersResult.Message)
                : new SuccessDataResult<List<WriterDto>>(writersResult.Data.Select(w => new WriterDto
                {
                    Id = w.Id,
                    Name = w.Name,
                    SurName = w.SurName,
                    NamePreAttachment = w.NamePreAttachment
                }).ToList(), writersResult.Message);
        }

        public IDataResult<List<Writer>> GetAll()
        {
            return new SuccessDataResult<List<Writer>>(_writerDal.GetAll(w => !w.IsDeleted).ToList(), WriterConstants.DataGet);
        }

        public IDataResult<List<WriterDto>> DtoGetAll()
        {
            IDataResult<List<Writer>> writersResult = GetAll();
            return !writersResult.Success
                ? new ErrorDataResult<List<WriterDto>>(writersResult.Message)
                : new SuccessDataResult<List<WriterDto>>(writersResult.Data.Select(w => new WriterDto
                {
                    Id = w.Id,
                    Name = w.Name,
                    SurName = w.SurName,
                    NamePreAttachment = w.NamePreAttachment
                }).ToList(), writersResult.Message);
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
