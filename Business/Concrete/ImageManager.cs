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
        public IResult Add(IFormFile file, Image image)
        {
            IDataResult<string> fileResult = _fileHelper.AddAsync(file);

            IResult result = BusinessRules.Run(ImageCheck(file), fileResult);
            if (result != null)
                return result;

            image.ImagePath = fileResult.Data;
            image.Date = DateTime.Now;
            image.IsDeleted = false;

            _imageDal.Add(image);
            return new SuccessResult(ImageConstants.AddSuccess);
        }

        public IResult ShadowDelete(Guid id)
        {
            Image image = _imageDal.Get(i => i.Id == id && !i.IsDeleted);
            
            if (image == null)
                return new ErrorResult(ImageConstants.NotMatch);

            image.IsDeleted = false;
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
        public IResult Update(IFormFile file, Image image)
        {
            string oldPath = GetById(image.Id).Data.ImagePath;
            image.ImagePath = _fileHelper.UpdateAsync(oldPath, file).Data;            
            image.Date = DateTime.Now;
            image.IsDeleted = false;
            _imageDal.Update(image);
            return new SuccessResult(ImageConstants.UpdateSuccess);
        }

        public IDataResult<Image> GetById(Guid id)
        {
            Image? image = _imageDal.Get(Z => Z.Id == id);
            return image == null
                ? new ErrorDataResult<Image>(ImageConstants.IsDeleted)
                : new SuccessDataResult<Image>(image, ImageConstants.DataGet);
        }

        public IDataResult<List<Image>> GetByFilterLists(Expression<Func<Image, bool>>? filter = null)
        {
            return new SuccessDataResult<List<Image>>(_imageDal.GetAll(filter).ToList(), ImageConstants.DataGet); 
        }

        public IDataResult<List<Image>> GetAll()
        {
            return new SuccessDataResult<List<Image>>(_imageDal.GetAll(g => !g.IsDeleted).ToList(), ImageConstants.DataGet);
        }

        public IDataResult<List<Image>> GetAllBySecrets()
        {
            return new SuccessDataResult<List<Image>>(_imageDal.GetAll(g => g.IsDeleted).ToList(), ImageConstants.DataGet);
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
