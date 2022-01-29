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
    public class CoverImageManager : ICoverImageService
    {
        private readonly ICoverImageDal _coverImage;

        readonly IFileHelper fileHelper;
        public CoverImageManager(ICoverImageDal coverImage, IFileHelper fileHelper)
        {
            _coverImage = coverImage;
            this.fileHelper = fileHelper;
            this.fileHelper.FullPath = Environment.CurrentDirectory + @"\wwwroot\Images\";
        }

        public IResult Add(IFormFile file, CoverImage coverImage)
        {
            IResult result = BusinessRules.Run(ImageCheck(file), CoverImageCheck(coverImage));
            if (result != null)
                return result;

            coverImage.ImagePath = this.fileHelper.AddAsync(file).Data;
            coverImage.Date = DateTime.Now;
            coverImage.IsDeleted = false;

            _coverImage.Add(coverImage);
            return new SuccessResult(CoverImageConstants.AddSucces);
        }

        public IResult EfDelete(CoverImage coverImage, bool isdel)
        {
            CoverImage image = GetById(coverImage.Id).Data;
            if (image.IsDeleted == isdel)
                return new ErrorResult(CoverImageConstants.DataStatusUnchanged);
            _coverImage.Update(coverImage);
            return new SuccessResult(CoverImageConstants.DataStatusChanged);
        }

        public IResult Delete(CoverImage coverImage)
        {
            this.fileHelper.DeleteAsync(GetById(coverImage.Id).Data.ImagePath);
            _coverImage.Delete(_coverImage.Get(z => z.Id == coverImage.Id));
            return new SuccessResult(CoverImageConstants.FileDeleted);
        }

        public IResult Update(IFormFile file, CoverImage coverImage)
        {
            string oldPath = GetById(coverImage.Id).Data.ImagePath;
            coverImage.ImagePath = this.fileHelper.UpdateAsync(oldPath, file).Data;
            coverImage.Date = DateTime.Now;
            coverImage.IsDeleted = false;
            _coverImage.Update(coverImage);
            return new SuccessResult(CoverImageConstants.UpdateSuccess);
        }

        public IDataResult<CoverImage> GetById(int id)
        {
            CoverImage? coverImage = _coverImage.Get(Z => Z.Id == id && !Z.IsDeleted);
            return coverImage == null
                ? new ErrorDataResult<CoverImage>(CoverImageConstants.IsDeleted)
                : new SuccessDataResult<CoverImage>(coverImage, CoverImageConstants.DataGet);
        }

        public IDataResult<List<CoverImage>> GetList()
        {
            return new SuccessDataResult<List<CoverImage>>((List<CoverImage>)_coverImage.GetAll(g => !g.IsDeleted), CoverImageConstants.DataGet);
        }

        private static IResult CoverImageCheck(CoverImage coverImage)
        {
            if (coverImage.IsDeleted)
                return new ErrorResult(CoverImageConstants.IsDeleted);
            return new SuccessResult();
        }

        private static IResult ImageCheck(IFormFile file)
        {
            if (file.Length > 0)
                return new ErrorResult(CoverImageConstants.InvalidFileSize);

            if (!CoverImageConstants.CoverImageExtension.Any(F => F == Path.GetExtension(file.FileName.ToLower())))
                return new ErrorResult(CoverImageConstants.InvalidFileSize);

            return new SuccessResult();
        }
    }
}
