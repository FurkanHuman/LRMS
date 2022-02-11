using Core.Utilities.Result.Abstract;
using Entities.Concrete.Infos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ILanguageService
    {
        IResult Add(Language language);
        IResult Delete(Language language);
        IResult Update(Language language);
        IDataResult<List<Language>> Getlist();
        IDataResult<Language> GetById(int id);
        IDataResult<Language> GetByLanguageName(string languageName);
    }
}
