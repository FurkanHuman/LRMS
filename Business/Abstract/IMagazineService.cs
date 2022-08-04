using Business.Abstract.Base;
using Core.Utilities.Result.Abstract;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IMagazineService : IBasePaperService<Magazine>
    {
        IDataResult<IList<Magazine>> GetAllByMagazineType(byte magazineType);
        IDataResult<IList<Magazine>> GetAllByVolume(uint volume);
        IDataResult<Dictionary<byte, string>> GetAllEnumToDictionaryMagazineType();
    }
}