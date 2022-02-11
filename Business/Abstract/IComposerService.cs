using Core.Utilities.Result.Abstract;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IComposerService: IFirstPersonBaseService<Composer>
    {

        IDataResult<List<Composer>> GetNamePreAttachmentList(string namePreAttachment);
    }
}
