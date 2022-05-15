using Business.Abstract;
using Business.Constants;
using Core.Utilities.Business;
using Core.Utilities.FileHelper;
using Core.Utilities.Result.Abstract;
using Core.Utilities.Result.Concrete;
using DataAccess.Abstract;
using Entities.Concrete.Infos;
using Microsoft.AspNetCore.Http;

namespace Business.Concrete
{
    public class ImageManager : IImageService
    {
        private readonly IImageDal _image;

        readonly IFileHelper fileHelper;
        public ImageManager(IImageDal image, IFileHelper fileHelper)
        {
            _image = image;
            this.fileHelper = fileHelper;
            this.fileHelper.FullPath = Environment.CurrentDirectory + @"\wwwroot\Images\";
        }

        public IResult Add(IFormFile file, Image image)
        {
            IResult result = BusinessRules.Run(ImageCheck(file), ImageCheck(image));
            if (result != null)
                return result;

            image.ImagePath = this.fileHelper.AddAsync(file).Data;
            image.Date = DateTime.Now;
            image.IsDeleted = false;

            _image.Add(image);
            return new SuccessResult(ImageConstants.AddSuccess);
        }

        public IResult EfDelete(Image efImage, bool isdel)
        {
            Image image = GetById(efImage.Id).Data;
            if (image.IsDeleted == isdel)
                return new ErrorResult(ImageConstants.DataStatusUnchanged);
            _image.Update(image);
            return new SuccessResult(ImageConstants.DataStatusChanged);
        }

        public IResult Delete(Image image)
        {
            this.fileHelper.DeleteAsync(GetById(image.Id).Data.ImagePath);
            _image.Delete(_image.Get(z => z.Id == image.Id));
            return new SuccessResult(ImageConstants.FileDeleted);
        }

        public IResult Update(IFormFile file, Image image)
        {
            string oldPath = GetById(image.Id).Data.ImagePath;
            image.ImagePath = this.fileHelper.UpdateAsync(oldPath, file).Data;
            image.Date = DateTime.Now;
            image.IsDeleted = false;
            _image.Update(image);
            return new SuccessResult(ImageConstants.UpdateSuccess);
        }

        public IDataResult<Image> GetById(Guid id)
        {
            Image? image = _image.Get(Z => Z.Id == id && !Z.IsDeleted);
            return image == null
                ? new ErrorDataResult<Image>(ImageConstants.IsDeleted)
                : new SuccessDataResult<Image>(image, ImageConstants.DataGet);
        }

        public IDataResult<List<Image>> GetList()
        {
            return new SuccessDataResult<List<Image>>((List<Image>)_image.GetAll(g => !g.IsDeleted), ImageConstants.DataGet);
        }

        private static IResult ImageCheck(Image image)
        {
            if (image.IsDeleted)
                return new ErrorResult(ImageConstants.IsDeleted);
            return new SuccessResult();
        }

        private static IResult ImageCheck(IFormFile file)
        {
            if (file.Length > 0)
                return new ErrorResult(ImageConstants.InvalidFileSize);

            if (!ImageConstants.ImageExtension.Any(F => F == Path.GetExtension(file.FileName.ToLower())))
                return new ErrorResult(ImageConstants.InvalidFileSize);

            return new SuccessResult();
        }
    }
}
