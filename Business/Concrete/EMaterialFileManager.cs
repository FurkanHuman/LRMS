using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.FileHelper;
using Core.Utilities.Result.Abstract;
using Core.Utilities.Result.Concrete;
using DataAccess.Abstract;
using Entities.Concrete.Infos;
using Microsoft.AspNetCore.Http;
using System.Linq.Expressions;

namespace Business.Concrete
{
    public class EMaterialFileManager : IEMaterialFileService
    {
        private readonly IEMaterialFileDal _eMaterialFileDal;
        private readonly IFileHelper _fileHelper;

        public EMaterialFileManager(IEMaterialFileDal eMaterialFileDal, IFileHelper fileHelper)
        {
            _eMaterialFileDal = eMaterialFileDal;
            _fileHelper = fileHelper;
            _fileHelper.FullPath = Environment.CurrentDirectory + @"\wwwroot\Files\";
        }

        [ValidationAspect(typeof(EMaterialFileValidator), Priority = 1)]
        public IResult Add(IFormFile file, EMaterialFile eMaterialFile)
        {
            IDataResult<string> fileResult = _fileHelper.AddAsync(file);

            IResult result = BusinessRules.Run(FileCheck(file), EMaterialFileCheck(eMaterialFile), fileResult);
            if (result != null)
                return result;

            eMaterialFile.FileSizeMB = ((file.Length / 1024) / 1024);
            eMaterialFile.IsSecret = false;
            _eMaterialFileDal.Add(eMaterialFile);

            return new SuccessResult(EMaterialFileConstants.AddSuccess);
        }

        public IResult Delete(Guid id)
        {
            EMaterialFile eMaterialFile = _eMaterialFileDal.Get(eMF => eMF.Id == id);

            return eMaterialFile == null
                ? new ErrorResult(EMaterialFileConstants.DeleteFailed)
                : new SuccessResult(EMaterialFileConstants.DeleteSuccess);
        }

        public IResult ShadowDelete(Guid id)
        {
            EMaterialFile eMaterialFile = _eMaterialFileDal.Get(e => e.Id == id && !e.IsSecret);

            if (eMaterialFile == null)
                return new ErrorDataResult<EMaterialFile>(EMaterialFileConstants.NotMatch);

            eMaterialFile.IsSecret = true;

            _eMaterialFileDal.Update(eMaterialFile);

            return new SuccessDataResult<EMaterialFile>(EMaterialFileConstants.UpdateSuccess);
        }

        [ValidationAspect(typeof(EMaterialFileValidator), Priority = 1)]
        public IResult Update(IFormFile file, EMaterialFile eMaterialFile)
        {
            IDataResult<string> fileResult = _fileHelper.AddAsync(file);

            IResult result = BusinessRules.Run(FileCheck(file), EMaterialFileCheck(eMaterialFile), fileResult);
            if (result != null)
                return result;

            EMaterialFile oldEMaterialFile = _eMaterialFileDal.Get(o => o.Id.Equals(eMaterialFile.Id) && !o.IsSecret);

            if (oldEMaterialFile == null)
                return new ErrorDataResult<EMaterialFile>(EMaterialFileConstants.DataNotGet);

            EMaterialFile updatedEMaterialFile = eMaterialFile;

            updatedEMaterialFile.FileSizeMB = eMaterialFile.FileSizeMB = ((file.Length / 1024) / 1024);

            _eMaterialFileDal.Update(updatedEMaterialFile);
            return new SuccessResult(EMaterialFileConstants.UpdateSuccess);

        }

        public IDataResult<EMaterialFile> GetById(Guid id)
        {
            EMaterialFile eMaterialFile = _eMaterialFileDal.Get(e => e.Id == id);

            return eMaterialFile == null
                ? new ErrorDataResult<EMaterialFile>(EMaterialFileConstants.DataNotGet)
                : new SuccessDataResult<EMaterialFile>(eMaterialFile, EMaterialFileConstants.DataGet);
        }

        public IDataResult<List<EMaterialFile>> GetByNames(string name)
        {
            List<EMaterialFile> eMaterialFiles = _eMaterialFileDal.GetAll(e => e.FileName.Contains(name, StringComparison.CurrentCultureIgnoreCase) && !e.IsSecret).ToList();

            return eMaterialFiles == null
                ? new ErrorDataResult<List<EMaterialFile>>(EMaterialFileConstants.DataNotGet)
                : new SuccessDataResult<List<EMaterialFile>>(eMaterialFiles, EMaterialFileConstants.DataGet);
        }

        public IDataResult<List<EMaterialFile>> GetByFilterLists(Expression<Func<EMaterialFile, bool>>? filter = null)
        {
            return new SuccessDataResult<List<EMaterialFile>>(_eMaterialFileDal.GetAll(filter).ToList(), EMaterialFileConstants.DataGet);
        }

        public IDataResult<List<EMaterialFile>> GetAll()
        {
            return new SuccessDataResult<List<EMaterialFile>>(_eMaterialFileDal.GetAll(e => !e.IsSecret).ToList(), EMaterialFileConstants.DataGet);
        }

        public IDataResult<List<EMaterialFile>> GetAllBySecrets()
        {
            return new SuccessDataResult<List<EMaterialFile>>(_eMaterialFileDal.GetAll(e => e.IsSecret).ToList(), EMaterialFileConstants.DataGet);
        }

        private static IResult FileCheck(IFormFile file)
        {
            /* Fix it. Todo
             * this here write Image Comparator and
             * File virus checker.
            */
            if (file.Length > 0 || file.Length >= 2000000000)
                return new ErrorResult(EMaterialFileConstants.InvalidFileSize);

            if (!EMaterialFileConstants.FileExtension.Any(F => F == Path.GetExtension(file.FileName.ToLower())))
                return new ErrorResult(EMaterialFileConstants.InvalidFileExtension);
            return new SuccessResult();
        }

        private static IResult EMaterialFileCheck(EMaterialFile eMaterialFile)
        {
            // fix it todo
            if (eMaterialFile.IsSecret)
                return new ErrorResult(EMaterialFileConstants.BuildedTime);
            return new SuccessResult(EMaterialFileConstants.BuildedTime);
        }
    }
}
