using Business.Abstract;
using Business.Constants;
using Business.DependencyResolvers.Facade;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Result.Abstract;
using Core.Utilities.Result.Concrete;
using DataAccess.Abstract;
using Entities.Concrete.Infos;
using System.Linq.Expressions;

namespace Business.Concrete
{
    public class StockManager : IStockService
    {
        private readonly IStockDal _stockDal;
        private readonly IFacadeService _facadeService;

        public StockManager(IStockDal stockDal)
        {
            _stockDal = stockDal;
        }

        [ValidationAspect(typeof(StockValidator), Priority = 1)]
        public IResult Add(Stock stock)
        {
            IResult result = BusinessRules.Run(StockControl(stock));
            if (result != null)
                return result;

            stock.Library = _facadeService.LibraryService().GetById(stock.Library.Id).Data;
            stock.IsDeleted = false;

            _stockDal.Add(stock);
            return new SuccessResult(StockConstans.AddSuccess);
        }

        public IResult Delete(Guid id)
        {
            Stock stock = _stockDal.Get(s => s.Id == id);
            if (stock == null)
                return new ErrorResult(StockConstans.NotMatch);

            _stockDal.Delete(stock);
            return new SuccessResult(StockConstans.DeleteSuccess);
        }

        public IResult ShadowDelete(Guid id)
        {
            Stock stock = _stockDal.Get(s => s.Id == id && !s.IsDeleted);
            if (stock == null)
                return new ErrorResult(StockConstans.NotMatch);

            stock.IsDeleted = true;
            _stockDal.Update(stock);
            return new SuccessResult(StockConstans.EfDeletedSuccsess);
        }

        [ValidationAspect(typeof(CategoryValidator), Priority = 1)]
        public IResult Update(Stock stock)
        {
            IResult result = BusinessRules.Run(StockControl(stock));
            if (result != null)
                return result;

            stock.Library = _facadeService.LibraryService().GetById(stock.Library.Id).Data;
            stock.IsDeleted = false;

            _stockDal.Update(stock);
            return new SuccessResult(StockConstans.AddSuccess);
        }

        public IDataResult<IList<Stock>> GetAll()
        {
            return new SuccessDataResult<IList<Stock>>(_stockDal.GetAll(s => !s.IsDeleted), StockConstans.DataGet);
        }

        public IDataResult<IList<Stock>> GetAllByFilter(Expression<Func<Stock, bool>>? filter = null)
        {
            return new SuccessDataResult<IList<Stock>>(_stockDal.GetAll(filter), StockConstans.DataGet);
        }

        public IDataResult<IList<Stock>> GetAllByIsDeleted()
        {
            return new SuccessDataResult<IList<Stock>>(_stockDal.GetAll(s => s.IsDeleted), StockConstans.DataGet);
        }

        public IDataResult<Stock> GetById(Guid id)
        {
            Stock stock = _stockDal.Get(s => s.Id == id);
            return stock == null
               ? new ErrorDataResult<Stock>(StockConstans.NotMatch)
               : new SuccessDataResult<Stock>(stock, StockConstans.DataGet);
        }

        public IDataResult<IList<Stock>> GetAllByIds(Guid[] ids)
        {
            IList<Stock> stocks = _stockDal.GetAll(s => ids.Contains(s.Id) && !s.IsDeleted);
            return stocks == null
                ? new ErrorDataResult<IList<Stock>>(StockConstans.DataNotGet)
                : new SuccessDataResult<IList<Stock>>(stocks, StockConstans.DataGet);
        }

        public IDataResult<IList<Stock>> GetAllByLibrary(Guid libraryId)
        {
            IDataResult<Library> lib = _facadeService.LibraryService().GetById(libraryId);
            if (!lib.Success)
                return new ErrorDataResult<IList<Stock>>(lib.Message);

            IList<Stock> stocks = _stockDal.GetAll(s => s.Library == lib.Data && !s.IsDeleted);
            return stocks == null
                ? new ErrorDataResult<IList<Stock>>(StockConstans.DataNotGet)
                : new SuccessDataResult<IList<Stock>>(stocks, StockConstans.DataGet);
        }

        public IDataResult<IList<Stock>> GetAllByName(string name)
        {
            return new ErrorDataResult<IList<Stock>>(StockConstans.Disabled);
        }

        public IDataResult<IList<Stock>> GetAllByQuanty(uint quantity)
        {
            IList<Stock> stocks = _stockDal.GetAll(s => s.Quantity == quantity && !s.IsDeleted);
            return stocks == null
                ? new ErrorDataResult<IList<Stock>>(StockConstans.DataNotGet)
                : new SuccessDataResult<IList<Stock>>(stocks, StockConstans.DataGet);
        }

        public IDataResult<IList<Stock>> GetAllByStockCode(string stockCode)
        {
            IList<Stock> stocks = _stockDal.GetAll(s => s.StockCode.Contains(stockCode) && !s.IsDeleted);
            return stocks == null
                ? new ErrorDataResult<IList<Stock>>(StockConstans.DataNotGet)
                : new SuccessDataResult<IList<Stock>>(stocks, StockConstans.DataGet);
        }

        private IResult StockControl(Stock stock)
        {
            IDataResult<Library> library = _facadeService.LibraryService().GetById(stock.Library.Id);
            if (!library.Success)
                return new ErrorResult(library.Message);

            bool dbStockControl = _stockDal.Get(s =>

                s.Library == library
            && s.Quantity == stock.Quantity
            && s.StockCode == stock.StockCode

                ) != null;

            if (dbStockControl)
                return new ErrorResult(StockConstans.AlreadyExists);

            return new SuccessResult();
        }
    }
}
