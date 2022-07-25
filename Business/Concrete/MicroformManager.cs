using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Result.Abstract;
using Core.Utilities.Result.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Concrete.Infos;
using System.Linq.Expressions;

namespace Business.Concrete
{
    public class MicroformManager : IMicroformService
    {
        private readonly IMicroformDal _microformDal;
        private readonly ICategoryService _categoryService;
        private readonly IDimensionService _dimensionService;
        private readonly IEMaterialFileService _eMaterialFileService;
        private readonly ITechnicalPlaceholderService _technicalPlaceholderService;
        private readonly IStockService _stockService;



        [ValidationAspect(typeof(MicroformValidator))]
        public IResult Add(Microform microform)
        {
            IResult result = BusinessRules.Run(MicroformControl(microform));
            if (result != null)
                return result;

            microform.IsDeleted = false;
            _microformDal.Add(microform);
            return new SuccessResult(MicroformConstants.AddSuccess);
        }

        public IResult Delete(Guid id)
        {
            Microform microform = _microformDal.Get(m => m.Id == id);
            if (microform == null)
                return new ErrorResult(MicroformConstants.NotMatch);

            _microformDal.Delete(microform);
            return new SuccessResult(MicroformConstants.DeleteSuccess);
        }

        public IResult ShadowDelete(Guid id)
        {
            Microform microform = _microformDal.Get(m => m.Id == id);
            if (microform == null)
                return new ErrorResult(MicroformConstants.NotMatch);

            microform.IsDeleted = true;
            _microformDal.Update(microform);
            return new SuccessResult(MicroformConstants.DeleteSuccess);
        }

        [ValidationAspect(typeof(MicroformValidator))]
        public IResult Update(Microform microform)
        {
            IResult result = BusinessRules.Run(MicroformControl(microform));
            if (result != null)
                return result;

            microform.IsDeleted = false;
            _microformDal.Update(microform);
            return new SuccessResult(MicroformConstants.UpdateSuccess);
        }

        public IDataResult<List<Microform>> GetAll()
        {
            return new SuccessDataResult<List<Microform>>(_microformDal.GetAll(m => !m.IsDeleted).ToList(), MicroformConstants.DataGet);
        }

        public IDataResult<List<Microform>> GetAllByCategories(int[] categoriesId)
        {

            IDataResult<List<Category>> categories = _categoryService.GetAllByIds(categoriesId);
            if (!categories.Success)
                return new ErrorDataResult<List<Microform>>(categories.Message);

            // List<Microform> microforms = _microformDal.GetAll(m => m.Categories == categories && m.IsDeleted).ToList();  // try code line
            List<Microform> microforms = _microformDal.GetAll(m => categories.Data.Select(c => c.Id).Contains(m.CategoryId) && m.IsDeleted).ToList();
            return microforms == null
               ? new ErrorDataResult<List<Microform>>(MicroformConstants.DataNotGet)
               : new SuccessDataResult<List<Microform>>(microforms, MicroformConstants.DataGet);
        }

        public IDataResult<List<Microform>> GetAllByDescriptionFinder(string finderString)
        {
            List<Microform> microforms = _microformDal.GetAll(m => m.Description.Contains(finderString) && m.IsDeleted).ToList();
            return microforms == null
               ? new ErrorDataResult<List<Microform>>(MicroformConstants.DataNotGet)
               : new SuccessDataResult<List<Microform>>(microforms, MicroformConstants.DataGet);
        }

        public IDataResult<List<Microform>> GetAllByDimension(Guid dimensionId)
        {
            IDataResult<Dimension> dimmension = _dimensionService.GetById(dimensionId);
            if (!dimmension.Success)
                return new ErrorDataResult<List<Microform>>(dimmension.Message);

            List<Microform> microforms = _microformDal.GetAll(m => m.DimensionsId == dimensionId && m.IsDeleted).ToList();
            return microforms == null
               ? new ErrorDataResult<List<Microform>>(MicroformConstants.DataNotGet)
               : new SuccessDataResult<List<Microform>>(microforms, MicroformConstants.DataGet);
        }

        public IDataResult<List<Microform>> GetAllByEMFile(Guid eMFileId)
        {
            IDataResult<EMaterialFile> eMFile = _eMaterialFileService.GetById(eMFileId);
            if (!eMFile.Success)
                return new ErrorDataResult<List<Microform>>(eMFile.Message);

            List<Microform> microforms = _microformDal.GetAll(m => m.EMaterialFilesId == eMFileId && m.IsDeleted).ToList();
            return microforms == null
               ? new ErrorDataResult<List<Microform>>(MicroformConstants.DataNotGet)
               : new SuccessDataResult<List<Microform>>(microforms, MicroformConstants.DataGet);
        }

        public IDataResult<List<Microform>> GetAllByFilter(Expression<Func<Microform, bool>>? filter = null)
        {
            return new SuccessDataResult<List<Microform>>(_microformDal.GetAll(filter).ToList(), MicroformConstants.DataGet);
        }

