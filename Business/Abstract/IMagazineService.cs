using Business.Abstract.Base;
using Core.Utilities.Result.Abstract;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IMagazineService : IBasePaperService<Magazine>
    {
        IDataResult<List<Magazine>> GetByMagazineType(byte magazineType);
        IDataResult<List<Magazine>> GetByVolume(uint volume);
        IDataResult<Dictionary<byte, string>> GetAllEnumToDictionaryMagazineTypes();
    }
}