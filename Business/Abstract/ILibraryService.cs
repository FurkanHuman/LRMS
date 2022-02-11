using Core.Utilities.Result.Abstract;
using Entities.Concrete.Infos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ILibraryService
    {
        IResult Add(Library library);
        IResult Delete(Library library);
        IResult Update(Library library);
        IDataResult<Library> GetById(int id);
        IDataResult<List<Library>> GetByName(string name);
        IDataResult<List<Library>> GetByAddress(string address);
        IDataResult<List<Library>> GetAll();
    }
}
