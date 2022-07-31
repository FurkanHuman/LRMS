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
    public class Object3DManager : IObject3DService
    {
        private readonly IObject3DDal _object3DDal;
        private readonly IFacadeService _facadeService;

        public Object3DManager(IObject3DDal object3DDal, IFacadeService facadeService)
        {
            _object3DDal = object3DDal;
            _facadeService = facadeService;
        }

        public IResult Add(Object3D object3D)
        {
            IResult result = BusinessRules.Run(Object3DControlDB(object3D));
            if (result != null)
                return result;

            object3D.IsDeleted = false;
            _object3DDal.Add(object3D);
            return new SuccessResult(Object3DConstants.AddSuccess);
        }

        public IResult Delete(Guid id)
        {
            Object3D object3D = _object3DDal.Get(o => o.Id == id);
            if (object3D == null)
                return new ErrorResult(Object3DConstants.NotMatch);

            _object3DDal.Delete(object3D);
            return new SuccessResult(Object3DConstants.EfDeletedSuccsess);
        }

        public IResult ShadowDelete(Guid id)
        {
            Object3D object3D = _object3DDal.Get(o => o.Id == id && !o.IsDeleted);
            if (object3D == null)
                return new ErrorResult(Object3DConstants.NotMatch);

            object3D.IsDeleted = true;
            _object3DDal.Update(object3D);
            return new SuccessResult(Object3DConstants.EfDeletedSuccsess);
        }

        [ValidationAspect(typeof(Object3DValidator))]
        public IResult Update(Object3D object3D)
        {
            IResult result = BusinessRules.Run(Object3DControlDB(object3D));
            if (result != null)
                return result;

            object3D.IsDeleted = false;
            _object3DDal.Update(object3D);
            return new SuccessResult(Object3DConstants.UpdateSuccess);
        }

        public IDataResult<List<Object3D>> GetAll()
        {
            return new SuccessDataResult<List<Object3D>>(_object3DDal.GetAll(o => !o.IsDeleted).ToList(), Object3DConstants.DataGet);
        }

        public IDataResult<List<Object3D>> GetAllByCategories(int[] categoriesId)
        {
            IDataResult<List<Category>> categories = _facadeService.CategoryService().GetAllByIds(categoriesId);
            if (!categories.Success)
                return new ErrorDataResult<List<Object3D>>(categories.Message);

            List<Object3D> object3Ds = _object3DDal.GetAll(o => o.Categories.ToList() == categories.Data.ToList() && !o.IsDeleted).ToList();
            return object3Ds == null
                ? new ErrorDataResult<List<Object3D>>(Object3DConstants.DataNotGet)
                : new SuccessDataResult<List<Object3D>>(object3Ds, Object3DConstants.DataGet);
        }

        public IDataResult<List<Object3D>> GetAllByDescriptionFinder(string finderString)
        {
            List<Object3D> object3Ds = _object3DDal.GetAll(o => o.Description.Contains(finderString) && !o.IsDeleted).ToList();
            return object3Ds == null
                ? new ErrorDataResult<List<Object3D>>(Object3DConstants.DataNotGet)
                : new SuccessDataResult<List<Object3D>>(object3Ds, Object3DConstants.DataGet);
        }

        public IDataResult<List<Object3D>> GetAllByDestroyState(bool state)
        {
            List<Object3D> object3Ds = _object3DDal.GetAll(o => o.IsDestroyed == state && !o.IsDeleted).ToList();
            return object3Ds == null
                ? new ErrorDataResult<List<Object3D>>(Object3DConstants.DataNotGet)
                : new SuccessDataResult<List<Object3D>>(object3Ds, Object3DConstants.DataGet);
        }

        public IDataResult<List<Object3D>> GetAllByDimension(Guid dimensionId)
        {
            IDataResult<Dimension> dimension = _facadeService.DimensionService().GetById(dimensionId);
            if (!dimension.Success)
                return new ErrorDataResult<List<Object3D>>(dimension.Message);

            List<Object3D> object3Ds = _object3DDal.GetAll(o => o.DimensionsId == dimensionId && !o.IsDeleted).ToList();
            return object3Ds == null
                ? new ErrorDataResult<List<Object3D>>(Object3DConstants.DataNotGet)
                : new SuccessDataResult<List<Object3D>>(object3Ds, Object3DConstants.DataGet);
        }

        public IDataResult<List<Object3D>> GetAllByEMFile(Guid eMFileId)
        {
            IDataResult<EMaterialFile> eMFile = _facadeService.EMaterialFileService().GetById(eMFileId);
            if (!eMFile.Success)
                return new ErrorDataResult<List<Object3D>>(eMFile.Message);

            List<Object3D> object3Ds = _object3DDal.GetAll(o => o.EMaterialFilesId == eMFileId && !o.IsDeleted).ToList();
            return object3Ds == null
                ? new ErrorDataResult<List<Object3D>>(Object3DConstants.DataNotGet)
                : new SuccessDataResult<List<Object3D>>(object3Ds, Object3DConstants.DataGet);
        }

        public IDataResult<List<Object3D>> GetAllByFilter(Expression<Func<Object3D, bool>>? filter = null)
        {
            return new SuccessDataResult<List<Object3D>>(_object3DDal.GetAll(filter).ToList(), Object3DConstants.DataGet);
        }

        public IDataResult<List<Object3D>> GetAllByIds(Guid[] ids)
        {
            List<Object3D> object3Ds = _object3DDal.GetAll(o => ids.Contains(o.Id) && !o.IsDeleted).ToList();
            return object3Ds == null
                ? new ErrorDataResult<List<Object3D>>(Object3DConstants.DataNotGet)
                : new SuccessDataResult<List<Object3D>>(object3Ds, Object3DConstants.DataGet);
        }

        public IDataResult<List<Object3D>> GetAllByName(string name)
        {
            List<Object3D> object3Ds = _object3DDal.GetAll(o => o.Name.Contains(name) && !o.IsDeleted).ToList();
            return object3Ds == null
                ? new ErrorDataResult<List<Object3D>>(Object3DConstants.DataNotGet)
                : new SuccessDataResult<List<Object3D>>(object3Ds, Object3DConstants.DataGet);
        }

        public IDataResult<List<Object3D>> GetAllByOwnerId(Guid ownerId)
        {
            IDataResult<OtherPeople> owner = _facadeService.OtherPeopleService().GetById(ownerId);
            if (!owner.Success)
                return new ErrorDataResult<List<Object3D>>(owner.Message);

            List<Object3D> object3Ds = _object3DDal.GetAll(o => o.Owner == owner && !o.IsDeleted).ToList();
            return object3Ds == null
                ? new ErrorDataResult<List<Object3D>>(Object3DConstants.DataNotGet)
                : new SuccessDataResult<List<Object3D>>(object3Ds, Object3DConstants.DataGet);
        }

        public IDataResult<List<Object3D>> GetAllByOwnersId(Guid[] ownerIds)
        {
            IDataResult<List<OtherPeople>> owners = _facadeService.OtherPeopleService().GetAllByIds(ownerIds);
            if (!owners.Success)
                return new ErrorDataResult<List<Object3D>>(owners.Message);

            List<Object3D> object3Ds = _object3DDal.GetAll(o => owners.Data.Contains(o.Owner) && !o.IsDeleted).ToList();
            return object3Ds == null
                ? new ErrorDataResult<List<Object3D>>(Object3DConstants.DataNotGet)
                : new SuccessDataResult<List<Object3D>>(object3Ds, Object3DConstants.DataGet);
        }

        public IDataResult<List<Object3D>> GetAllByPrice(decimal minPrice, decimal? maxPrice = null)
        {
            List<Object3D> object3Ds = maxPrice == null
                ? _object3DDal.GetAll(o => o.Price == minPrice && !o.IsDeleted).ToList()
                : _object3DDal.GetAll(o => o.Price >= minPrice && o.Price <= maxPrice && !o.IsDeleted).ToList();

            return object3Ds == null
                ? new ErrorDataResult<List<Object3D>>(Object3DConstants.DataNotGet)
                : new SuccessDataResult<List<Object3D>>(object3Ds, Object3DConstants.DataGet);
        }

        public IDataResult<List<Object3D>> GetAllBySecret()
        {
            return new SuccessDataResult<List<Object3D>>(_object3DDal.GetAll(o => o.IsDeleted).ToList(), Object3DConstants.DataGet);
        }

        public IDataResult<List<Object3D>> GetAllByTechnicalPlaceholder(Guid technicalPlaceholderId)
        {
            IDataResult<TechnicalPlaceholder> techPlaceHolder = _facadeService.TechnicalPlaceholderService().GetById(technicalPlaceholderId);
            if (!techPlaceHolder.Success)
                return new ErrorDataResult<List<Object3D>>(techPlaceHolder.Message);

            List<Object3D> object3Ds = _object3DDal.GetAll(o => o.TechnicalPlaceholdersId==technicalPlaceholderId && !o.IsDeleted).ToList();
            return object3Ds == null
                ? new ErrorDataResult<List<Object3D>>(Object3DConstants.DataNotGet)
                : new SuccessDataResult<List<Object3D>>(object3Ds, Object3DConstants.DataGet);
        }

        public IDataResult<List<Object3D>> GetAllByTitle(string title)
        {
            List<Object3D> object3Ds = _object3DDal.GetAll(o => o.Title.Contains(title) && !o.IsDeleted).ToList();
            return object3Ds == null
                ? new ErrorDataResult<List<Object3D>>(Object3DConstants.DataNotGet)
                : new SuccessDataResult<List<Object3D>>(object3Ds, Object3DConstants.DataGet);
        }

        public IDataResult<Object3D> GetById(Guid id)
        {
            Object3D object3D = _object3DDal.Get(o => o.Id == id);
            return object3D == null
                ? new ErrorDataResult<Object3D>(Object3DConstants.DataNotGet)
                : new SuccessDataResult<Object3D>(object3D, Object3DConstants.DataGet);
        }

        public IDataResult<Object3D> GetByImageId(Guid imageId)
        {
            IDataResult<Image> image = _facadeService.ImageService().GetById(imageId);
            if (!image.Success)
                return new ErrorDataResult<Object3D>(image.Message);

            Object3D object3D = _object3DDal.Get(o => o.ImageId==imageId && !o.IsDeleted);
            return object3D == null
                ? new ErrorDataResult<Object3D>(Object3DConstants.DataNotGet)
                : new SuccessDataResult<Object3D>(object3D, Object3DConstants.DataGet);
        }

        public IDataResult<Object3D> GetByStock(Guid stockId)
        {
            IDataResult<Stock> stock = _facadeService.StockService().GetById(stockId);
            if (!stock.Success)
                return new ErrorDataResult<Object3D>(stock.Message);

            Object3D object3D = _object3DDal.Get(o => o.StockId == stockId && !o.IsDeleted);
            return object3D == null
                ? new ErrorDataResult<Object3D>(Object3DConstants.DataNotGet)
                : new SuccessDataResult<Object3D>(object3D, Object3DConstants.DataGet);
        }

        public IDataResult<byte?> GetSecretLevel(Guid id)
        {
            byte? sLevel = _object3DDal.Get(o => o.Id == id && !o.IsDeleted).SecretLevel;
            return sLevel == null
                ? new ErrorDataResult<byte?>(Object3DConstants.DataNotGet)
                : new SuccessDataResult<byte?>(sLevel, Object3DConstants.DataGet);
        }

        public IDataResult<byte> GetState(Guid id)
        {
            return new SuccessDataResult<byte>(_object3DDal.Get(o => o.Id == id).State, Object3DConstants.DataGet);
        }

        private IResult Object3DControlDB(Object3D object3D)
        {
            bool obj3d = _object3DDal.Get(o =>

               o.Name == object3D.Name
            && o.Title == object3D.Title
            && o.Description == object3D.Description
            && o.Price == object3D.Price
            && o.StockId == object3D.StockId
            && o.State == object3D.State
            && o.Owner == object3D.Owner
            ) != null;

            if (obj3d)
                return new ErrorResult(Object3DConstants.AlreadyExists);
            return new SuccessResult();
        }
    }
}
