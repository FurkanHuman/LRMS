using Business.Abstract.Base;
using Core.Utilities.Result.Abstract;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IMagazineService : IBasePaperService<Magazine>
    {
        IDataResult<List<Magazine>> GetAllByMagazineType(byte magazineType);
        IDataResult<List<Magazine>> GetAllByVolume(uint volume);
        IDataResult<Dictionary<byte, string>> GetAllEnumToDictionaryMagazineType();
    }
}