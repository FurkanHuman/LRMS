using Core.Utilities.Result.Abstract;
using Entities.Concrete.Base;

namespace Business.Abstract.Base
{
    public interface IBasePaperService<T> where T : BasePaper
    {
        IDataResult<T> GetById(int id);
        IDataResult<List<T>> GetByName(string names);
        IDataResult<List<T>> GetList();
        IDataResult<List<T>> GetByCategory(int categoryId);
        IDataResult<List<T>> GetByWriter(int writerId);
        IDataResult<List<T>> GetByEdition(int editionNum);
        IDataResult<List<T>> GetByPublisher(int publisherNum);
        IDataResult<List<T>> GetByCoverCap(int CoverCapNum);
        IDataResult<List<T>> GetByFilterList();
        IResult Add(T Entity);
        IResult Delete(T Entity);
        IResult Update(T Entity);
    }
}
