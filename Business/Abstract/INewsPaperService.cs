using Business.Abstract.Base;
using Core.Utilities.Result.Abstract;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface INewsPaperService : IBasePaperService<NewsPaper>
    {
        IDataResult<NewsPaper> GetByImage(Guid imageId);

        IDataResult<IList<NewsPaper>> GetAllByDate(DateTime date);

        IDataResult<IList<NewsPaper>> GetAllByNewsPaperName(string newPaperName);

        IDataResult<IList<NewsPaper>> GetAllByNewsPaperNumber(uint number);
    }
}
