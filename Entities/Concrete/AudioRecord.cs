using Core.Entities.Abstract;
using Entities.Concrete.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class AudioRecord:MaterialBase,IEntity
    {
        public DateTime RecordDate { get; set; }
    }
}
