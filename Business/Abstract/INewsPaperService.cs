using Business.Abstract.Base;
using Core.Utilities.Result.Abstract;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface INewsPaperService : IBasePaperService<NewsPaper>
    {
        IDataResult<NewsPaper> GetByImage(Guid imageId);

        IDataResult<List<NewsPaper>> GetAllByDate(DateTime date);

        IDataResult<List<NewsPaper>> GetAllByNewsPaperName(string newPaperName);

        IDataResult<List<NewsPaper>> GetAllByNewsPaperNumber(uint number);
    }
}
