using Core.DataAccess;
using Entities.Concrete.Infos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface ILanguageDal : IEntityRepository<Language>
    {
    }
}
