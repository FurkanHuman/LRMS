using Business.Abstract.Base;
using Core.Utilities.Result.Abstract;
using Entities.Concrete.Infos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IResearcherService: IFirstPersonBaseService<Researcher>
    {
        IDataResult<List<Researcher>> GetNamePreAttachmentList(string namePreAttachment);
        IDataResult<List<Researcher>> GetSpecialtyList(string Specialty);
    }
}
