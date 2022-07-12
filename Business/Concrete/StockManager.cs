using Business.Abstract;
using Business.Constants;
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
        private readonly ILibraryService _libraryService;

        public StockManager(IStockDal stockDal, ILibraryService libraryService)
        {
            _stockDal = stockDal;
            _libraryService = libraryService;
        }

        [ValidationAspect(typeof(StockValidator), Priority = 1)]
        public IResult Add(Stock stock)
        {
            IResult result = BusinessRules.Run(StockControl(stock));
            if (result != null)
                return result;

            stock.Library = _libraryService.GetById(stock.Library.Id).Data;
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

            stock.Library = _libraryService.GetById(stock.Library.Id).Data;
            stock.IsDeleted = false;

            _stockDal.Update(stock);
            return new SuccessResult(StockConstans.AddSuccess);
        }

        public IDataResult<List<Stock>> GetAll()
        {
            return new SuccessDataResult<List<Stock>>(_stockDal.GetAll(s => !s.IsDeleted).ToList(), StockConstans.DataGet);
        }

        public IDataResult<List<Stock>> GetAllByFilter(Expression<Func<Stock, bool>>? filter = null)
        {
            return new SuccessDataResult<List<Stock>>(_stockDal.GetAll(filter).ToList(), StockConstans.DataGet);
        }

        public IDataResult<List<Stock>> GetAllBySecrets()
        {
            return new SuccessDataResult<List<Stock>>(_stockDal.GetAll(s => s.IsDeleted).ToList(), StockConstans.DataGet);
        }

        public IDataResult<Stock> GetById(Guid id)
        {
            Stock stock = _stockDal.Get(s => s.Id == id);
            return stock == null
               ? new ErrorDataResult<Stock>(StockConstans.NotMatch)
               : new SuccessDataResult<Stock>(stock, StockConstans.DataGet);
        }

        public IDataResult<List<Stock>> GetByIds(Guid[] ids)
        {
            List<Stock> stocks = _stockDal.GetAll(s => ids.Contains(s.Id) && !s.IsDeleted).ToList();
            return stocks == null
                ? new ErrorDataResult<List<Stock>>(StockConstans.DataNotGet)
                : new SuccessDataResult<List<Stock>>(stocks, StockConstans.DataGet);
        }

        public IDataResult<List<Stock>> GetByLibraries(Guid libraryId)
        {
            IDataResult<Library> lib = _libraryService.GetById(libraryId);
            if (!lib.Success)
                return new ErrorDataResult<List<Stock>>(lib.Message);

            List<Stock> stocks = _stockDal.GetAll(s => s.Library == lib.Data && !s.IsDeleted).ToList();
            return stocks == null
                ? new ErrorDataResult<List<Stock>>(StockConstans.DataNotGet)
                : new SuccessDataResult<List<Stock>>(stocks, StockConstans.DataGet);
        }

        public IDataResult<List<Stock>> GetByNames(string name)
        {
            return new ErrorDataResult<List<Stock>>(StockConstans.Disabled);
        }

        public IDataResult<List<Stock>> GetByQuantites(uint quantity)
        {
            List<Stock> stocks = _stockDal.GetAll(s => s.Quantity == quantity && !s.IsDeleted).ToList();
            return stocks == null
                ? new ErrorDataResult<List<Stock>>(StockConstans.DataNotGet)
                : new SuccessDataResult<List<Stock>>(stocks, StockConstans.DataGet);
        }

        public IDataResult<List<Stock>> GetByStockCodes(string stockCode)
        {
            List<Stock> stocks = _stockDal.GetAll(s => s.StockCode.Contains(stockCode) && !s.IsDeleted).ToList();
            return stocks == null
                ? new ErrorDataResult<List<Stock>>(StockConstans.DataNotGet)
                : new SuccessDataResult<List<Stock>>(stocks, StockConstans.DataGet);
        }

        private IResult StockControl(Stock stock)
        {
            IDataResult<Library> library = _libraryService.GetById(stock.Library.Id);
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
