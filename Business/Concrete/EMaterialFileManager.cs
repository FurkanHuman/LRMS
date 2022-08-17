using Core.Utilities.FileHelper;
using Microsoft.AspNetCore.Http;

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
            if (eMaterialFile == null)
                return new ErrorResult(EMaterialFileConstants.NotMatch);

            _eMaterialFileDal.Delete(eMaterialFile);
            return new ErrorResult(EMaterialFileConstants.EfDeletedSuccsess);
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

        public IDataResult<IList<EMaterialFile>> GetAllByIds(Guid[] ids)
        {
            IList<EMaterialFile> eMaterialFiles = _eMaterialFileDal.GetAll(e => ids.Contains(e.Id) && !e.IsSecret);

            return eMaterialFiles == null
                ? new ErrorDataResult<IList<EMaterialFile>>(EMaterialFileConstants.DataNotGet)
                : new SuccessDataResult<IList<EMaterialFile>>(eMaterialFiles, EMaterialFileConstants.DataGet);
        }

        public IDataResult<IList<EMaterialFile>> GetAllByName(string name)
        {
            IList<EMaterialFile> eMaterialFiles = _eMaterialFileDal.GetAll(e => e.FileName.Contains(name) && !e.IsSecret);

            return eMaterialFiles == null
                ? new ErrorDataResult<IList<EMaterialFile>>(EMaterialFileConstants.DataNotGet)
                : new SuccessDataResult<IList<EMaterialFile>>(eMaterialFiles, EMaterialFileConstants.DataGet);
        }

        public IDataResult<IList<EMaterialFile>> GetAllByFilter(Expression<Func<EMaterialFile, bool>>? filter = null)
        {
            return new SuccessDataResult<IList<EMaterialFile>>(_eMaterialFileDal.GetAll(filter), EMaterialFileConstants.DataGet);
        }

        public IDataResult<IList<EMaterialFile>> GetAll()
        {
            return new SuccessDataResult<IList<EMaterialFile>>(_eMaterialFileDal.GetAll(e => !e.IsSecret), EMaterialFileConstants.DataGet);
        }

        public IDataResult<IList<EMaterialFile>> GetAllByIsDeleted()
        {
            return new SuccessDataResult<IList<EMaterialFile>>(_eMaterialFileDal.GetAll(e => e.IsSecret), EMaterialFileConstants.DataGet);
        }

        private static IResult FileCheck(IFormFile file)
        {
            // Fix it. Todo
            // File compare
            // File virus checker.

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
