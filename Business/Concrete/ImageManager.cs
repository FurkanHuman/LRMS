using Core.Utilities.FileHelper;
using Microsoft.AspNetCore.Http;

namespace Business.Concrete
{
    public class ImageManager : IImageService
    {
        private readonly IImageDal _imageDal;
        private readonly IFileHelper _fileHelper;

        public ImageManager(IImageDal image, IFileHelper fileHelper)
        {
            _imageDal = image;
            _fileHelper = fileHelper;
            _fileHelper.FullPath = Environment.CurrentDirectory + @"\wwwroot\Images\";
        }

        [ValidationAspect(typeof(ImageValidator), Priority = 1)]
        public IDataResult<Image> Add(IFormFile file)
        {
            IDataResult<string> fileResult = _fileHelper.AddAsync(file);

            IResult result = BusinessRules.Run(ImageCheck(file), fileResult);
            if (result != null)
                return new ErrorDataResult<Image>(result.Message);

            Image image = new()
            {
                ImagePath = fileResult.Data,
                Date = DateTime.Now,
                IsDeleted = false
            };
            _imageDal.Add(image);
            return new ErrorDataResult<Image>(image, ImageConstants.AddSuccess);
        }

        public IResult ShadowDelete(Guid id)
        {
            Image image = _imageDal.Get(i => i.Id == id && !i.IsDeleted);

            if (image == null)
                return new ErrorResult(ImageConstants.NotMatch);

            image.IsDeleted = true;
            _imageDal.Update(image);
            return new SuccessResult(ImageConstants.DataStatusChanged);
        }

        public IResult Delete(Guid id)
        {
            Image image = _imageDal.Get(i => i.Id == id);

            if (image == null)
                return new ErrorResult(ImageConstants.NotMatch);

            _fileHelper.DeleteAsync(image.ImagePath);
            _imageDal.Delete(image);

            return new SuccessResult(ImageConstants.FileDeleted);
        }

        [ValidationAspect(typeof(ImageValidator), Priority = 1)]
        public IDataResult<Image> Update(IFormFile file, Image image)
        {
            string oldPath = GetById(image.Id).Data.ImagePath;
            IDataResult<string> fileHelper = _fileHelper.UpdateAsync(oldPath, file);
            if (!fileHelper.Success)
                return new ErrorDataResult<Image>(fileHelper.Message);

            image.ImagePath = fileHelper.Data;
            image.Date = DateTime.Now;
            image.IsDeleted = false;

            _imageDal.Update(image);
            return new SuccessDataResult<Image>(image, ImageConstants.UpdateSuccess);
        }

        public IDataResult<Image> GetById(Guid id)
        {
            Image? image = _imageDal.Get(Z => Z.Id == id);
            return image == null
                ? new ErrorDataResult<Image>(ImageConstants.IsDeleted)
                : new SuccessDataResult<Image>(image, ImageConstants.DataGet);
        }

        public IDataResult<IList<Image>> GetAllByIds(Guid[] ids)
        {
            IList<Image> images = _imageDal.GetAll(i => ids.Contains(i.Id) && !i.IsDeleted);
            return images == null
                ? new ErrorDataResult<IList<Image>>(ImageConstants.IsDeleted)
                : new SuccessDataResult<IList<Image>>(images, ImageConstants.DataGet);
        }

        public IDataResult<IList<Image>> GetAllByFilter(Expression<Func<Image, bool>>? filter = null)
        {
            return new SuccessDataResult<IList<Image>>(_imageDal.GetAll(filter), ImageConstants.DataGet);
        }

        public IDataResult<IList<Image>> GetAll()
        {
            return new SuccessDataResult<IList<Image>>(_imageDal.GetAll(g => !g.IsDeleted), ImageConstants.DataGet);
        }

        public IDataResult<IList<Image>> GetAllByIsDeleted()
        {
            return new SuccessDataResult<IList<Image>>(_imageDal.GetAll(g => g.IsDeleted), ImageConstants.DataGet);
        }

        private static IResult ImageCheck(IFormFile file)
        {
            /* Fix it. Todo
             * this here write Image Comparator and
             * File virus checker.
            */
            if (file.Length > 0 || file.Length >= 2000000000)
                return new ErrorResult(ImageConstants.InvalidFileSize);

            if (!ImageConstants.ImageExtension.Any(F => F == Path.GetExtension(file.FileName.ToLower())))
                return new ErrorResult(ImageConstants.InvalidFileExtension);

            return new SuccessResult();
        }
    }
}