        public IDataResult<List<Microform>> GetAllByIds(Guid[] ids)
        {
            List<Microform> microforms = _microformDal.GetAll(m => ids.Contains(m.Id) && m.IsDeleted).ToList();
            return microforms == null
                ? new ErrorDataResult<List<Microform>>(MicroformConstants.DataNotGet)
                : new SuccessDataResult<List<Microform>>(microforms, MicroformConstants.DataGet);
        }

        public IDataResult<List<Microform>> GetAllByName(string name)
        {
            List<Microform> microforms = _microformDal.GetAll(m => m.Name.Contains(name) && !m.IsDeleted).ToList();
            return microforms.Count > 0
                ? new ErrorDataResult<List<Microform>>(MicroformConstants.DataNotGet)
                : new SuccessDataResult<List<Microform>>(microforms, MicroformConstants.DataGet);
        }

        public IDataResult<List<Microform>> GetAllByPrice(decimal minPrice, decimal? maxPrice = null)
        {
            List<Microform> microforms = maxPrice == null
                ? _microformDal.GetAll(m => m.Price == minPrice && !m.IsDeleted).ToList()
                : _microformDal.GetAll(m => m.Price >= minPrice && m.Price <= maxPrice && !m.IsDeleted).ToList();

            return microforms.Count > 0
                ? new ErrorDataResult<List<Microform>>(MicroformConstants.DataNotGet)
                : new SuccessDataResult<List<Microform>>(microforms, MicroformConstants.DataGet);
        }

        public IDataResult<List<Microform>> GetAllByScale(string scale)
        {
            List<Microform> microforms = _microformDal.GetAll(m => m.Scale.Contains(scale) && !m.IsDeleted).ToList();
            return microforms.Count > 0
                ? new ErrorDataResult<List<Microform>>(MicroformConstants.DataNotGet)
                : new SuccessDataResult<List<Microform>>(microforms, MicroformConstants.DataGet);
        }

        public IDataResult<List<Microform>> GetAllBySecret()
        {
            return new SuccessDataResult<List<Microform>>(_microformDal.GetAll(m => m.IsDeleted).ToList(), MicroformConstants.DataGet);
        }

        public IDataResult<List<Microform>> GetAllByTechnicalPlaceholder(Guid technicalPlaceholderId)
        {
            IDataResult<TechnicalPlaceholder> techPlaceHolder = _technicalPlaceholderService.GetById(technicalPlaceholderId);
            if (!techPlaceHolder.Success)
                return new ErrorDataResult<List<Microform>>(techPlaceHolder.Message);

            List<Microform> microforms = _microformDal.GetAll(m => m.TechnicalPlaceholdersId == technicalPlaceholderId && m.IsDeleted).ToList();
            return microforms == null
               ? new ErrorDataResult<List<Microform>>(MicroformConstants.DataNotGet)
               : new SuccessDataResult<List<Microform>>(microforms, MicroformConstants.DataGet);
        }

        public IDataResult<List<Microform>> GetAllByTitle(string title)
        {
            List<Microform> microforms = _microformDal.GetAll(m => m.Title.Contains(title) && !m.IsDeleted).ToList();
            return microforms.Count > 0
                ? new ErrorDataResult<List<Microform>>(MicroformConstants.DataNotGet)
                : new SuccessDataResult<List<Microform>>(microforms, MicroformConstants.DataGet);
        }

        public IDataResult<Microform> GetById(Guid id)
        {
            Microform microform = _microformDal.Get(m => m.Id == id);
            return microform == null
                ? new ErrorDataResult<Microform>(MicroformConstants.NotMatch)
                : new SuccessDataResult<Microform>(microform, MicroformConstants.DataGet);
        }

        public IDataResult<Microform> GetByStock(Guid stockId)
        {
            IDataResult<Stock> stock = _stockService.GetById(stockId);
            if (!stock.Success)
                return new ErrorDataResult<Microform>(stock.Message);

            Microform microform = _microformDal.Get(m => m.StockId == stockId && m.IsDeleted);
            return microform == null
               ? new ErrorDataResult<Microform>(MicroformConstants.DataNotGet)
               : new SuccessDataResult<Microform>(microform, MicroformConstants.DataGet);
        }

        public IDataResult<byte?> GetSecretLevel(Guid id)
        {
            byte? sLevel = _microformDal.Get(m => m.Id == id && !m.IsDeleted).SecretLevel;
            return sLevel == null
                ? new ErrorDataResult<byte?>(MicroformConstants.DataNotGet)
                : new SuccessDataResult<byte?>(sLevel, MicroformConstants.DataGet);
        }

        public IDataResult<byte> GetState(Guid id)
        {
            return new SuccessDataResult<byte>(_microformDal.Get(m => m.Id == id && !m.IsDeleted).State, MicroformConstants.DataGet);
        }

        IResult MicroformControl(Microform microform)
        {
            bool microformControl = _microformDal.Get(m =>

               m.Name == microform.Name
            && m.Description == microform.Description
            && m.Title == microform.Title
            && m.Price == microform.Price
            && m.Scale == microform.Scale
                ) != null;

            if (microformControl)
                return new ErrorResult(MicroformConstants.AlreadyExists);

            return new SuccessResult();
        }
    }
}
