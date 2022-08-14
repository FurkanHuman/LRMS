using Business.Abstract;
using Business.Constants;
using Business.DependencyResolvers.Facade;
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
        private readonly IFacadeService _facadeService;

        public MicroformManager(IMicroformDal microformDal)
        {
            _microformDal = microformDal;
        }

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

        public IDataResult<IList<Microform>> GetAll()
        {
            return new SuccessDataResult<IList<Microform>>(_microformDal.GetAll(m => !m.IsDeleted), MicroformConstants.DataGet);
        }

        public IDataResult<IList<Microform>> GetAllByCategories(int[] categoriesId)
        {

            IDataResult<IList<Category>> categories = _facadeService.CategoryService().GetAllByIds(categoriesId);
            if (!categories.Success)
                return new ErrorDataResult<IList<Microform>>(categories.Message);

            // IList<Microform> microforms = _microformDal.GetAll(m => m.Categories == categories && m.IsDeleted);  // try code line
            IList<Microform> microforms = _microformDal.GetAll(m => categories.Data.Select(c => c.Id).Contains(m.CategoryId) && m.IsDeleted);
            return microforms == null
               ? new ErrorDataResult<IList<Microform>>(MicroformConstants.DataNotGet)
               : new SuccessDataResult<IList<Microform>>(microforms, MicroformConstants.DataGet);
        }

        public IDataResult<IList<Microform>> GetAllByDescriptionFinder(string finderString)
        {
            IList<Microform> microforms = _microformDal.GetAll(m => m.Description.Contains(finderString) && m.IsDeleted);
            return microforms == null
               ? new ErrorDataResult<IList<Microform>>(MicroformConstants.DataNotGet)
               : new SuccessDataResult<IList<Microform>>(microforms, MicroformConstants.DataGet);
        }

        public IDataResult<IList<Microform>> GetAllByDimension(Guid dimensionId)
        {
            IDataResult<Dimension> dimmension = _facadeService.DimensionService().GetById(dimensionId);
            if (!dimmension.Success)
                return new ErrorDataResult<IList<Microform>>(dimmension.Message);

            IList<Microform> microforms = _microformDal.GetAll(m => m.DimensionsId == dimensionId && m.IsDeleted);
            return microforms == null
               ? new ErrorDataResult<IList<Microform>>(MicroformConstants.DataNotGet)
               : new SuccessDataResult<IList<Microform>>(microforms, MicroformConstants.DataGet);
        }

        public IDataResult<IList<Microform>> GetAllByEMFile(Guid eMFileId)
        {
            IDataResult<EMaterialFile> eMFile = _facadeService.EMaterialFileService().GetById(eMFileId);
            if (!eMFile.Success)
                return new ErrorDataResult<IList<Microform>>(eMFile.Message);

            IList<Microform> microforms = _microformDal.GetAll(m => m.EMaterialFilesId == eMFileId && m.IsDeleted);
            return microforms == null
               ? new ErrorDataResult<IList<Microform>>(MicroformConstants.DataNotGet)
               : new SuccessDataResult<IList<Microform>>(microforms, MicroformConstants.DataGet);
        }

        public IDataResult<IList<Microform>> GetAllByFilter(Expression<Func<Microform, bool>>? filter = null)
        {
            return new SuccessDataResult<IList<Microform>>(_microformDal.GetAll(filter), MicroformConstants.DataGet);
        }

        public IDataResult<IList<Microform>> GetAllByIds(Guid[] ids)
        {
            IList<Microform> microforms = _microformDal.GetAll(m => ids.Contains(m.Id) && m.IsDeleted);
            _facadeService.CounterService().Count(microforms);
            return microforms == null
                ? new ErrorDataResult<IList<Microform>>(MicroformConstants.DataNotGet)
                : new SuccessDataResult<IList<Microform>>(microforms, MicroformConstants.DataGet);
        }

        public IDataResult<IList<Microform>> GetAllByName(string name)
        {
            IList<Microform> microforms = _microformDal.GetAll(m => m.Name.Contains(name) && !m.IsDeleted);
            return microforms.Count > 0
                ? new ErrorDataResult<IList<Microform>>(MicroformConstants.DataNotGet)
                : new SuccessDataResult<IList<Microform>>(microforms, MicroformConstants.DataGet);
        }

        public IDataResult<IList<Microform>> GetAllByPrice(decimal minPrice, decimal? maxPrice = null)
        {
            IList<Microform> microforms = maxPrice == null
                ? _microformDal.GetAll(m => m.Price == minPrice && !m.IsDeleted)
                : _microformDal.GetAll(m => m.Price >= minPrice && m.Price <= maxPrice && !m.IsDeleted);

            return microforms.Count > 0
                ? new ErrorDataResult<IList<Microform>>(MicroformConstants.DataNotGet)
                : new SuccessDataResult<IList<Microform>>(microforms, MicroformConstants.DataGet);
        }

        public IDataResult<IList<Microform>> GetAllByScale(string scale)
        {
            IList<Microform> microforms = _microformDal.GetAll(m => m.Scale.Contains(scale) && !m.IsDeleted);
            return microforms.Count > 0
                ? new ErrorDataResult<IList<Microform>>(MicroformConstants.DataNotGet)
                : new SuccessDataResult<IList<Microform>>(microforms, MicroformConstants.DataGet);
        }

        public IDataResult<IList<Microform>> GetAllByIsDeleted()
        {
            return new SuccessDataResult<IList<Microform>>(_microformDal.GetAll(m => m.IsDeleted), MicroformConstants.DataGet);
        }

        public IDataResult<IList<Microform>> GetAllByTechnicalPlaceholder(Guid technicalPlaceholderId)
        {
            IDataResult<TechnicalPlaceholder> techPlaceHolder = _facadeService.TechnicalPlaceholderService().GetById(technicalPlaceholderId);
            if (!techPlaceHolder.Success)
                return new ErrorDataResult<IList<Microform>>(techPlaceHolder.Message);

            IList<Microform> microforms = _microformDal.GetAll(m => m.TechnicalPlaceholdersId == technicalPlaceholderId && m.IsDeleted);
            return microforms == null
               ? new ErrorDataResult<IList<Microform>>(MicroformConstants.DataNotGet)
               : new SuccessDataResult<IList<Microform>>(microforms, MicroformConstants.DataGet);
        }

        public IDataResult<IList<Microform>> GetAllByTitle(string title)
        {
            IList<Microform> microforms = _microformDal.GetAll(m => m.Title.Contains(title) && !m.IsDeleted);
            return microforms.Count > 0
                ? new ErrorDataResult<IList<Microform>>(MicroformConstants.DataNotGet)
                : new SuccessDataResult<IList<Microform>>(microforms, MicroformConstants.DataGet);
        }

        public IDataResult<Microform> GetById(Guid id)
        {
            Microform microform = _microformDal.Get(m => m.Id == id);
            _facadeService.CounterService().Count(microform);
            return microform == null
                ? new ErrorDataResult<Microform>(MicroformConstants.NotMatch)
                : new SuccessDataResult<Microform>(microform, MicroformConstants.DataGet);
        }

        public IDataResult<Microform> GetByStock(Guid stockId)
        {
            IDataResult<Stock> stock = _facadeService.StockService().GetById(stockId);
            if (!stock.Success)
                return new ErrorDataResult<Microform>(stock.Message);

            Microform microform = _microformDal.Get(m => m.StockId == stockId && m.IsDeleted);
            _facadeService.CounterService().Count(microform);
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
